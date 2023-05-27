using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagerInterface
{
    public class OrderedItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public OrderedItem(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
