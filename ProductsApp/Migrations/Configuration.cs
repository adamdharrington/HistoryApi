namespace HistoryApp.Migrations
{
    using System;
    using HistoryApp.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<HistoryApp.Models.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HistoryApp.Models.WebApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var events = new List<APIEvent>
            {
                new APIEvent {
                    Id = 1,
                    Name = "Wounded Knee Massacre",
                    EndDate = Convert.ToDateTime("1890-12-28"),
                    StartDate = Convert.ToDateTime("1890-12-28"),
                    Category = "Battles",
                    Latitude = 43.4364,
                    Longitude = -102.5453,                    
                    ImageName = "Wounded Knee Massacre",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/1/1d/DeadBigfoot.jpg",
                    Excerpt = "The Wounded Knee Massacre occurred on December 29, 1890, near Wounded Knee Creek on the Lakota...",
                    Description = "The Wounded Knee Massacre occurred on December 29, 1890, near Wounded Knee Creek on the Lakota Pine Ridge Indian Reservation in the U.S. state of South Dakota. On the day before, a detachment of the U.S. 7th Cavalry Regiment commanded by Major Samuel M. Whitside intercepted Spotted Elk's band of Miniconjou Lakota and 38 Hunkpapa Lakota near Porcupine Butte and escorted them five miles westward to Wounded Knee Creek, where they made camp.\nThe remainder of the 7th Cavalry Regiment arrived, led by Colonel James W. Forsyth and surrounded the encampment supported by four Hotchkiss guns.\nOn the morning of December 29, the troops went into the camp to disarm the Lakota. One version of events claims that during the process of disarming the Lakota, a deaf tribesman named Black Coyote was reluctant to give up his rifle, claiming he had paid a lot for it. A scuffle over Black Coyote's rifle escalated and a shot was fired which resulted in the 7th Cavalry's opening fire indiscriminately from all sides, killing men, women, and children, as well as some of their own fellow soldiers. Those few Lakota warriors who still had weapons began shooting back at the attacking soldiers, who quickly suppressed the Lakota fire. The surviving Lakota fled, but U.S. cavalrymen pursued and killed many who were unarmed.",
                    SourceUrl = "http://en.wikipedia.org/wiki/index.html?curid=209886"
                },
                new APIEvent {
                    Id = 2,
                    Name = "Battle of the Boyne",
                    EndDate = Convert.ToDateTime("1690-01-01"),
                    StartDate = Convert.ToDateTime("1690-01-01"),
                    Category = "Battles",
                    Latitude = 53.713889,
                    Longitude = -6.350278,
                    ImageName = "BattleOfBoyne",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/2/20/BattleOfBoyne.gif",
                    Excerpt = "The Battle of the Boyne was fought in 1690 between two rival claimants of the English, Scottish,...",
                    Description = "The Battle of the Boyne was fought in 1690 between two rival claimants of the English, Scottish, and Irish thrones – the Catholic James VII & II and the Protestant William III, II & I – across the River Boyne near Drogheda on the east coast of Ireland. The battle, won by William, was a turning point in James's unsuccessful attempt to regain the crown and ultimately helped ensure the continuation of Protestant ascendancy in Ireland.\nThe battle took place on 1 July 1690 in the \"old style\" calendar. This was equivalent to 11 July in the \"new style\" calendar, although today its commemoration is held on 12 July, on which the decisive Battle of Aughrim was fought a year later. William's forces defeated James's army of mostly raw recruits. The symbolic importance of this battle has made it one of the best-known battles in the history of the British Isles and a key part of the folklore of the Orange Order. Its commemoration today is principally by the Protestant Orange Institution.",
                    SourceUrl = "http://en.wikipedia.org/wiki/index.html?curid=68318"
                },
                new APIEvent {
                    Id = 3,
                    Name = "Attack on Broome",
                    EndDate = Convert.ToDateTime("1942-03-03"),
                    StartDate = Convert.ToDateTime("1942-03-03"),
                    Category = "Attack",
                    Latitude = -17.961944,
                    Longitude = 122.236111,
                    ImageName = "Attack on Broome",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/en/a/a9/Broome_Dornier_%28AWM044613%29.jpg",
                    Excerpt = "The town of Broome, Western Australia was attacked by Japanese fighter planes on 3 March 1942,...",
                    Description = "The town of Broome, Western Australia was attacked by Japanese fighter planes on 3 March 1942, during World War II. At least 88 people were killed.\nAlthough Broome was a small pearling port at the time, it was also a refuelling point for aircraft, on the route between the Netherlands East Indies and major Australian cities. As a result, Broome was on a line of flight for Dutch and other refugees, following the Japanese invasion of Java, and had become a significant Allied military base. During a two-week period in February–March 1942, more than a thousand refugees from the Dutch East Indies — many of them in flying boats, which often served as airliners at the time – passed through Broome.\nThe number of refugees has previously been given as 8000, but new research by Dr Tom Lewis contends that this figure is massively overstated. The figure was first quoted in the relevant Australian Official War History and has been reproduced in many publications since. The actual number of aerial evacuees passing through Broome at this time is estimated to have been only 1,350. Most of these were military personnel. There were approximately just 250 Dutch civilian refugees, most of whom were family members of Dutch aircrews.",
                    SourceUrl = "http://en.wikipedia.org/wiki/index.html?curid=3635392"
                },
                new APIEvent {
                    Id = 4,
                    Name = "Siege of Limerick",
                    EndDate = Convert.ToDateTime("1690-08-01"),
                    StartDate = Convert.ToDateTime("1690-09-01"),
                    Category = "Battles",
                    Latitude = 52.6653,
                    Longitude = -8.6238,
                    ImageName = "Patrick Sarsfield, 1st Earl of Lucan",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/en/b/b7/Sarsfield.gif",
                    Excerpt = "Limerick, a city in western Ireland, was besieged twice in the Williamite War in Ireland,...",
                    Description = "Limerick, a city in western Ireland, was besieged twice in the Williamite War in Ireland, 1689-1691. On the first of these occasions, in August to September 1690, its Jacobite defenders retreated to the city after their defeat at the Battle of the Boyne. The Williamites, under William III, tried to take Limerick by storm, but were driven off and had to retire into their winter quarters.",
                    SourceUrl = "http://en.wikipedia.org/wiki/index.html?curid=6817788"
                }
            };
            events.ForEach(s => s.AddGeolocation());
            events.ForEach(s => context.Events.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
