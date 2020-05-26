using CityOfInfo.Data.Mids.Builds;
using CityOfInfo.Data.Mids.Links;
using CityOfInfo.Data.Mids.Saves;
using System.IO;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests.Builds
{

    public class CharacterReaderTests
    {

        [Fact]
        public void CanRead()
        {
            var reader = new StringReader("|MxDz;1862;706;1412;HEX;||78DA6D944B6F125114C7676028E5551EA5D052A08516DA824550F726DAD6444BD284449784B4572041203334EAD2857B6DAD6E7CB43E125F71E56BE9EB4BA855E307B0F5191F9BF1C0BD70CE62260CF9CDFF9EFBBFE79E7367F267E69C8F8E9C3B28C98EC3B592A6150FA9AB2D66C997CAD565B3244976ED5449AB54976B4CB3C263A8335CCCB31A6399C26A93A9C5424B65F572AB12E44373EC24AB6B2C73A25AAB351BA7992AB9961A8D5A66A15AAEB4AAF5B2BDF3546832B6E2ECE0222B354177771F56980A0B367DF3CDEA7266BEA4B62AC57C496B31F5EC302490843B2EC35FFB96748BB40959E61459876B6A8BF04DC2B79053B79167EF20BF9588E74FD44DBF08FF4656FE12DE87DC1F049308E7776D4BEE699689671FF1EC239EFD7F9027609E59E463762AA8BB080F204FBA097B087B91DF839B857BCA9649A9A787092760BCDDE8F6BAD60B38D7791179608DF03AB2E712E10DE46D70B3893AD876708FF65DC2DF909DDF919330CFC1F3911C9A097B0149BA84EE3A8FFA0750DC9DA2EB8A3B8C3EE10872348A1C1B43CE8D93330316DECE81D0656F1AEBE323FC117090EF4B1ABC82399821B721B1DF21D2F700E97B80F47D98F45D81B9413137D836E9C6F89143C7C819F6A01E87B923A2BF2324CF10E14F80A33CC6344AFC53C42747D60A806744C447487C94C4447F603E33208F89F3337615CFC0F835C2D709DF408E6D12DE42F65AC53B0FFB8A931C26480E9F6134C1D7352748CD93A4E64952F324A9F93AE0349FAB4CDFC57567EE11BE4FF80172EA21F206F8A4799E4AFA05EA7B5E127E45F835F2EC1BE4CBE09311F9641EA3BEF709E1A7849F21E79E2307A16E59F18E64DB027F1314495C3AFCBA6ACA50CD1AAA394375BFA17AC0505D507A5F5B7DD13062491101A0CA3DD5E681AF2257F52FF6DED79544ECA26A9263D863DF713C2BFEA3C0539C770C5DBEA22ACBE4CDF6AF21FF0B008A3DFC07685F8D90|");
            var saveReader = new SaveReader(reader);
            var save = saveReader.Read();
            Assert.NotNull(save);
            Assert.NotNull(save.CompressionData);

            using var stream = new CompressionDataStream(save.CompressionData);
            using var binaryReader = new BinaryReader(stream);
            var characterReader = new CharacterReader(binaryReader);
            var character = characterReader.Read();
            Assert.NotNull(character);
            Assert.NotNull(character.Archetype);
            Assert.NotNull(character.Name);
            Assert.Equal("smashicles", character.Name);

            Assert.Equal("Class_Brute", character.Archetype.ClassName);
            Assert.Equal("Brute", character.Archetype.DisplayName);
            Assert.Equal<object>(SchemaVersion.v1_1_0, character.Version);
            Assert.True(character.UseSubpowerFields);
            Assert.False(character.UseQualifiedNames);

            Assert.NotNull(character.Builds);
            Assert.Single(character.Builds);

            foreach (var build in character.Builds)
            {
                Assert.NotNull(build.PowerSlots);
                Assert.Equal(39, build.PowerSlots.Count);

                Assert.NotNull(build.PowerSets);
                Assert.Equal(8, build.PowerSets.Count);
                Assert.Equal(23, build.LastPower);
            }
        }

        [Fact]
        public void CanReadEmptyBuild()
        {
            var linkData = "http://www.cohplanner.com/mids/download.php?uc=609&c=250&a=500&f=HEX&dc=78DAF3AD70E159E7DE68CFC0C8EB9C93585C1CEF04244B528B587D13D333931980802B332F393FB72027B524951DC895832A880F4ACC4B4F4DD10B4A4CC94C2CC9CCCF83E854834907971614E4179520C9FB26E6651694E680390C8201F9F9397A9E796599C599499939992595226011D78A82D4A2CCDCD4BC12B03A5EB0A05B667A4649665E3A37849703E20ABA166426EB39E7E7A4000D06D9582901749D1A1047F23240C17F20020206734D7491FF7405322CE8F62B824418C122FFBDB5E0B2FFB530541A6088186288186388986088F8608804B0409D001461048B700A303030435DF2960B28CB882CFB1E43E41D86C8070C110042BB08B9";
            var link = new LinkReader(new StringReader(linkData)).Read();
            Assert.NotNull(link);
            Assert.NotNull(link.CompressionData);

            using var stream = new CompressionDataStream(link.CompressionData);
            using var binaryReader = new BinaryReader(stream);
            var characterReader = new CharacterReader(binaryReader);
            var character = characterReader.Read();
            Assert.NotNull(character);
            Assert.NotNull(character.Archetype);
            Assert.Equal("Blaster", character.Archetype.DisplayName);
            Assert.NotNull(character.Name);
            Assert.Equal("incomplete", character.Name);

            foreach (var build in character.Builds)
            {
                Assert.NotNull(build.PowerSets);
                Assert.Equal(8, build.PowerSets.Count);

                Assert.NotNull(build.PowerSlots);
                Assert.Equal(39, build.PowerSlots.Count);
            }
        }
    }
}
