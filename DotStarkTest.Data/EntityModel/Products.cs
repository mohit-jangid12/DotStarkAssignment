using DotStarkTest.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotStarkTest.Data.EntityModel
{
    public class Products : BaseEntity
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public long StockAvailable { get; set; }
    }
}
