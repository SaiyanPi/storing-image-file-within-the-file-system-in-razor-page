using Microsoft.EntityFrameworkCore;
using UserImage.Models;

namespace UserImage.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            // Look for any users.
            if (context.Users.Any())
            {
                return; // Db has been seeded.
            }
            var users = new User[]
            {
                new User
                {
                    FirstName = "Roshan",
                    MiddleName = "",
                    LastName = "Karki",
                    Address = "Nepal, lalitpur",
                    Contact = "000000000",
                    DoB = DateTime.Parse("1996-05-02"),
                    ImageName = "roshan.jpg"
                },
                new User
                {
                    FirstName = "Pustam",
                    MiddleName = "Thapa",
                    LastName = "Magar",
                    Address = "Nepal, lalitpur",
                    Contact = "000000001",
                    DoB = DateTime.Parse("1996-04-02"),
                    ImageName = "pustam.jpg"
                },
                new User
                {
                    FirstName = "Sajan",
                    MiddleName = "",
                    LastName = "Thapa",
                    Address = "Nepal, lalitpur",
                    Contact = "000000002",
                    DoB = DateTime.Parse("1996-09-02"),
                    ImageName = "sajan.jpg"
                },
                 new User
                 {
                     FirstName = "Biren",
                     MiddleName = "",
                     LastName = "Maharjan",
                     Address = "Nepal, lalitpur",
                     Contact = "000000005",
                     DoB = DateTime.Parse("1996-01-02"),
                     ImageName = "brain.jpg"
                 },
                 new User
                 {
                     FirstName = "reetesh",
                     MiddleName = "",
                     LastName = "dolal",
                     Address = "Nepal, lalitpur",
                     Contact = "000000007",
                     DoB = DateTime.Parse("1996-05-22"),
                     ImageName = "ritesh.jpg"
                 }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

        }  
    }
}
