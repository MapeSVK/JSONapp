using System;
using System.Diagnostics;
using System.Xml.Xsl;
using JSON.app;
using JSON.App.Core.DomainService;
using JSON.App.Infrastructure;

namespace PerformanceTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Reading JSON file");
            var stopwatch = Stopwatch.StartNew();
            IFunction function = new Function(new Deserializator());
            stopwatch.Stop();
            Console.WriteLine($"reading JSON file took: {stopwatch.ElapsedMilliseconds / 1000}");
            
            function.GetAmountOfReviewsByReviewer(1);
            function.GetAverageGradeOfReviewsByReviewer(4);
            function.GetAmountOfSpecificGradesByReviewer(3, 7);
            function.GetAmountOfMovieReviews(372233);
            function.GetAverageRatingOfMovie(1227322);
            function.GetTotalAmountOfSpecificGradeGivenToMovie(808731, 4);
            function.GetIdOfMovieWithHighestAmountOfTopGrade();
            function.GetReviewerWithHighestAmountOfReviews();
            function.GetSpecificAmountOfBestMovies(3);
            function.GetMoviesReviewedBySpecificReviewer(5);
            function.GetMovieReviewers(893988);
        }
    }
}