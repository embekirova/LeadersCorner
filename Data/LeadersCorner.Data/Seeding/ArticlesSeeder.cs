namespace LeadersCorner.Data.Seeding
{
    using LeadersCorner.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ArticlesSeeder : ISeeder
    {
        public string Name { get; private set; }

        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Articles.Any())
            {
                return;
            }


            await dbContext.AddAsync(new Article
            {
                Title = "What Is Leadership?",
                ArticleContent = "Leadership is both a research area, " +
                "and a practical skill encompassing the ability of an individual, " +
                "group or organization to \" lead \"," +
                "influence or guide other individuals, teams, or entire organizations.",
                ImageUrl = "https://images.unsplash.com/photo-1541844053589-346841d0b34c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8bGVhZGVyc2hpcHxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "WorkAthmosphere")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "The most important part of Time Management",
                ArticleContent = "Time management is the process of planning and exercising " +
                "conscious control of time spent on specific activities, especially to increase " +
                "effectiveness, efficiency, and productivity. It involves a juggling act of " +
                "various demands upon a person relating to work, social life, family, hobbies, " +
                "personal interests, and commitments with the finiteness of time. Using time " +
                "effectively gives the person \"choice\" on spending or " +
                "managing activities at their own time and expediency. " +
                "Time management may be aided by a range of skills, tools, " +
                "and techniques used to manage time when accomplishing specific " +
                "tasks, projects, and goals complying with a due date. Initially, " +
                "time management referred to just business or work activities, but eventually, the term broadened to include personal activities as well. A time management system is a designed combination " +
                "of processes, tools, techniques, and methods. ",
                ImageUrl = "https://images.unsplash.com/photo-1553034545-32d4cd2168f1?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dGltZSUyMG1hbmFnZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TimeManagement")
                .Select(c => c.Id)
                .FirstOrDefault(),

            });
            await dbContext.AddAsync(new Article
            {
                Title = "Bad apples",
                ArticleContent = "Like it or not, every team has one (or more). " +
                "The worst thing an organization can do with an asshole is to ignore them.",
                ImageUrl = "https://images.unsplash.com/photo-1542014740373-51ad6425eb7c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YmFkJTIwYXBwbGV8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "Recruiting")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "What is problem solving",
                ArticleContent = "Problem solving consists of using generic or ad hoc methods in an orderly manner to find solutions to problems. " +
                "Some of the problem-solving techniques developed and used in philosophy, " +
                "artificial intelligence, computer science, engineering, mathematics, medicine and societies in general " +
                "are related to mental problem-solving techniques studied in psychology and cognitive sciences.",
                ImageUrl = "https://images.unsplash.com/photo-1587093336587-eeca6cb17cf2?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvYmxlbSUyMHNvbHZlcnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "ProblemSolving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "How to solve a problem",
                ArticleContent = "The first thing to do is to define the problem by itself. Once you figured out the real reason of describing the situation as problem, you are one step awa from solving it",
                ImageUrl = "https://images.unsplash.com/photo-1627453999407-f9dc86eddd09?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTl8fHByb2JsZW0lMjBzb2x2ZXJ8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "ProblemSolving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Solved one problem but arised a new",
                ArticleContent = "Have you ever been in that ridiculous situation of solving a problem and at that very second you realize the new one that you have brought up...",
                ImageUrl = "https://images.unsplash.com/photo-1506702315536-dd8b83e2dcf9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8d3JvbmclMjB3YXl8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "ProblemSolving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "How to talk about problem",
                ArticleContent = "Common barriers to problem solving are mental constructs that impede our ability to correctly solve problems. These barriers prevent people from solving problems in the most " +
                "efficient manner possible. Five of the most common processes and factors that researchers have identified as barriers to problem solving are confirmation bias, mental set, functional fixedness, " +
                "unnecessary constraints, and irrelevant information.",
                ImageUrl = "https://images.unsplash.com/photo-1619785699068-c8225c74ae46?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dGFsayUyMHByb2JsZW18ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "ProblemSolving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "How to motivate?",
                ArticleContent = "Motivation is what explains why people or animals initiate, continue or terminate a certain behavior at a particular time. Motivational states are commonly understood as forces acting within the " +
                "agent that create a disposition to engage in goal-directed behavior. It is often held that different mental states compete with each other and that only the strongest state determines behavior.[1] This means that we " +
                "can be motivated to do something without actually doing it.The paradigmatic mental state providing motivation is desire. But various other states, " +
                "like beliefs about what one ought to do or intentions, may also provide motivation.",
                ImageUrl = "https://images.unsplash.com/photo-1504805572947-34fad45aed93?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8bW90aXZhdGV8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 3,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TeamMotivation")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Recruiting?",
                ArticleContent = "Recruitment refers to the overall process of identifying, attracting, screening, shortlisting, and interviewing suitable candidates for jobs (either permanent or temporary) within an organization. " +
                "Recruitment can also refer to processes involved in choosing individuals for unpaid roles. Managers, human resource generalists and recruitment specialists may be tasked with carrying out recruitment, but in some cases " +
                "public-sector employment, commercial recruitment agencies, or specialist search consultancies are used to undertake parts of the process. Internet-based technologies which support all aspects of recruitment have become " +
                "widespread, including the use of artificial intelligence ",
                ImageUrl = "https://images.unsplash.com/photo-1487528278747-ba99ed528ebc?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8am9iJTIwaW50ZXJ2aWV3fGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 3,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "Recruiting")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "My first job interview?",
                ArticleContent = "The first thing to do for your first job interview is to take a look at the company ypur are applying at...",
                ImageUrl = "https://images.unsplash.com/photo-1483058712412-4245e9b90334?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mzl8fGludGVydmlld3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                AuthorId = 3,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "Recruiting")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "5 most common job inteview questions",
                ArticleContent = "The Most Common Interview Questions are: \"Tell Me About Yourself\", \"Did You Hear About This Position ?\", \"Why Do You Want This Job?\", \"Why Should We Hire You?\", \"What Can You Bring to the Company?\"",
                ImageUrl = "https://images.unsplash.com/photo-1483058712412-4245e9b90334?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mzl8fGludGVydmlld3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "Recruiting")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Self-employment",
                ArticleContent = "When an individual entirely owns the business for which they labor, this is known as self - employment.Self - employment often leads to incorporation.Incorporation offers certain protections of one's " +
                "personal assets. Individuals who are self-employed may own a small business. They may also be considered to be an entrepreneur.",
                ImageUrl = "https://images.unsplash.com/photo-1489533119213-66a5cd877091?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8c2VsZnxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "SelfImproving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Time efficiency",
                ArticleContent = "Efficiency is the (often measurable) ability to avoid wasting materials, energy, efforts, money, and time in doing something or in producing a desired result. In a more " +
                "general sense, it is the ability to do things well, successfully, and without waste",
                ImageUrl = "https://images.unsplash.com/photo-1553034545-32d4cd2168f1?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dGltZSUyMG1hbmFnZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TimeManagement")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "4 D's for better time management",
                ArticleContent = "The 4 Ds are: Do, Defer (Delay), Delegate, and Delete (Drop). Placing a task or project into one of these categories helps you manage your limited time more effectively and stay focused on what matters most to you.",
                ImageUrl = "https://images.unsplash.com/photo-1610072947120-8736bbfc56e1?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8NCUyMGRvZXN8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TimeManagement")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Occupational stress",
                ArticleContent = "Occupational stress is psychological stress related to one's job. Occupational stress refers to a chronic condition. Occupational stress can be managed by understanding " +
                "what the stressful conditions at work are and taking steps to remediate those conditions.[",
                ImageUrl = "https://images.unsplash.com/photo-1586473219010-2ffc57b0d282?ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8c3RyZXNzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "WorkAthmosphere")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Long hours - the reason for burnout",
                ArticleContent = "Although the importance of individual differences cannot be ignored, scientific evidence suggests that certain working conditions are stressful to most people. ",
                ImageUrl = "https://images.unsplash.com/photo-1508962914676-134849a727f0?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8aG91cnN8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TimeManagement")
                .Select(c => c.Id)
                .FirstOrDefault()
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Work–life balance",
                ArticleContent = "Work–life balance refers to the extent to which there is equilibrium between work demands and one's personal life outside of work. Workers face increasing challenges " +
                "to meeting workplace demands and fulfilling their family roles as well as other roles outside of work.",
                ImageUrl = "https://images.unsplash.com/photo-1536816579748-4ecb3f03d72a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8YmFsYW5jZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "SelfImproving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.AddAsync(new Article
            {
                Title = "Job satisfaction",
                ArticleContent = "Job satisfaction or employee satisfaction is a measure of workers' contentedness with their job, whether they like the job or individual aspects or facets of jobs, such as nature of work or supervision.",
                ImageUrl = "https://images.unsplash.com/photo-1509490927285-34bd4d057c88?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGJhbGFuY2V8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 3,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "SelfImproving")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
            await dbContext.SaveChangesAsync();
        }

    }
}
