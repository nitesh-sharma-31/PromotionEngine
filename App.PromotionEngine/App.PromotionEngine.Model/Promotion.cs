using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.Model
{
    public class Promotion
    {
        public Dictionary<string, int> Combinations = new Dictionary<string, int>();

        public double Amount { get; set; }
    }
}
