using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JSON.app
{
    public class DeserializationProcess
    {
        public IEnumerable<Review> reviewCollection;
        
        private void getReviewsFromFile(string path)
        {
            
            using (StreamReader streamReader = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                reviewCollection = new IEnumerable<Review>();
                
                
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Review review = serializer.Deserialize<Review>(reader);
                    }
                    
                }
            }
        }
    }
}