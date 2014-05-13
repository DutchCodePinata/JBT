using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommandation.System.Library
{
    public class RecommendationSystemFactory
    {
        public static RecommendationSystem GetRecommandationSystem()
        {
            return new RecommendationSystem();
        }
    }
}
