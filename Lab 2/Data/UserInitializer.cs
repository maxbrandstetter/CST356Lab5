using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lab_2.Models;

namespace Lab_2.Data
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User{FirstName="John",LastName="Doe",EmailAddress="johndoe@email.com",NumberOfSiblings="2"},
                new User{FirstName="Mary",LastName="Sue",EmailAddress="marysue@email.com",NumberOfSiblings="5"}
            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();
        }
    }
}