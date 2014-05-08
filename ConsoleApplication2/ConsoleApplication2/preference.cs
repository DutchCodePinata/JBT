using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Preference
    {
        int userID;
        int[] itemID = new int[0];
        double[] ratingID = new double[0];

        public Preference(int ID)
        {
            userID = ID;
        }

        public void Add(int item, double rating)
        {
            int[] copyItem = itemID;
            itemID = new int[itemID.Length+1];
            Array.Copy(copyItem, itemID, copyItem.Length);
            itemID[copyItem.Length] = item;

            double[] copyRating = ratingID;
            ratingID = new double[ratingID.Length + 1];
            Array.Copy(copyRating, ratingID, copyRating.Length);
            ratingID[copyRating.Length] = rating;
        }

        
        //sorteert de itemID (zorg dat rating mee gaat)
        //maak copy
        //sorteer origineel
        //vind de rating bij de oude en zet ze bij de nieuwe
        public void Sort()
        {
            int[] copyItem = new int[itemID.Length];
            double[] copyRating = new double[ratingID.Length];
            Array.Copy(itemID, copyItem, copyItem.Length);
            Array.Copy(ratingID, copyRating, copyRating.Length);
            int teller = 0;
            Array.Sort(itemID);
            foreach (int item in copyItem)
            {
                int i = Array.BinarySearch(itemID, copyItem[teller]);
                ratingID[i] = copyRating[teller];
                teller++;
            }    
        }

        public double getAverageRating()
        {
            double total = 0;
            foreach (double d in ratingID)
            {
                total += d;
            }
            return total/ratingID.Length;
        }

        public int getID()
        {
            return userID;
        }

        public int[] getItem()
        {
            return itemID;
        }

        public double[] getRating()
        {
            return ratingID;
        }
    }
}
