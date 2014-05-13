using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommandation.System.Library
{
    public class RecommandationSystemFactory
    {
        public static RecommandationSystem GetRecommandationSystem()
        {
            return new RecommandationSystem();
        }
    }
}
