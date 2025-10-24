using Npgsql;
using System;
using System.Data;
namespace OnlineStore;

internal class Program
{
    private static void Main(string[] args)
    {

        DatabaseConnect databaseConnect = new DatabaseConnect();
        CustomerHandler customerHandler = new CustomerHandler();
        AdminHandler adminHandler = new AdminHandler();
        while (true)
        {
           Console.Clear();
            Console.WriteLine("Please select one of the following options: \n 1- Admin \n 2- Customer \n 3- Exit");
            string choice = Console.ReadLine();

            
            if (choice.Equals("1"))
            {
                adminHandler.AdminMenu();
            }
            else if (choice.Equals("2"))
            {
                customerHandler.CustomerMenu();
            }
            else if (choice.Equals("3"))
            {
                break;
            }

        }
    }
}