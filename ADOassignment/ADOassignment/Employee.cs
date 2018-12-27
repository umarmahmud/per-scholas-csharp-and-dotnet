using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class Employee
    {
        private Employee()
        {

        }

        public int? EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public int? OfficeCode { get; set; }
        public int? ReportsTo { get; set; }
        public string JobTitle { get; set; }

        public static Employee EmployeeFactory(IDataReader reader)
        {
            return new Employee
            {
                EmployeeNumber = reader.IsDBNull(0) ? (int?) null : reader.GetInt32(0),
                LastName = reader.IsDBNull(1) ? null : reader.GetString(1),
                FirstName = reader.IsDBNull(2) ? null : reader.GetString(2),
                Extension = reader.IsDBNull(3) ? null : reader.GetString(3),
                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                OfficeCode = reader.IsDBNull(5) ? (int?) null : reader.GetInt32(5),
                ReportsTo = reader.IsDBNull(6) ? (int?) null : reader.GetInt32(6),
                JobTitle = reader.IsDBNull(7) ? null : reader.GetString(7),
            };
        }
    }
}
