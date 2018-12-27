using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ADOassignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user id=root;password=password;database=classicmodels;";
            string ordersListQuery = "SELECT * FROM orders ";
            string orderDetailsListQuery = "SELECT *" +
                                           "FROM orderDetails " +
                                           "INNER JOIN orders " +
                                                "ON orders.orderNumber=orderDetails.orderNumber " +
                                           "WHERE orders.orderNumber=10422";
            string latestOrderQuery = "SELECT customerName, employeeNumber " +
                                      "FROM orders " +
                                      "INNER JOIN customers " +
                                            "ON orders.customerNumber=customers.customerNumber " +
                                      "INNER JOIN employees " +
                                            "ON customers.salesRepEmployeeNumber=employees.employeeNumber " +
                                      "WHERE orders.orderNumber=10422";
            List<Order> ordersList = new List<Order>();
            List<OrderDetail> ordersDetailsList = new List<OrderDetail>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(ordersListQuery, connection);
 
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    // populate List<Order> representing all of the orders in the database
                    while (reader.Read())
                    {
                        ordersList.Add(Order.OrderFactory(reader));
                    }
                    reader.Close();

                    command.CommandText = orderDetailsListQuery;
                    reader = command.ExecuteReader();

                    // for order 10422, populate List<OrderDetail> for each item in the order and load related objects - the customer who placed the order and the employee who enabled the order
                    while (reader.Read())
                    {
                        ordersDetailsList.Add(OrderDetail.OrderDetailFactory(reader));
                    }
                    reader.Close();

                    command.CommandText = latestOrderQuery;
                    reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Console.WriteLine($"The customer name is: " + reader[0]);
                        Console.WriteLine($"The employee number is: " + reader[1]); 
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
