using KursProjectISP31.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Model
{
    public static class SeedData
    {
        public static void SeedDatabase(GgContext context)
        {
            context.Database.Migrate();
            if (context.Persons.Count() == 0)
            {
                Person user = new Person { Email = "22252225d@gmail.com", Password = "1111" };
                user.Password = AuthOptoins.GetHash(user.Password);
                context.Persons.Add(user);
                context.SaveChanges();
            }
        }
    }
}
