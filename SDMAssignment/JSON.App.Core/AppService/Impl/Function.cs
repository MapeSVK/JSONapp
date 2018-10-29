using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JSON.App.Core.DomainService;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;

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
	        var stopwatch = StartWatch();
            var sumOfReviewersGrades = _deserializator.RatingCollection().Where(n => n.Reviewer == reviewerId).Sum(o => o.Grade);
	        StopWatchAndCheckTime("GetAverageGradeOfReviewsByReviewer", stopwatch);
            return sumOfReviewersGrades/GetAmountOfReviewsByReviewer(reviewerId);
        }

        public int GetAmountOfSpecificGradesByReviewer(int specificGrade, int reviewerId)
        {
	        var stopwatch = StartWatch();
            var amountOfSpecificGradeByReviewer =  _deserializator.RatingCollection()
	            .Where(n => n.Reviewer == reviewerId).Count(o => o.Grade == specificGrade);
	        StopWatchAndCheckTime("GetAmountOfSpecificGradesByReviewer", stopwatch);
            return amountOfSpecificGradeByReviewer;
        }

        public int GetAmountOfMovieReviews(int movieId)
        {
	        var stopwatch = StartWatch();
            var amountOfReviews = _deserializator.RatingCollection().Count(n => n.Movie == movieId);
	        StopWatchAndCheckTime("GetAmountOfMovieReviews", stopwatch);
            return amountOfReviews;
        }

        public float GetAverageRatingOfMovie(int movieId)
        {
	        var stopwatch = StartWatch();
            var averageRating = _deserializator.RatingCollection().Where(n => n.Movie == movieId).Sum(o => o.Grade);
	        StopWatchAndCheckTime("GetAverageRatingOfMovie", stopwatch);
            return averageRating / GetAmountOfMovieReviews(movieId);
        }

        public int GetTotalAmountOfSpecificGradeGivenToMovie(int movieId, int specificGrade)
        {
	        var stopwatch = StartWatch();
            var amountOfSpecificGrade = _deserializator.RatingCollection().Where(n => n.Movie == movieId)
                .Count(o => o.Grade == specificGrade);
	        StopWatchAndCheckTime("GetTotalAmountOfSpecificGradeGivenToMovie", stopwatch);
            return amountOfSpecificGrade;
        }

        public int GetIdOfMovieWithHighestAmountOfTopGrade()
        {
	        var stopwatch = StartWatch();
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
	        StopWatchAndCheckTime("GetIdOfMovieWithHighestAmountOfTopGrade", stopwatch);
            return movieId;
        }

        public int GetReviewerWithHighestAmountOfReviews()
        {
	        var stopwatch = StartWatch();
	        var result = _deserializator.RatingCollection().GroupBy(id => id.Reviewer)
		        .Select(group => new
		        {
			        Key = group.Key, // key is reviewerId
			        Count = group.Count() // count represents amount of reviews inside of one group (one reviewer)
		        }).OrderByDescending(x => x.Count).FirstOrDefault();

	        StopWatchAndCheckTime("GetReviewerWithHighestAmountOfReviews", stopwatch);
	        return result.Key;

        }

        public List<int> GetSpecificAmountOfBestMovies(int amountOfMovies)
        {
	       
	        /*
	         * 1. Group reviews by movieIds
	         * 2. Get their ids and average grade
	         * 3. Order all movies descending by their grade
	         * 4. Get specific amount of them by writing .take(parameter)
	         * 5. With foreach loop go through all results and get ONLY their ids (keys)
	         * 6. Add them to the new list and return that list
	         */
	        var stopwatch = StartWatch();
	        var moviesAndAverageGradeSortedList = _deserializator.RatingCollection().GroupBy(movieId => movieId.Movie)
		        .Select(group => new
		        {
			        Key = group.Key, // Key is movieId
			        Average = group.Average(g => g.Grade)
		        })
		        .OrderByDescending(a => a.Average)
		        .Take(amountOfMovies)
		        .ToList();
	        
	        var moviesSortedList = new List<int>();

	        foreach (var movie in moviesAndAverageGradeSortedList)
	        {
		        var key = movie.Key;
		        moviesSortedList.Add(key);
	        }

	        
	        StopWatchAndCheckTime("GetSpecificAmountOfBestMovies", stopwatch);
	        return moviesSortedList;

        }

        public List<int> GetMoviesReviewedBySpecificReviewer(int reviewerId)
        {
	        var stopwatch = StartWatch();
	        var result = _deserializator.RatingCollection()
		        .Where(x => x.Reviewer == reviewerId)
		        .OrderByDescending(x => x.Grade)
		        .ThenByDescending(x => x.Date)
		        .Select(x => x.Movie).ToList();	
			
	        StopWatchAndCheckTime("GetMoviesReviewedBySpecificReviewer", stopwatch);
	        return result;
        }

        public List<int> GetMovieReviewers(int movieId)
        {
	        var stopwatch = StartWatch();
	        var result = _deserializator.RatingCollection()
		        .Where(x => x.Movie == movieId)
		        .OrderByDescending(x => x.Grade)
		        .ThenByDescending(x => x.Date)
		        .Select(x => x.Reviewer).ToList();	
			
	        StopWatchAndCheckTime("GetMovieReviewers", stopwatch);
	        return result;
        }
	    
	    
	    
	    // starts the watch to observe time spent on particular method's execution
        private Stopwatch StartWatch()
        {
            return Stopwatch.StartNew();
        }
	    
		// stop the watch and print out name of the method and time spent on execution
	    // Throws an exception if time is more than 4 seconds.
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