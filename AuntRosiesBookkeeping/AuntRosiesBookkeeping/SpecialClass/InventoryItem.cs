/**
 * InventoryItem() - Used to handle the management of inventory items
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuntRosiesBookkeeping.SpecialClass
{
    class InventoryItem
    {
        public int InventoryId { get; set; }

        public string InventoryDescription { get; set; }

        public string InventoryType { get; set; }

        public double InventoryQuantity { get; set; }

        public string Measurement { get; set; }

    }
}
