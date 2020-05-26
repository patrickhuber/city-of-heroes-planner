using Xunit;

namespace CityOfInfo.Data.Mids.Tests.Builds
{
    public class VersionTests
    {

        [Fact]
        public void FindCanLocateExistingVersion()
        {
            var schemaVersion = 1.0f;
            var version = Mids.Builds.SchemaVersion.Find(schemaVersion);
            Assert.NotNull(version);
            Assert.Equal(1, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(0, version.Patch);
        }

        [Fact]
        public void FindCanCalculateMissingVersion()
        {
            var schemaVersion = 3.1f;
            var version = Mids.Builds.SchemaVersion.Find(schemaVersion);
            Assert.NotNull(version);
            Assert.Equal(3, version.Major);
            Assert.Equal(10, version.Minor);
            Assert.Equal(0, version.Patch);
        }
    }
}
