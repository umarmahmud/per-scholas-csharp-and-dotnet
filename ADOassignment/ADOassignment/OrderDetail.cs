using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class OrderDetail
    {
        private OrderDetail()
        {

        }

        public int? OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int? QuantityOrdered { get; set; }
        public decimal? PriceEach { get; set; }
        public int? OrderLineNumber { get; set; }

        public static OrderDetail OrderDetailFactory(IDataReader reader)
        {
            return new OrderDetail
            {
                OrderNumber = reader.IsDBNull(0) ? (int?)null : reader.GetInt32(0),
                ProductCode = reader.IsDBNull(1) ? null : reader.GetString(1),
                QuantityOrdered = reader.IsDBNull(2) ? (int?) null : reader.GetInt32(2),
                PriceEach = reader.IsDBNull(3) ? (decimal?) null : reader.GetDecimal(3),
                OrderLineNumber = reader.IsDBNull(4) ? (int?) null : reader.GetInt16(4),
            };
        }
    }
}
