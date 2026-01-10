using ArtStore.Application.Common.Mappings;
using Microsoft.Extensions.Logging.Abstractions;
using AutoMapper;

namespace ArtStore.Application.UnitTests.Common.Mapping
{
    public class MappingTests
    {
        [Fact]
        public void MappingConfiguration_ShouldBeValid()
        {
			var nullLoggerFactory = NullLoggerFactory.Instance;
			// Arrange
			var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
			}, nullLoggerFactory);

            // Act & Assert
            config.AssertConfigurationIsValid();
		}
	}
}
