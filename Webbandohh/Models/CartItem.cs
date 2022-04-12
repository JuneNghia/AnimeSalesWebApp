using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webbandohh.Models
{
    [Serializable]
    public class CartItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}