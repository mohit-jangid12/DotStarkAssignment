using System;
using System.Collections.Generic;
using System.Text;

namespace DotStarkTest.Core.ViewModel
{
    public class ProductVM
    {
        public long ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public long StockAvailable { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Delete { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
