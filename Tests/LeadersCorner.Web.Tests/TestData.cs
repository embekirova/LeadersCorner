using LeadersCorner.Data.Models;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadersCorner.Web.Tests
{
    public class TestData
    {
        public static List<Article> GetArticles(int count)
        {
            var user = new 
            {
                Id = TestUser.Identifier,
                UserName = TestUser.Username
            };

            var comments = Enumerable
                .Range(1, count)
                .Select(i => new Comment
                {
                    Id = i,
                    CommentContent = $"Comments Content is too large {i}",
                    }
                ).ToList();


            var articles = Enumerable
                .Range(1, count)
                .Select(i => new Article
                {
                    Id = i,
                    Title = $"Article Number {i}",
                    ArticleContent = $"Article Content is too large {i}",
                    AuthorId = i,
                    Author = new Author
                    {
                        Id = i,
                        FirstName = $"Author {i}"
                    },
                    Comments = comments,
                })
                .ToList();

            return articles;
        }
        public static List<Course> GetCourse(int count)
        {
            var user = new
            {
                Id = TestUser.Identifier,
                UserName = TestUser.Username
            };

            var comments = Enumerable
                .Range(1, count)
                .Select(i => new Comment
                {
                    Id = i,
                    CommentContent = $"Comments Content is too large {i}",
                }
                ).ToList();


            var courses = Enumerable
                .Range(1, count)
                .Select(i => new Course
                {
                    Id = i,
                    Title = $"Course Number {i}",
                    CourseContent = $"Course Content is too large {i}",
                    AuthorId = i,
                    DurationInWeeks = i,
                    Author = new Author
                    {
                        Id = i,
                        FirstName = $"Author {i}"
                    },
                    Comments = comments,
                })
                .ToList();

            return courses;
        }
    }
}
