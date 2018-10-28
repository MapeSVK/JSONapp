using System.Collections.Generic;
using JSON.app;

namespace JSON.App.Core.DomainService
{
    public interface IDeserializator
    {
        IEnumerable<Rating> RatingCollection();
        
        void GetReviewsFromFile(string path);
    }
}