using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Office
    {
        private Office()
        {

        }

        public string OfficeCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Territory { get; set; }

        public static Office OfficeFactory(IDataReader reader)
        {
            return new Office
            {
                OfficeCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                City = reader.IsDBNull(1) ? null : reader.GetString(1),
                Phone = reader.IsDBNull(2) ? null : reader.GetString(2),
                AddressLine1 = reader.IsDBNull(3) ? null : reader.GetString(3),
                AddressLine2 = reader.IsDBNull(4) ? null : reader.GetString(4),
                State = reader.IsDBNull(5) ? null : reader.GetString(5),
                Country = reader.IsDBNull(6) ? null : reader.GetString(6),
                PostalCode = reader.IsDBNull(7) ? null : reader.GetString(7),
                Territory = reader.IsDBNull(8) ? null : reader.GetString(8),
            };
        }
    }
}
