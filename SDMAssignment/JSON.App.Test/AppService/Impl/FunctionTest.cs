using System;
using System.Collections.Generic;
using System.IO;
using JSON.app;
using JSON.App.Core.DomainService;
using JSON.App.Infrastructure;
using Moq;
using Xunit;

namespace JSON.App.Test.AppService.Impl
{
    public class FunctionTest
    {
        [Fact]
        public void GetNumberOfReviewsByReviewerTest_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 1,
                    Date = "date",
                    Movie = 2
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 1,
                    Date = "date",
                    Movie = 2
                }
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetAmountOfReviewsByReviewer(1),2);            
        }

        [Fact]
        public void GetAverageRateOfReviewsByReviewerTest_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 1
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 3
                }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetAverageGradeOfReviewsByReviewer(1),2);
        }
        
        [Fact]
        public void GetNumberOfSpecificGradesByReviewer_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 1
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 3
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 3
                }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetAmountOfSpecificGradesByReviewer(3,1),2);
        }
        
        [Fact]
        public void GetNumberOfMovieReviews_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Movie = 2
                    
                },
                new Rating()
                {
                    Reviewer = 2,
                    Movie = 1
                   
                },
                new Rating()
                {
                    Reviewer = 3,
                    Movie = 1
                }
    
            });            
            var TestedClass = new Function(dataSource.Object);

            Assert.Equal(TestedClass.GetAmountOfMovieReviews(1),2);
        }
        
        [Fact]
        public void GetAverageRatingOfMovie_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Movie = 1,
                    Grade = 5
                    
                },
                new Rating()
                {
                    Reviewer = 2,
                    Movie = 1,
                    Grade = 2
                   
                },
                new Rating()
                {
                    Reviewer = 3,
                    Movie = 1,
                    Grade = 2                   
                }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetAverageRatingOfMovie(1),3);
        }
        
        [Fact]
        public void GetNumberOfSpecificGradeGivenToMovie_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Movie = 1,
                    Grade = 5
                    
                },
                new Rating()
                {
                    Reviewer = 2,
                    Movie = 1,
                    Grade = 2
                   
                },
                new Rating()
                {
                    Reviewer = 3,
                    Movie = 1,
                    Grade = 2                   
                }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetTotalAmountOfSpecificGradeGivenToMovie(1,2),2);
        }
        
        [Fact]
        public void GetIdOfMovieWithBiggestNumberOfTopGrade_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 1,
                    Movie = 3,
                    Grade = 5
                    
                },
                new Rating()
                {
                    Reviewer = 2,
                    Movie = 3,
                    Grade = 5
                   
                },
                new Rating()
                {
                    Reviewer = 7,
                    Movie = 2,
                    Grade = 5                 
                },
                new Rating()
                {
                Reviewer = 9,
                Movie = 2,
                Grade = 5                
            },
                new Rating()
                {
                Reviewer = 5,
                Movie = 2,
                Grade = 5                
            }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetIdOfMovieWithHighestAmountOfTopGrade(),2);
        }
        
        [Fact]
        public void GetReviewerWithHighestAmountOfReviews_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 1
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 3
                },
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 3
                }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetReviewerWithHighestAmountOfReviews(),2);
        }
        
        [Fact]
        public void GetSpecificAmountOfBestMovies_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 1,
                    Movie = 3,
                    Date = "2004-08-12"
                },
                new Rating()
                {
                    Reviewer = 1,
                    Grade = 4,
                    Movie = 5,
                    Date = "2004-10-12"
                },
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 4,
                    Movie = 3,
                    Date = "2005-05-12"
                },
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 3,
                    Movie = 2,
                    Date = "2005-05-12"
                }    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetSpecificAmountOfBestMovies(2),new List<int>(){5,2});
        }
        
        [Fact]
        public void GetMoviesReviewedBySpecificReviewer_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 2,
                    Movie = 3,
                    Date = "2004-08-12"
                },
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 2,
                    Movie = 5,
                    Date = "2005-05-12"
                },
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 5,
                    Movie = 8,
                    Date = "2005-05-12"
                }
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetMoviesReviewedBySpecificReviewer(2),new List<int>(){8,5,3});
        }
        
        [Fact]
        public void GetMovieReviewers_ReturnValues()
        {
            var dataSource = new Mock<IDeserializator>();
                            
            dataSource.Setup(m => m.RatingCollection()).Returns(new List<Rating>()
            {
                new Rating()
                {
                    Reviewer = 2,
                    Grade = 2,
                    Movie = 3,
                    Date = "2005-05-12"
                },
                new Rating()
                {
                    Reviewer = 4,
                    Grade = 2,
                    Movie = 7,
                    Date = "2004-08-12"
                },
                new Rating()
                {
                    Reviewer = 3,
                    Grade = 2,
                    Movie = 7,
                    Date = "2005-05-12"
                },
                new Rating()
                {
                    Reviewer = 5,
                    Grade = 5,
                    Movie = 7,
                    Date = "2005-05-12"
                }
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetMovieReviewers(7),new List<int>(){5,3,4});
        }
    }
}