using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _2lab8.Models
{
    public class Product
    {
        public string Name { get; set; }
        public long? InventoryNumber { get; set; }
        public int? Weight { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public Byte[] Image { get; set; }
        public string Producer { get; set; }
        public string ImagePath { get; set; }
    }
}
