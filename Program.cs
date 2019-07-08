using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> mntVernom = Artists.Where(artist => artist.Hometown == "Mount Vernon");
            foreach(var art in mntVernom)
            {
                Console.WriteLine(art.ArtistName);
                Console.WriteLine(art.RealName);
                Console.WriteLine(art.Age);
            }
            

            //Who is the youngest artist in our collection of artists?
            IEnumerable<Artist> youngest = Artists.OrderBy(young => young.Age);
            Artist baby = youngest.FirstOrDefault();
            Console.WriteLine(baby.Age);


            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> will = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(var x in will)
            {
                Console.WriteLine(x.ArtistName);
                Console.WriteLine(x.RealName);
                Console.WriteLine(x.Age);
            }

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> atl = Artists.Where(artist => artist.Hometown == "Atlanta" && artist.Age > 38);
            foreach(var x in atl)
            {
                Console.WriteLine(x.ArtistName);
                Console.WriteLine(x.RealName);
                Console.WriteLine(x.Age);
                Console.WriteLine(x.Hometown);
                Console.WriteLine("###############################");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            IEnumerable<Group> wtc = Groups.Where(group => group.GroupName == "Wu-Tang Clan");
            foreach(var x in wtc)
            {
                Console.WriteLine(x.GroupName);
                foreach(var y in x.Members)
                {
                    Console.WriteLine(y.RealName);
                }
                Console.WriteLine("###############################");
            }
	        // Console.WriteLine(Groups.Count);
        }
    }
}
