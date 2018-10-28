using System;
using System.Diagnostics;
using System.IO;
using JSON.App.Core.DomainService;
using System.Linq;
namespace JSON.app
{
    public class Function: IFunction
    {
        private readonly IDeserializator _deserializator;
        
        public Function(IDeserializator deserializator)
        {
            _deserializator = deserializator;
        }
        public int GetNumberOfReviewsByReviewer(int reviewerId)
        {
            var stopwatch = StartWatch();
            var numberOfReviews = _deserializator.RatingCollection().Count(n => n.Reviewer == reviewerId);
            StopWatchAndCheckTime("GetNumberOfReviewsByReviewer", stopwatch);
            return numberOfReviews;
        }

        public float GetAverageGradeOfReviewsByReviewer(int reviewerId)
        {
            var sumOfReviewersGrades = _deserializator.RatingCollection().Where(n => n.Reviewer == reviewerId).Sum(o => o.Grade);
            return sumOfReviewersGrades/GetNumberOfReviewsByReviewer(reviewerId);
        }

        public int GetNumberOfSpecificGradesByReviewer(int specificGrade, int reviewerId)
        {
            var amountOfSpecificGradeByReviewer =  _deserializator.RatingCollection().Where(n => n.Reviewer == reviewerId).Count(o => o.Grade == specificGrade);
            return amountOfSpecificGradeByReviewer;
        }

        public int GetNumberOfMovieReviews(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public float GetAverageRatingOfMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfSpecificGradeGivenToMovie(int movieId, int specificGrade)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdOfMovieWithBiggestNumberOfTopGrade()
        {
            throw new System.NotImplementedException();
        }

        public int GetReviewerWithHighestAmountOfReviews()
        {
            throw new System.NotImplementedException();
        }

        public int GetSpecificAmountOfBestMovies(int amountOfMovies)
        {
            throw new System.NotImplementedException();
        }

        public int GetMoviesReviewedBySpecificReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public int GetMovieReviewers(int movieId)
        {
            throw new System.NotImplementedException();
        }

        private Stopwatch StartWatch()
        {
            return Stopwatch.StartNew();
        }

        private void StopWatchAndCheckTime(string methodName, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds / 1000;
            if (time > 4)
            {
                throw new TimeoutException();
            }
            Console.WriteLine(methodName + " took " + time + " seconds");
        }
    }
}