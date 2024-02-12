using CDN_WebAPI.Data;
using CDN_WebAPI.Models;

namespace CDN_WebAPI
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            this._context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.Users.Any())
            {
                var users = new List<UserModel>()
                {
                    new()
                    {
                        FirstName = "Alan",
                        LastName = "Walker",
                        Email = "AlanWalker@gmail.com",
                        PhoneNumber = 123
                    },
                    new()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "JohnDoe@gmail.com",
                        PhoneNumber = 135
                    },
                    new()
                    {
                        FirstName = "Thomas",
                        LastName = "Hamston",
                        Email = "ThomasHamston@gmail.com",
                        PhoneNumber = 496
                    }
                };

                _context.Users.AddRange(users);
            }

            if (!_context.SkillSet.Any())
            {
                var skillSets = new List<SkillSetModel>()
                {
                    new()
                    {
                        SkillSet = "C#",
                        UserId = 1
                    },
                    new()
                    {
                        SkillSet = ".NET",
                        UserId = 1
                    },
                    new()
                    {
                        SkillSet = "CSS",
                        UserId = 2
                    },
                    new()
                    {
                        SkillSet = "HTML",
                        UserId = 2
                    },
                    new()
                    {
                        SkillSet = "Javascript",
                        UserId = 2
                    },
                    new()
                    {
                        SkillSet = "Java",
                        UserId = 3
                    }
                };

                _context.SkillSet.AddRange(skillSets);
            }

            if (_context.Hobby.Any())
            {
                var hobbies = new List<HobbyModel>()
                {
                    new()
                    {
                        Hobby = "Eating",
                        UserId= 1
                    },
                    new()
                    {
                        Hobby = "Playing games",
                        UserId= 1
                    },
                    new()
                    {
                        Hobby = "Swimming",
                        UserId= 2
                    },
                    new()
                    {
                        Hobby = "Running",
                        UserId= 2
                    },
                    new()
                    {
                        Hobby = "Sleeping",
                        UserId= 2
                    },
                    new()
                    {
                        Hobby = "Cycling",
                        UserId= 3
                    },
                };

                _context.Hobby.AddRange(hobbies);
            }

            _context.SaveChanges();
        }
    }
}
