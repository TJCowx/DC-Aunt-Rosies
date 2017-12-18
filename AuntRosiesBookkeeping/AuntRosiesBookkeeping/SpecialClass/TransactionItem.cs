using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuntRosiesBookkeeping.SpecialClass
{
    public class TransactionItem
    {
        public int ProductId { get; set; }

        public string ProductDescription { get; set; }

        public string ProductPrice { get; set; }

        public double ProductQuantity { get; set; }
    }
}
