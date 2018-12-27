using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Customer
    {
        private Customer()
        {

        }

        public int? CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactFirstName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int? EmployeeNumber { get; set; }
        public decimal? CreditLimit { get; set; }

        public static Customer CustomerFactory(IDataReader reader)
        {
            return new Customer
            {
                CustomerNumber = reader.IsDBNull(0) ? (int?) null : reader.GetInt32(0),
                CustomerName = reader.IsDBNull(1) ? null : reader.GetString(1),
                ContactLastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                ContactFirstName = reader.IsDBNull(3) ? null : reader.GetString(3),
                Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                AddressLine1 = reader.IsDBNull(5) ? null : reader.GetString(5),
                AddressLine2 = reader.IsDBNull(6) ? null : reader.GetString(6),
                City = reader.IsDBNull(7) ? null : reader.GetString(7),
                State = reader.IsDBNull(8) ? null : reader.GetString(8),
                PostalCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                Country = reader.IsDBNull(10) ? null : reader.GetString(10),
                EmployeeNumber = reader.IsDBNull(11) ? (int?) null : reader.GetInt32(11),
                CreditLimit = reader.IsDBNull(12) ? (decimal?) null: reader.GetDecimal(12)
            };
        }
    }
}
