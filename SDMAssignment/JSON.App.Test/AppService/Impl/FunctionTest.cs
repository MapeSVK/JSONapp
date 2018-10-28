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
            var testedClas = new Function(dataSource.Object);

            Assert.Equal(testedClas.GetNumberOfReviewsByReviewer(1),2);            
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
            var testedClas = new Function(dataSource.Object);

            Assert.Equal(testedClas.GetAverageGradeOfReviewsByReviewer(1),2);
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
            var testedClas = new Function(dataSource.Object);

            Assert.Equal(testedClas.GetNumberOfSpecificGradesByReviewer(3,1),2);
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
            var testedClas = new Function(dataSource.Object);

            Assert.Equal(testedClas.GetNumberOfMovieReviews(1),2);
        }
        
    }
}