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
                    Reviewer = 3,
                    Movie = 2,
                    Grade = 5                 
                },
                new Rating()
                {
                Reviewer = 3,
                Movie = 2,
                Grade = 2                 
            }
    
            });            
            var testedClass = new Function(dataSource.Object);

            Assert.Equal(testedClass.GetIdOfMovieWithBiggestNumberOfTopGrade(),3);
        }
    }
}