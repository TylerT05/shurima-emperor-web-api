using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class MiniSeries
    {
        public int Losses { get; set; }
        public string Progress { get; set; }
        public int Target { get; set; }
        public int Wins { get; set; }
    }
}
