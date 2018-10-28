using System.Reflection;

namespace JSON.app
{
    public interface IFunction
    {
        // returns the number of all reviews made by the reviewer
        int GetNumberOfReviewsByReviewer(int reviewerId);

        // returns the average of the grades made by reviewer
        float GetAverageGradeOfReviewsByReviewer(int reviewerId);

        // returns the total number of specific grade made by the reviewer
        int GetNumberOfSpecificGradesByReviewer(int specificGrade, int reviewerId);

        // returns the total number of all reviews of specific movie
        int GetNumberOfMovieReviews(int movieId);

        // returns the average rating of the movie
        float GetAverageRatingOfMovie(int movieId);

        // returns the number of specific grade given to movie
        int GetNumberOfSpecificGradeGivenToMovie(int movieId, int specificGrade);

        // returns id of the movie with the biggest number of the best (top) grade - 5
        int GetIdOfMovieWithBiggestNumberOfTopGrade();

        // returns the reviewer who has highest amount of the reviews
        int GetReviewerWithHighestAmountOfReviews();

        // returns the amount of the movies specified in the parameter
        int GetSpecificAmountOfBestMovies(int amountOfMovies);

        // returns all movies reviewed by the specific reviewer specified by id as a parameter
        int GetMoviesReviewedBySpecificReviewer(int reviewerId);

        // returns all reviewers (ids) who reviewed the movie
        int GetMovieReviewers(int movieId);
    }
}