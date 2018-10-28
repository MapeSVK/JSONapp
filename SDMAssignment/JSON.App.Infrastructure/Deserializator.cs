using System.Collections.Generic;
using System.IO;
using JSON.app;
using JSON.App.Core.DomainService;
using Newtonsoft.Json;

namespace JSON.App.Infrastructure
{
    public class Deserializator: IDeserializator
    {
        private readonly string _path = "ratings.json";
        
        public Deserializator()
        {
            GetReviewsFromFile(_path);
        }             
        
        private IEnumerable<Rating> _ratingCollection;

        public IEnumerable<Rating> RatingCollection()
        {
            return _ratingCollection;
        }

        public void GetReviewsFromFile(string _path)
        {           
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var ratingHashSet = new HashSet<Rating>();
                
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Rating review = serializer.Deserialize<Rating>(reader);
                        ratingHashSet.Add(review);
                    }
                    
                }
                _ratingCollection = ratingHashSet;
            }
        }
    }
}