using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;
using Xunit;

namespace CleanArchitecture.UnitTests.Architecture
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "CleanArchitecture.Domain";
        private const string ApplicationNamespace = "CleanArchitecture.Application";
        private const string PersistenceNamespace = "CleanArchitecture.Persistence";
        private const string PresentationNamespace = "CleanArchitecture";

        private IEnumerable<string> AssemblyNames = Enumerable.Empty<string>();

        public ArchitectureTests()
        {
            AssemblyNames = LoadAssemblies();
        }

        private IEnumerable<string> LoadAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName != null && x.FullName.Contains("CleanArchitecture"));

            if(assemblies.Any())
            {
                foreach(var assembly in assemblies)
                {
                    var assemblyName = assembly.GetName().Name;
                    if(assemblyName is not null)
                        yield return assemblyName;
                }
            }
        }
    
        [Fact]
        public void Domain_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var domainAssembly =  AssemblyNames.Where(x => x.Equals(DomainNamespace)).First();
            string[] otherProjects = AssemblyNames.Where(x => !x.Equals(DomainNamespace)).ToArray();
            // Act
            var results = Types.InAssembly(Assembly.Load(domainAssembly))
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();
      
            // Assert
            results.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Application_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            string applicationAssembly = AssemblyNames.Where(x => x.Equals(ApplicationNamespace)).First();
            string[] otherProjects = new string[] {
                ApplicationNamespace,
                DomainNamespace,
                PersistenceNamespace
            };

            var types = Types.InCurrentDomain();

            // Act
            var results = types.That().ResideInNamespace(applicationAssembly)
                .Should()
                .HaveDependencyOn(PresentationNamespace)
                .GetResult();

            // Assert
            results.IsSuccessful.Should().BeTrue();
        }



    }
}
