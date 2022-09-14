using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNGV.TALKDESK.DOMAIN.Models
{
    public class Prefix
    {

        public string PrefixNumber { get; set; }
        public List<PrefixDefinition> BusinessCount { get; set; }

        public Prefix()
        {
            BusinessCount = new List<PrefixDefinition>();
        }
    }
}
