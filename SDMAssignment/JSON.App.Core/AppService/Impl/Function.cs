using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JSON.App.Core.DomainService;
using System.Linq;
using System.Runtime.InteropServices;

namespace JSON.app
{
    public class Function: IFunction
    {
        private readonly IDeserializator _deserializator;
        
        public Function(IDeserializator deserializator)
        {
            _deserializator = deserializator;
        }
        public int GetAmountOfReviewsByReviewer(int reviewerId)
        {
            var stopwatch = StartWatch();
            var numberOfReviews = _deserializator.RatingCollection().Count(n => n.Reviewer == reviewerId);
            StopWatchAndCheckTime("GetNumberOfReviewsByReviewer", stopwatch);
            return numberOfReviews;
        }

        public float GetAverageGradeOfReviewsByReviewer(int reviewerId)
        {
            var sumOfReviewersGrades = _deserializator.RatingCollection().Where(n => n.Reviewer == reviewerId).Sum(o => o.Grade);
            return sumOfReviewersGrades/GetAmountOfReviewsByReviewer(reviewerId);
        }

        public int GetAmountOfSpecificGradesByReviewer(int specificGrade, int reviewerId)
        {
            var amountOfSpecificGradeByReviewer =  _deserializator.RatingCollection().Where(n => n.Reviewer == reviewerId).Count(o => o.Grade == specificGrade);
            return amountOfSpecificGradeByReviewer;
        }

        public int GetAmountOfMovieReviews(int movieId)
        {
            var amountOfReviews = _deserializator.RatingCollection().Count(n => n.Movie == movieId);
            return amountOfReviews;
        }

        public float GetAverageRatingOfMovie(int movieId)
        {
            var averageRating = _deserializator.RatingCollection().Where(n => n.Movie == movieId).Sum(o => o.Grade);
            return averageRating / GetAmountOfMovieReviews(movieId);
        }

        public int GetTotalAmountOfSpecificGradeGivenToMovie(int movieId, int specificGrade)
        {
            var amountOfSpecificGrade = _deserializator.RatingCollection().Where(n => n.Movie == movieId)
                .Count(o => o.Grade == specificGrade);
            return amountOfSpecificGrade;
        }

        public int GetIdOfMovieWithBiggestNumberOfTopGrade()
        {
            var movieId = 0;
            var biggestAmountOfTopGrades = 0;
            foreach (var movie in _deserializator.RatingCollection().Where(g => g.Grade==5))
            {
                var ratingNumber = _deserializator.RatingCollection().Count(n => n.Movie == movie.Movie);
                if (ratingNumber > biggestAmountOfTopGrades)
                {
                    biggestAmountOfTopGrades = ratingNumber;
                    movieId = movie.Movie;
                }
            }
            return movieId;
        }

        public int GetReviewerWithHighestAmountOfReviews()
        {
           // var topReviewer = _deserializator.RatingCollection().GroupBy(Rating => Rating.Reviewer).Count()
            throw new System.NotImplementedException();
        }

        public List<int> GetSpecificAmountOfBestMovies(int amountOfMovies)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesReviewedBySpecificReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMovieReviewers(int movieId)
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