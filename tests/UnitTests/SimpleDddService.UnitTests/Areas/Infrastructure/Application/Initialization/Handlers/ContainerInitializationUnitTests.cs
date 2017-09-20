using NUnit.Framework;
using SimpleDddService.Infrastructure.Application.Initialization.Handlers;

namespace SimpleDddService.UnitTests.Areas.Infrastructure.Application.Initialization.Handlers
{
    [TestFixture]
    public class ContainerInitializationUnitTests
    {
        [Test]
        public void CreatingInitializedContainer_WithValidConfiguration_DoesntFailAssertion()
        {
            // Given & When
            var container = ContainerInitialization.CreateInitializedContainer();

            // Then
            container.AssertConfigurationIsValid();
        }
    }
}