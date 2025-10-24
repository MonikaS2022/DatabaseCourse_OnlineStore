using System;
namespace OnlineStore
{
    public class CustomerHandler
    {
        DatabaseConnect databaseConnect = new DatabaseConnect();
        public CustomerHandler()
        {
        }

        public void CustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer MENU. Please select one of the following options: \n 1- Login \n 2- CreateCustomer \n 3- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    Login();
                }
                else if (choice.Equals("2"))
                {
                    RegistrateCustomer();
                }
                else if (choice.Equals("3"))
                {
                    break;
                }

            }
        }

        public void Login()
        {
            Console.WriteLine("Please enter username: ");
            Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            Console.ReadLine();
            LoginCustomer();

        }
        public void LoginCustomer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer Login MENU. Please select one of the following options: \n 1- Products \n 2- Orders \n 3- Exit");
                string choice = Console.ReadLine();


                if (choice.Equals("1"))
                {
                    ShowProductsMeny();
                    
                }
                else if (choice.Equals("2"))
                {
                    SearchOrdersMenu();
                }

                else if (choice.Equals("3"))
                {
                    break;
                }
            }
        }

        public void ShowProductsMeny()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Customers PRODUCTS MENU. Please select one of the following options: \n 1- Show ALL Products \n 2- Show ALL Products that are currently discounted \n 3- Show Products By ID \n 4- Show Products By SupplierID \n 5- Show Products By Product Name\n 6- Show Products By Price \n 7- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Show ALL products");
                        string search = Console.ReadLine();
                        databaseConnect.ShowProductsAll();
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }

                if (choice.Equals("2"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Show ALL products that are currently discounted");
                        databaseConnect.ShowAllProductsWithDiscounts();
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }

                else if (choice.Equals("3"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search by product code:");
                        string search = Console.ReadLine();

                        try
                        {
                            databaseConnect.ShowProductsByCode(search);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("4"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search by supplier ID:");
                        
                        try
                        {
                            int search = int.Parse(Console.ReadLine());
                            databaseConnect.ShowProductsBySupplierId(search);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("5"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search by Product name: ");
                        string search = Console.ReadLine();
                        databaseConnect.ShowProductsByProductName(search);
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("6"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search by price range, you will be entering two prices.");

                        Console.WriteLine("Enter lowest price: ");
                        try
                        {
                            int search = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter highest price: ");
                            int searchTwo = int.Parse(Console.ReadLine());

                            databaseConnect.ShowProductsByPrice(search, searchTwo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }

                else if (choice.Equals("7"))
                {
                    break;
                }
            }
        }


        public void SearchOrdersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer ORDERS MENU. Please select one of the following options: \n 1- Make an order \n 2- Add product to order \n 3- See all orders \n 4- See orderslist by ordersId \n 5- Delete orders \n 6- Accept and pay for order \n 7- Exit");
                string choice = Console.ReadLine();


                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Make an order, enter email:");
                        string search = Console.ReadLine();
                        try
                        {
                            databaseConnect.CreateOrder(search);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine("Create more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("2"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Add product to order");
                        try
                        {


                            Console.WriteLine("Order Id:");
                            int orderId = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Product code:");
                            string productCode = Console.ReadLine();
                            Console.WriteLine("Quantity:");
                            int quantity = Int32.Parse(Console.ReadLine());

                            databaseConnect.AddToOrder(orderId, productCode, quantity);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine("Add more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }

                else if (choice.Equals("3"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("See all orders by email: ");
                        string search = Console.ReadLine();
                        databaseConnect.SeeAllOrdersByEmail(search);
                        Console.WriteLine();

                        Console.WriteLine("See again? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("4"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("See products on orderId:");
                        try
                        {
                            int search = int.Parse(Console.ReadLine());
                            databaseConnect.SeeProductsbyOrderId(search);
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("5"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Delete order");
                        try
                        {

                            int search = int.Parse(Console.ReadLine());
                            databaseConnect.DeleteOrder(search);
                            databaseConnect.DeleteOrderId(search);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("This order cannot be deleted");
                        }
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("6"))
                {

                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("Enter order id: ");
                        string orderId = Console.ReadLine();
                        databaseConnect.Calculatefullprice(Int32.Parse(orderId));

                        Console.WriteLine("Do you wanna pay for this order?");

                        Console.ReadLine();

                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }

                }
                else if (choice.Equals("7"))
                {
                    break;
                }
            }
        }

        public void RegistrateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Customer REGISTRATION");

            Console.WriteLine("First name");
            string firstname = Console.ReadLine();
            Console.WriteLine("Last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            Console.WriteLine("Address");
            string address = Console.ReadLine();
            Console.WriteLine("City");
            string city = Console.ReadLine();
            Console.WriteLine("Country");
            string country = Console.ReadLine();
            Console.WriteLine("Phonenumber");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("You are now registrated!");

            databaseConnect.CreateCustomer(firstname, lastname, email, address, city, country, phoneNumber);
            Console.ReadKey();

        }
    }
}

