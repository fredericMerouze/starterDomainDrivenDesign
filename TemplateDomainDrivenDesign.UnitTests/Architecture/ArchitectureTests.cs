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
        private const string PresentationNamespace = "CleanArchitecture.Presentation";

        public ArchitectureTests()
        {
        }

        [Fact]
        public void Domain_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(DomainNamespace);
            string[] otherProjects = new string[]
            {
                PersistenceNamespace,
                PresentationNamespace,
                ApplicationNamespace
            };
            // Act
            var results = Types.InAssembly(assembly)
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
            var assembly = Assembly.Load(ApplicationNamespace);
            string[] otherProjects = new string[] {
                DomainNamespace,
                PersistenceNamespace,
                PresentationNamespace
            };

            // Act
            var results = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            results.IsSuccessful.Should().BeTrue();
        }



        [Fact]
        public void Infrastructure_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(PersistenceNamespace);
            var otherProjects = new[] {
                PresentationNamespace
            };

            // Act
            var results = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            results.IsSuccessful.Should().BeTrue();
        }
    }
}
