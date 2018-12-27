using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Payment
    {
        private Payment()
        {

        }

        public int? CustomerNumber { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }

        public static Payment PaymentFactory(IDataReader reader)
        {
            return new Payment
            {
                CustomerNumber = reader.IsDBNull(0) ? (int?) null : reader.GetInt32(0),
                CheckNumber = reader.IsDBNull(1) ? null : reader.GetString(1),
                PaymentDate = reader.IsDBNull(2) ? (DateTime?) null : reader.GetDateTime(2),
                Amount = reader.IsDBNull(3) ? (decimal?) null : reader.GetDecimal(3),
            };
        }
    }
}
