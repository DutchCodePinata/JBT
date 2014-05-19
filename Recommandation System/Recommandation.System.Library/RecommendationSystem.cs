using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Recommandation.System.Library;

namespace Recommendation.System.Library
{
    public class RecommendationSystem
    {
        private Dictionary<int, Rating> ratings;
        private Dictionary<int, Tag> tags;
        private Dictionary<int, Movie> movies;

        private List<int> productID;

        public RecommendationSystem()
        {
            init();
            
            getDataSets();
            Add();
            CreateAllPearson();
        }

        private void init()
        {
            ratings = new Dictionary<int, Rating>();
            tags = new Dictionary<int, Tag>();
            movies = new Dictionary<int, Movie>();

            productID = new List<int>();    
        }

        private void getDataSets()
        {
            ratings = dataSet<Rating>("FILE LOCATION");
            tags = dataSet<Tag>("FILE LOCATION");
            movies = dataSet<Movie>("FILE LOCATION");
        }

        private Dictionary<int,TClass> dataSet<TClass>(string file) where TClass : Data, new()
        {
            Dictionary<int, TClass> dictionary = new Dictionary<int, TClass>();
            StreamReader s = new StreamReader(file);

            string allData = s.ReadToEnd();
            string[] rows = allData.Split("\r\n".ToCharArray());
            foreach (string row in rows)
            {
                //Split the row at the delimiter.
                string[] items = row.Split("::".ToCharArray());

                //Add the item
                dictionary.Add(
                    int.Parse(items[0]),
                    new TClass(){data = items});
            }
            return dictionary;
        }

        private double getRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public void Add()
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";
            StreamReader myFile = new StreamReader("c:\\Users\\Gameblade\\Desktop\\testdata.txt");
            string userString;
            while ((userString = myFile.ReadLine()) != null)
            {
                string[] userinfo = userString.Split(',');
                if (!users.ContainsKey(int.Parse(userinfo[0])))
                {
                    users.Add(int.Parse(userinfo[0]), new Preference(int.Parse(userinfo[0])));
                }
                if (!productID.Contains(int.Parse(userinfo[1])))
                {
                    productID.Add(int.Parse(userinfo[1]));
                }
                Preference pref = users[int.Parse(userinfo[0])];
                pref.Add(int.Parse(userinfo[1]), double.Parse(userinfo[2], ci));
            }


            myFile.Close();

            //Display the file contents.
            Console.WriteLine("Userdata loaded");
            //Suspend the screen.
            Console.ReadLine();
        }

        public void CreateAllPearson()
        {
            foreach (KeyValuePair<int, Preference> pref in users)
            {
                CreatePearson(pref.Value);
            }
            Console.ReadLine();
        }

        public void CreatePearson(Preference user)
        {
            double teller;
            double noemerA;
            double noemerB;
            double pearson;
            double fase1;
            double fase2;
            foreach (KeyValuePair<int, Preference> pref in users)
            {
                teller = 0;
                noemerA = 0;
                noemerB = 0;

                if (user.getID() != pref.Key)
                {
                    foreach (int ID in user.getItem())
                    {
                        if (Array.BinarySearch(pref.Value.getItem(), ID) >= 0)
                        {
                            fase1 = (user.getRating()[Array.BinarySearch(user.getItem(), ID)] - user.getAverageRating());
                            fase2 = (pref.Value.getRating()[Array.BinarySearch(pref.Value.getItem(), ID)] - pref.Value.getAverageRating());
                            teller += fase1 * fase2;
                            noemerA += Math.Pow(user.getRating()[Array.BinarySearch(user.getItem(), ID)] - user.getAverageRating(), 2);
                            noemerB += Math.Pow(pref.Value.getRating()[Array.BinarySearch(pref.Value.getItem(), ID)] - pref.Value.getAverageRating(), 2);
                        }
                    }
                    pearson = teller / Math.Sqrt(noemerA * noemerB);
                    //Display the file contents.
                    //Console.WriteLine(teller + " / " + Math.Sqrt(noemerA * noemerB));
                    Console.WriteLine(user.getID() + " -> " + pref.Value.getID() + " | " + pearson);
                    //Suspend the screen.
                }
            }
            Console.WriteLine();
        }

        public void GetInfo(Preference user)
        {
            //Console.WriteLine(user.getID());

            int userid = user.getID();
            int[] items = user.getItem();
            double[] ratings = user.getRating();
            int teller = 0;
            foreach (int i in items)
            {
                Console.WriteLine(userid + " " + items[teller] + " " + ratings[teller]);
                teller++;
            }

            Console.ReadLine();
        }
    }
}
