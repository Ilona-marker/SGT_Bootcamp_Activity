using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.CardGame
{
    public class SimpleCard : ICard
    {
        public int CardAttribute { get; set; }

        public string GetCardAttribute()
        {
            return $"Card {CardAttribute}"; 
        }

    }
}
