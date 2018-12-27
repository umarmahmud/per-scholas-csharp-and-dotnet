using System;
using System.Data;
using System.IO;
using System.Linq;

namespace CSV2DataTable
{
	  // Exercise:	read the tab-delimited file "customers.txt" and package it into a DataTable
		//						Use DataTable.Select find just those customers from Germany.
		//						Print their names to the console.


		//						Assume:
		//							The table columns at indexes 0 and 11 are integers
		//							The table column at index 12 is of type Decimal
		//							All other columns are String
		//							Any value of "NULL" means it is missing and should not be added to the table

	class Program
	{
		static void Main(string[] args)
		{       
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines("customers.txt");
            
            for (int i = 0; i < lines[0].Split("\t").Length; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = lines[0].Split("\t")[i];
                column.AllowDBNull = false;
                dt.Columns.Add(column);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["customerNumber"] = lines[i].Split("\t")[0];
                row["customerName"] = lines[i].Split("\t")[1];
                row["contactLastName"] = lines[i].Split("\t")[2];
                row["contactFirstName"] = lines[i].Split("\t")[3];
                row["phone"] = lines[i].Split("\t")[4];
                row["addressLine1"] = lines[i].Split("\t")[5];
                row["addressLine2"] = lines[i].Split("\t")[6];
                row["city"] = lines[i].Split("\t")[7];
                row["state"] = lines[i].Split("\t")[8];
                row["postalCode"] = lines[i].Split("\t")[9];
                row["country"] = lines[i].Split("\t")[10];
                row["salesRepEmployeeNumber"] = lines[i].Split("\t")[11];
                row["creditLimit"] = lines[i].Split("\t")[12];
                dt.Rows.Add(row);
            }

            for (int i = 0; i < dt.Select("country = 'Germany'").Length; i++)
            {
                Console.WriteLine(dt.Select("country = 'Germany'")[i][1]);
            }
        }
	}
}
