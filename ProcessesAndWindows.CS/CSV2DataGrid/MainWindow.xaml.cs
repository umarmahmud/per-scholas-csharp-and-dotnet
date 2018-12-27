using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace CSV2DataGrid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

            var lines = File.ReadAllLines("Customers.txt").ToList();

            lines.RemoveAt(0);

            foreach (var l in lines)
            {
                Customer c = new Customer();
                var column = l.Replace("NULL", "").Split('\t');
                for(var i = 0; i < column.Length; i++)
                { 
                    c.customerNumber = column[0];
                    c.customerName = column[1];
                    c.contactLastName = column[2];
                    c.contactFirstName = column[3];
                    c.phone = column[4];
                    c.addressLine1 = column[5];
                    c.addressLine2 = column[6];
                    c.city = column[7];
                    c.state = column[8];
                    c.postalCode = column[9];
                    c.country = column[10];
                    c.salesRepEmployeeNumber = column[11];
                    c.creditLimit = column[12];
                }

                CustomerGrid.Items.Add(c);

            }
		}

        public class Customer
        {
            public string customerNumber { get; set; }
            public string customerName { get; set; }
            public string contactLastName { get; set; }
            public string contactFirstName { get; set; }
            public string phone { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postalCode { get; set; }
            public string country { get; set; }
            public string salesRepEmployeeNumber { get; set; }
            public string creditLimit { get; set; }
        }

	}
}
