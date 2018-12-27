using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Product
    {
        private Product()
        {

        }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductLine { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public int? QuantityInStock { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? MSRP { get; set; }

        public static Product ProductFactory(IDataReader reader)
        {
            return new Product
            {
                ProductCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                ProductName = reader.IsDBNull(1) ? null : reader.GetString(1),
                ProductLine = reader.IsDBNull(2) ? null : reader.GetString(2),
                ProductScale = reader.IsDBNull(3) ? null : reader.GetString(3),
                ProductVendor = reader.IsDBNull(4) ? null : reader.GetString(4),
                ProductDescription = reader.IsDBNull(5) ? null : reader.GetString(5),
                QuantityInStock = reader.IsDBNull(6) ? (int?) null : reader.GetInt16(6),
                BuyPrice = reader.IsDBNull(7) ? (decimal?) null : reader.GetDecimal(7),
                MSRP = reader.IsDBNull(8) ? (decimal?) null : reader.GetDecimal(8)
            };
        }
    }
}
