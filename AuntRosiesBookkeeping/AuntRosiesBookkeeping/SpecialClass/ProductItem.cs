/**
 * ProductItem() - Used for managing product items
 */   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuntRosiesBookkeeping.SpecialClass
{
    class ProductItem
    {
        public int ProductId { get; set; }

        public string ProductDescription { get; set; }

        public int ProductQuantity { get; set; }

        public string ProductType { get; set; }

        public double ProductPrice { get; set; }
    }
}
