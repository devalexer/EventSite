namespace EventSite.Migrations
{
    using EventSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventSite.Models.ApplicationDbContext context)
        {
            var ownerRole = "owner";
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == ownerRole))
            {
                var role = new IdentityRole { Name = ownerRole };
                manager.Create(role);
            }


            var ownerEmail = "owner@events.com";
            var defaultPassword = "Password1!";
            if (!context.Users.Any(u => u.UserName == ownerEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = ownerEmail };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, ownerRole);
            }

            var concert = new GenreModel { Name = "Concert" };
            var rally = new GenreModel { Name = "Rally" };
            var dance = new GenreModel { Name = "Dance" };
            var fundraiser = new GenreModel { Name = "Fundraiser" };
            context.Genres.AddOrUpdate(g => g.Name, concert);

            var janus = new VenueModel { Name = "Janus" };
            var church = new VenueModel { Name = "Church" };
            var beach = new VenueModel { Name = "Beach" };
            var palladium = new VenueModel { Name = "Palladium" };
            context.Venues.AddOrUpdate(v => v.Name, janus);
            context.SaveChanges();

        }
    }
}
