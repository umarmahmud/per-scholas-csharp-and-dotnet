using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Order
    {
        private Order()
        {

        }

        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int? CustomerNumber { get; set; }

        public static Order OrderFactory(IDataReader reader)
        {
            return new Order
            {
                OrderNumber = reader.IsDBNull(0) ? (int?) null : reader.GetInt32(0),
                OrderDate = reader.IsDBNull(1) ? (DateTime?) null : reader.GetDateTime(1),
                RequiredDate = reader.IsDBNull(2) ? (DateTime?) null : reader.GetDateTime(2),
                ShippedDate = reader.IsDBNull(3) ? (DateTime?) null : reader.GetDateTime(3),
                Status = reader.IsDBNull(4) ? null : reader.GetString(4),
                Comments = reader.IsDBNull(5) ? null : reader.GetString(5),
                CustomerNumber = reader.IsDBNull(6) ? (int?) null : reader.GetInt32(6)
            };
        }
    }
}
