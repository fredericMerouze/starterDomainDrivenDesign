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
        private const string ApiNamepaspace = "CleanArchitecture.Api";

        public ArchitectureTests()
        {
        }

        [Fact]
        public void Domain_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = typeof(Domain.AssemblyReference).Assembly;
            string[] otherProjects = new string[]
            {
                PersistenceNamespace,
                PresentationNamespace,
                ApplicationNamespace,
                ApiNamepaspace
            };
            // Act
            var results = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            results.IsSuccessful.Should().BeTrue();
        }

/*        [Fact]
        public void Application_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(ApplicationNamespace);
            string[] otherProjects = new string[] {
                ApiNamepaspace,
                PersistenceNamespace,
                PresentationNamespace,
                DomainNamespace,
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
        public void Persitence_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(PersistenceNamespace);
            var otherProjects = new[] {
                PresentationNamespace,
                ApiNamepaspace,
                PresentationNamespace,
                DomainNamespace,
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
        public void Presentation_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(PresentationNamespace);
            var otherProjects = new[] {
                ApiNamepaspace,
                PersistenceNamespace,
                DomainNamespace,
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
        public void Api_Should_Not_HaveDependency_On_Other_Project()
        {
            // Arrange
            var assembly = Assembly.Load(PresentationNamespace);
            var otherProjects = new[] {
                PersistenceNamespace,
                DomainNamespace,
                ApplicationNamespace
            };

            // Act
            var results = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            results.IsSuccessful.Should().BeTrue();
        }*/
    }
}
