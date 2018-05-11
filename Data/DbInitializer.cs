using MangaSearch.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace MangaSearch.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Mangas.Any())
            {
                context.AddRange
                (
                    new Manga
                    {
                        Name = "Naruto Volume 1",
                        Price = 10.00M,
                        ShortDescription = "Naruto, Vol. 1: Uzumaki Naruto ",
                        LongDescription = "Twelve years ago the Village Hidden in the Leaves was attacked by a fearsome threat. A nine-tailed fox spirit claimed the life of the village leader, the Hokage, and many others. Today, the village is at peace and a troublemaking kid named Naruto is struggling to graduate from Ninja Academy. His goal may be to become the next Hokage, but his true destiny will be much more complicated. The adventure begins now!",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61blY%2BDiS4L.jpg",
                        InStock = true,
                        IsPreferredManga = true,
                        ImageThumbnailUrl = "https://images-na.ssl-images-amazon.com/images/I/61blY%2BDiS4L.jpg"
                    },
                    new Manga
                    {
                        Name = "Naruto Volume 1",
                        Price = 10.00M,
                        ShortDescription = "Bleach, Vol. 1: Strawberry and the Soul Reapers",
                        LongDescription = "Ichigo Kurosaki has always been able to see ghosts, but this ability doesn't change his life nearly as much as his close encounter with Rukia Kuchiki, a Soul Reaper and member of the mysterious Soul Society. While fighting a Hollow, an evil spirit that preys on humans who display psychic energy, Rukia attempts to lend Ichigo some of her powers so that he can save his family; but much to her surprise, Ichigo absorbs every last drop of her energy. Now a full-fledged Soul Reaper himself, Ichigo quickly learns that the world he inhabits is one full of dangerous spirits and, along with Rukia--who is slowly regaining her powers--it's Ichigo's job to protect the innocent from Hollows and help the spirits themselves find peace.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51FEKMNJTbL._SY346_.jpg",
                        InStock = true,
                        IsPreferredManga = true,
                        ImageThumbnailUrl = "https://images-na.ssl-images-amazon.com/images/I/51FEKMNJTbL._SY346_.jpg"
                    },
                    new Manga
                    {
                        Name = "One Piece Volume 1",
                        Price = 10.00M,
                        ShortDescription = "One Piece, Vol. 1: Romance Dawn",
                        LongDescription = "As a child, Monkey D. Luffy was inspired to become a pirate by listening to the tales of the buccaneer "Red - Haired" Shanks. But his life changed when Luffy accidentally ate the Gum-Gum Devil Fruit and gained the power to stretch like rubber...at the cost of never being able to swim again! Years later, still vowing to become the king of the pirates, Luffy sets out on his adventure...one guy alone in a rowboat, in search of the legendary "One Piece,
                        " said to be the greatest treasure in the world...",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61MxIOS2GVL._SY346_.jpg",
                        InStock = true,
                        IsPreferredManga = true,
                        ImageThumbnailUrl = "https://images-na.ssl-images-amazon.com/images/I/61MxIOS2GVL._SY346_.jpg"
                    },
                    new Manga
                    {
                        Name = "Silent Voice",
                        Price = 10.00M,
                        ShortDescription = "Naturally contained in fruit or vegetable tissue.",
                        LongDescription = "Shoya is a bully. When Shoko, a girl who can't hear, enters his elementary school class, she becomes their favorite target, and Shoya and his friends goad each other into devising new tortures for her. But the children's cruelty goes too far. Shoko is forced to leave the school, and Shoya ends up shouldering all the blame. Six years later, the two meet again. Can Shoya make up for his past mistakes, or is it too late? Read the manga industry insiders voted their favorite of 2014!",
                        Category = _categoryRepository.Categories.Last(),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61leF3kduEL.jpg",
                        InStock = true,
                        IsPreferredManga = false,
                        ImageThumbnailUrl = "https://images-na.ssl-images-amazon.com/images/I/61leF3kduEL.jpg"
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Discounted Ones", Description="All Discounted Ones Mangas." },
                        new Category { CategoryName = "General", Description="All General Mangas" }
                    };

                                                  categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
