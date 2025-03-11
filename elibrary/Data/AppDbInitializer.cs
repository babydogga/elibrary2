using elibrary.Data.Enums;
using elibrary.Models;

namespace elibrary.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //biblioteka
                if (!context.Biblioteki.Any())
                {
                    context.Biblioteki.AddRange(new List<Biblioteka>()
                        {
                       new Biblioteka()
                       {
                           NameBib = "Biblioteka Jagiellonska",
                           LogoBib = "https://www.mabpz.org/media/zoo/images/Biblioteka-Jagiellonska_Logo-01_a64373b7a6f7b26c34d81314be9942bd.png",
                           DescBib = "To jest opis dla Biblioteki Jagiellonskiej"
                       },

                       new Biblioteka()
                       {
                           NameBib = "Biblioteka na rajskiej",
                           LogoBib = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ6Z9YzhoSSAjExaUuQWyJ7UcDCd7MR_HsAg&s",
                           DescBib = "To jest opis dla biblioteki na rajskiej"
                       },

                       new Biblioteka()
                       {
                           NameBib = "Biblioteka Ignatianum",
                           LogoBib = "https://fundacjaignatianum.pl/wp-content/uploads/2013/04/akademia_ignatianum_logo-300x228.png",
                           DescBib = "To jest opis dla Biblioteki Ignatianum"
                       },

                       new Biblioteka()
                       {
                           NameBib = "Biblioteka Uniwersytetu Pegadogicznego",
                           LogoBib = "https://bg.up.krakow.pl/wp-content/uploads/2017/02/logobgup_-_burgund-300x300.png",
                           DescBib = "To jest opis dla biblioteki Uniwersytetu Pedagogicznego"
                       },

                       new Biblioteka()
                       {
                           NameBib = "Biblioteka AWF",
                           LogoBib = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThJjaeri3v6DOb32iIrCY8qBgXi5NCGI5Dyw&s",
                           DescBib = "To jest opis dla Biblioteki AWF"
                       }

                    });
                    context.SaveChanges();
                }
                //autors
                if (!context.Autorzy.Any())
                {
                    context.Autorzy.AddRange(new List<Autor>()
                    {
                        new Autor()
                        {
                            Id = 1,
                            FullName = "JRR Tolkien",
                            Bio = "To jest opis dla JRR Tolkiena",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/J._R._R._Tolkien%2C_ca._1925.jpg/1024px-J._R._R._Tolkien%2C_ca._1925.jpg"
                        },

                        new Autor()
                        {
                            Id = 2, 
                            FullName = "CS Levis",
                            Bio = "To jest opis dla CS Levis",
                            ProfilePictureURL = "https://cdn.britannica.com/24/82724-050-A1F9D0B9/CS-Lewis.jpg"
                        },

                        new Autor()
                        {
                            Id = 3, 
                            FullName = "Marcin Najman",
                            Bio = "To jest opis dla Marcin Najman",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/0/03/Marcin_Najman_..._%2840313247093%29_%28cropped%29.jpg"
                       }

                    });
                    context.SaveChanges();
                }
                //wydawnictwo
                if (!context.Wydawnictwa.Any())
                {
                    context.Wydawnictwa.AddRange(new List<Wydawnictwo>()
                        {
                            new Wydawnictwo()
                            {
                                Id = 1,
                                NameWyd = "Wydawnictwo Uniwersytetu Jagiellonskiego",
                                DescWyd = "To jest Wydawnictwo Uniwersytetu Jagiellonskiego",
                                WydPictureURL = "https://a.allegroimg.com/original/1271ea/7818254f452490344fe22596a489"
                            },

                            new Wydawnictwo()
                            {
                                Id = 2,
                                NameWyd = "Wydawnictwo UAM",
                                DescWyd = "To jest Wydawnictwo UAM",
                                WydPictureURL = "https://amu.edu.pl/__data/assets/image/0017/15803/wydawnictwo-naukowe-uam.PNG"
                            },

                            new Wydawnictwo()
                            {
                                Id = 3,
                                NameWyd = "Wydawnictwo Krzak",
                                DescWyd = "To jest Wydawnictwo Krzak",
                                WydPictureURL = "https://pracownia52.pl/www/wp-content/uploads/2018/05/krzak-jarocin-001-mn.jpg"
                            }


                    });
                    context.SaveChanges();
                }
                //ksaizki
                if (!context.Ksiazki.Any())
                {
                    context.Ksiazki.AddRange(new List<Ksiazka>()
                        {
                            new Ksiazka()
                            {
                                Id = 1,
                                NameKs = "Silmarillion",
                                DescKs = "Oto najnowasza ksiazka JRR Tolkiena, Silmarillion!",
                                ImageURL = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1610045590i/7332.jpg",
                                PublikacjaTime = DateTime.Now.AddDays(-11),
                                WydId = 1,
                                BibId = 1,
                                ksiazkaCategory = KsiazkaCategory.Fabularna
                            },

                            new Ksiazka()
                            {
                                Id = 2,
                                NameKs = "Opowiesci z Narnii",
                                DescKs = "Oto najnowasza ksiazka CS Levisa, Opowiesci z Narnii!",
                                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Chronicles_narnia_lion_witch_logo.png",
                                PublikacjaTime = DateTime.Now.AddDays(-11),
                                WydId = 1,
                                BibId = 2,
                                ksiazkaCategory = KsiazkaCategory.SciFi
                            },

                            new Ksiazka()
                            {
                                Id = 3,
                                NameKs = "Ojciec chrzestny polskich Freak Fightów",
                                DescKs = "Oto najnowasza ksiazka Marcina Najmana, Ojciec chrzestny polskich Freak Fightów!",
                                ImageURL = "https://skrypt.com.pl/wp-content/uploads/2024/01/1-1-24.jpg",
                                PublikacjaTime = DateTime.Now.AddDays(-11),
                                WydId = 1,
                                BibId = 3,
                                ksiazkaCategory = KsiazkaCategory.Fantazy
                            }

                    });
                    context.SaveChanges();
                }
                //bib&ksiazki
                if (!context.Autor_Ksiazki.Any())
                {
                    context.Autor_Ksiazki.AddRange(new List<Autor_Ksiazka>()
                        {
                            new Autor_Ksiazka()
                            {
                                KsiazkaId = 1,
                                AutorId = 1,
                            },
                            new Autor_Ksiazka()
                            {
                                KsiazkaId = 1,
                                AutorId = 2,
                            },
                            new Autor_Ksiazka()
                            {
                                KsiazkaId = 1,
                                AutorId = 3,
                            },

                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
