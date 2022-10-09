using Microsoft.AspNetCore.Identity;
using MovieShop.Data.Enums;
using MovieShop.Data.Static;
using MovieShop.Models;
using System;
namespace MovieShop.Data
{
    public class ApplicationDbIntializer
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var service = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = service.ServiceProvider.GetService<ApplicationDbContext>();

                if (context != null)
                {
                    //Cinema
                    if (!context.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                        context.SaveChanges();
                    }
                    //Actors
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                        context.SaveChanges();
                    }
                    //Producers
                    //if (!context.Producers.Any())
                    //{
                    //    context.Producers.AddRange(new List<Producer>()
                    //{
                    //    new Producer()
                    //    {
                    //        FullName = "Producer 1",
                    //        Bio = "This is the Bio of the first actor",
                    //        ImageUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                    //    },
                    //    new Producer()
                    //    {
                    //        FullName = "Producer 2",
                    //        Bio = "This is the Bio of the second actor",
                    //        ImageUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                    //    },
                    //    new Producer()
                    //    {
                    //        FullName = "Producer 3",
                    //        Bio = "This is the Bio of the second actor",
                    //        ImageUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                    //    },
                    //    new Producer()
                    //    {
                    //        FullName = "Producer 4",
                    //        Bio = "This is the Bio of the second actor",
                    //        ImageUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                    //    },
                    //    new Producer()
                    //    {
                    //        FullName = "Producer 5",
                    //        Bio = "This is the Bio of the second actor",
                    //        ImageUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                    //    }
                    //});
                    //    context.SaveChanges();
                    //}
                    //Movies
                    if (!context.Movies.Any())
                    {
                        context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaID = 3,
                            Category = Category.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaID = 1,
                            Category = Category.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaID = 4,
                            Category = Category.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaID = 1,
                            Category = Category.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaID = 1,
                            Category = Category.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaID = 1,
                            Category = Category.Drama
                        }
                    });
                        context.SaveChanges();
                    }
                    //Actors & Movies
                    if (!context.MovieActors.Any())
                    {
                        context.MovieActors.AddRange(new List<MovieActor>()
                    {
                        new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 1
                        },
                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 1
                        },

                         new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 2
                        },
                         new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 2
                        },

                        new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 3
                        },
                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 3
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 3
                        },


                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 4
                        },
                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 4
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 4
                        },


                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 5
                        },
                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 5
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 5
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 5
                        },


                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 6
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 6
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 6
                        },
                    });
                        context.SaveChanges();
                    }
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole() { NormalizedName="R", Name = UserRoles.Admin});
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole() { NormalizedName = "R", Name = UserRoles.User});
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Name = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Songbien123@");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        Name = "Application User",
                        NormalizedUserName = "",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Songbien123@");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
