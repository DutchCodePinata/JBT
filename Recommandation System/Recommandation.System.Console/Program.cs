using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Recommandation.System.Library;

namespace Recommandation.System.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var recommandationSystem = RecommendationSystemFactory.GetRecommendationSystem();
            }
            catch (Exception e)
            {
                
                throw;
            }           
        }
    }
}
