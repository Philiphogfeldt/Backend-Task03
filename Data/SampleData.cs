﻿using Backend_Task03.Models;
using System;

namespace Backend_Task03.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }

            database.SaveChanges();
        }
        public static void CreateBeer(AppDbContext database)
        {
            if (!database.Beers.Any())
            {
                var beers = new List<Beer>()
                {
                    new Beer
                    {
                        Name = "Hoppy McHopface",
                        Description = "A bold, hoppy brew with a crisp finish that will leave you feeling hoppily ever after.",
                        Type = "IPA",
                        Percentage = "6.5%",
                        Brewery = "Hoppy Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Lager than Life",
                        Description = "A smooth, refreshing lager that's bigger than life itself.",
                        Type = "Lager",
                        Percentage = "4.8%",
                        Brewery = "Big Brewery",
                        Country = "Canada"
                    },
                    new Beer
                    {
                        Name = "Witty Kolsch",
                        Description = "A clever and light-bodied Kolsch that's sure to put a smile on your face.",
                        Type = "Kolsch",
                        Percentage = "5.0%",
                        Brewery = "Wit Brewery",
                        Country = "Germany"
                    },
                    new Beer
                    {
                        Name = "Saison's Greetings",
                        Description = "A spicy, seasonal Saison that's perfect for the holidays.",
                        Type = "Saison",
                        Percentage = "6.2%",
                        Brewery = "Seasonal Brewery",
                        Country = "Belgium"
                    },
                    new Beer
                    {
                        Name = "Hazy Daze IPA",
                        Description = "A hazy, juicy IPA that will transport you to a lazy day on the beach.",
                        Type = "IPA",
                        Percentage = "6.8%",
                        Brewery = "Hazy Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Red Oktoberfest",
                        Description = "A rich, malty Oktoberfest brew with a deep red color and a smooth finish.",
                        Type = "Oktoberfest",
                        Percentage = "5.5%",
                        Brewery = "Red Brewery",
                        Country = "Germany"
                    },
                    new Beer
                    {
                        Name = "Imperial Stout of Mind",
                        Description = "A bold and complex Imperial Stout that will blow your mind.",
                        Type = "Imperial Stout",
                        Percentage = "10.0%",
                        Brewery = "Mind Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Belgian Waffle Ale",
                        Description = "A sweet and savory Belgian-style ale that tastes like breakfast in a bottle.",
                        Type = "Belgian Ale",
                        Percentage = "7.0%",
                        Brewery = "Waffle Brewery",
                        Country = "Belgium"
                    },
                    new Beer
                    {
                        Name = "Irish Goodbye Stout",
                        Description = "A smooth and creamy Irish-style stout that will make you want to say goodbye to your troubles.",
                        Type = "Stout",
                        Percentage = "5.2%",
                        Brewery = "Goodbye Brewery",
                        Country = "Ireland"
                    },
                    new Beer
                    {
                         Name = "Sourpuss Gose",
                        Description = "A tart and salty Gose that's perfect for those with a sourpuss attitude.",
                        Type = "Gose",
                        Percentage = "4.2%",
                        Brewery = "Sourpuss Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Funky Monkey Brown Ale",
                        Description = "A nutty and chocolatey brown ale with a funky twist.",
                        Type = "Brown Ale",
                        Percentage = "5.8%",
                        Brewery = "Funky Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Tropical Tripel",
                        Description = "A fruity and spicy Belgian Tripel with a tropical twist.",
                        Type = "Tripel",
                        Percentage = "9.5%",
                        Brewery = "Tropical Brewery",
                        Country = "Belgium"
                    },
                    new Beer
                    {
                        Name = "Java Stout",
                        Description = "A rich and roasty stout brewed with coffee beans for a java kick.",
                        Type = "Stout",
                        Percentage = "6.0%",
                        Brewery = "Java Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Cucumber Kolsch",
                        Description = "A light and refreshing Kolsch brewed with cucumber for a cool twist.",
                        Type = "Kolsch",
                        Percentage = "4.5%",
                        Brewery = "Cucumber Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Cherry Bomb Sour",
                        Description = "A tart and fruity sour brewed with cherries for a flavorful explosion.",
                        Type = "Sour",
                        Percentage = "5.0%",
                        Brewery = "Cherry Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Honey Wheat Ale",
                        Description = "A light and smooth wheat ale brewed with honey for a touch of sweetness.",
                        Type = "Wheat Ale",
                        Percentage = "4.2%",
                        Brewery = "Honey Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Gingerbread Stout",
                        Description = "A spiced and rich stout brewed with gingerbread for a holiday treat.",
                        Type = "Stout",
                        Percentage = "8.0%",
                        Brewery = "Gingerbread Brewery",
                        Country = "USA"
                    },
                    new Beer
                    {
                        Name = "Peanut Butter Porter",
                        Description = "A smooth and nutty porter brewed with peanut butter for a creamy finish.",
                        Type = "Porter",
                        Percentage = "6.5%",
                        Brewery = "Peanut Brewery",
                        Country = "USA" 
                    },
                    new Beer
                    {
                        Name = "Mango Habanero Wheat Ale",
                        Description = "A spicy and fruity wheat ale brewed with mango and habanero for a kick.",
                        Type = "Wheat Ale",
                        Percentage = "5.0%",
                        Brewery = "Mango Habanero Brewery",
                        Country = "USA"
                    },
                    
                };
                database.SaveChanges();
            }    
        }
    } 
}
