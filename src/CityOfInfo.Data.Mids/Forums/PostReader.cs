using CityOfInfo.Data.Mids.Saves;
using System.IO;

namespace CityOfInfo.Data.Mids.Forums
{
    public class PostReader
    {
        private StringReader _reader;

        public PostReader(StringReader reader)
        {
            _reader = reader;
        }

        public Post Read()
        {
            var save = new SaveReader(_reader).Read();
            return ConvertToPost(save);
        }

        private Post ConvertToPost(Save save)
        {
            return new Post
            {
                CompressionData = save.CompressionData
            };
        }
    }
}
