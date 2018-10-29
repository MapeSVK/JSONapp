using System.Collections.Generic;
using System.Reflection;

namespace JSON.app
{
    public interface IFunction
    {
        // returns the amount of all reviews made by the reviewer
        int GetAmountOfReviewsByReviewer(int reviewerId);

        // returns the average of the grades made by reviewer
        float GetAverageGradeOfReviewsByReviewer(int reviewerId);

        // returns the total amount of specific grade made by the reviewer
        int GetAmountOfSpecificGradesByReviewer(int specificGrade, int reviewerId);

        // returns the total amount of all reviews of specific movie
        int GetAmountOfMovieReviews(int movieId);

        // returns the average rating of the movie
        float GetAverageRatingOfMovie(int movieId);

        // returns the total amount of specific grade given to movie
        int GetTotalAmountOfSpecificGradeGivenToMovie(int movieId, int specificGrade);

        // returns id of the movie with the biggest number of the best (top) grade - 5
        int GetIdOfMovieWithBiggestNumberOfTopGrade();

        // returns the reviewer who has highest amount of the reviews
        int GetReviewerWithHighestAmountOfReviews();

        // returns the amount of the movies specified in the parameter
        List<int> GetSpecificAmountOfBestMovies(int amountOfMovies);

        // returns all movies reviewed by the specific reviewer specified by id as a parameter
        List<int> GetMoviesReviewedBySpecificReviewer(int reviewerId);

        // returns all reviewers (ids) who reviewed the movie
        List<int> GetMovieReviewers(int movieId);
    }
}