using System;
namespace OnlineStore
{
    public class AdminHandler
    {
        DatabaseConnect databaseConnect = new DatabaseConnect();

        public AdminHandler()
        {
        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Please select one of the following options: \n 1- Show Suppliers MENY \n 2- Show Products MENY  \n 3- Show Orders MENY \n 4- Show Discounts MENY \n 5- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    ShowSuppliersMeny();
                }
                else if (choice.Equals("2"))
                {
                    ShowProductsMeny();
                }

                else if (choice.Equals("3"))
                {
                    ShowOrdersMenu();
                }
                else if (choice.Equals("4"))
                {
                    ShowDiscountMeny();

                }
                else if (choice.Equals("5"))
                {
                    break;

                }

            }
        }

        public void ShowSuppliersMeny()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Admin SUPPLIERS MENU. Please select one of the following options: \n 1- Show All Suppliers \n 2- Add Supplier \n 3- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Show All suppliers");
                        string search = Console.ReadLine();
                        databaseConnect.ShowSuppliersAll();
                        Console.WriteLine();
                        Console.WriteLine("Search again? Y - for yes, any other ONE letter - for no");
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
                        Console.WriteLine("Add Supplier");
                        Console.WriteLine("Id");
                        try
                        {
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Phonenumber");
                            string sphoneNumber = Console.ReadLine();
                            Console.WriteLine("Address");
                            string saddress = Console.ReadLine();

                            databaseConnect.CreateSupplier(id, sphoneNumber, saddress);
                            Console.WriteLine("Supplier is registrated!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine();
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
                    break;
                }
            }
        }

        public void ShowProductsMeny()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Admin PRODUCTS MENU. Please select one of the following options: \n 1- Show All Products \n 2- Show Products By id \n 3- Show Products By Supplier \n 4- Show Products By Product Name\n 5- Add product \n 6- Delete product \n 7- Edit quantity of product \n 8- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Show All products");
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
                else if (choice.Equals("2"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search by product id:");
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
                else if (choice.Equals("3"))
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
                        Console.WriteLine("Search again? Y - for yes, any other ONE letter - for no");
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
                else if (choice.Equals("5"))
                {
                    while (true)
                    {

                        Console.Clear();
                        Console.WriteLine("Add Product");
                        Console.WriteLine("Product Code: ");
                        string code = Console.ReadLine();
                        Console.WriteLine("Product Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Product Quantity: ");
                        string quantity = Console.ReadLine();
                        Console.WriteLine("Product Price: ");
                        string price = Console.ReadLine();
                        Console.WriteLine("Product Supplier (An integer): ");
                        string supplier = Console.ReadLine();
                        try
                        {
                            databaseConnect.AddProduct(code, name, Int16.Parse(quantity), Int32.Parse(price), Int16.Parse(supplier));
                            Console.WriteLine("Product is added!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }

                        Console.WriteLine("Again? Y - for yes, any other ONE letter - for no");
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
                        Console.WriteLine("Delete product by code:");
                        string pcode = Console.ReadLine();
                        try
                        {
                            databaseConnect.DeleteProduct(pcode);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Product exist in order. Check order first!");
                        }

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
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Edit product by id:");
                        string pcode = Console.ReadLine();
                        Console.WriteLine("Quantity: ");
                        string quantity = Console.ReadLine();
                        databaseConnect.EditQuantity(pcode, Int16.Parse(quantity));
                        Console.WriteLine("Search more? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }

                }
                else if (choice.Equals("8"))
                {
                    break;
                }


            }
        }

        public void ShowOrdersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admins ORDERS MENU. Please select one of the following options: \n 1- See all orders \n 2- Aprove orders \n 3- Exit");
                string choice = Console.ReadLine();


                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("See all orders");
                        string search = Console.ReadLine();
                        databaseConnect.SeeAllOrders();
                        Console.WriteLine();
                        Console.WriteLine("See again? Y - for yes, any other ONE letter - for no");
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
                        Console.WriteLine("Select order id to approve:");
                        try
                        {
                            int search = int.Parse(Console.ReadLine());
                            databaseConnect.ApproveOrder(search);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine("Seach again? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("3"))
                {
                    break;
                }

            }
        }

        public void ShowDiscountMeny()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Admin DISCOUNT MENU. Please select one of the following options: \n 1- Add new discount \n 2- Add discount on product \n 3- Show discount history \n 4- Show current discount options \n 5- Exit");
                string choice = Console.ReadLine();

                if (choice.Equals("1"))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Discount REGISTRATION");
                        Console.WriteLine("Code");
                        try
                        {
                            int dcode = int.Parse(Console.ReadLine());
                            Console.WriteLine("Percentage");
                            int dpercentage = int.Parse(Console.ReadLine());
                            Console.WriteLine("Reason");
                            string dreason = Console.ReadLine();
                            Console.WriteLine("Discount is registrated!");

                            databaseConnect.CreateNewDiscount(dcode.ToString(), dpercentage, dreason);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        Console.WriteLine("Seach again? Y - for yes, any other ONE letter - for no");
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
                        Console.WriteLine("Adding discount to product");
                        Console.WriteLine("Start date: (year-mm-dd) format");

                        try {

                        DateOnly startDate = DateOnly.Parse(Console.ReadLine());
                        Console.WriteLine("End date: (year-mm-dd) format");
                        DateOnly endDate = DateOnly.Parse(Console.ReadLine());

                        Console.WriteLine(endDate);

                        if (startDate > endDate) 
                        {
                            Console.WriteLine($"Start date: {startDate} cannot be after end date: {endDate}.");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine("Enter discount code: ");

                        string discountCode = Console.ReadLine();

                        Console.WriteLine("Enter product code: ");
                        string productCode = Console.ReadLine();

                        databaseConnect.CreateNewDiscountHistory(startDate, endDate, discountCode, productCode);
                        }

                        catch (Exception ex)
                        {
                        Console.WriteLine("Something went wrong...");
                            Console.WriteLine(ex.Message);

                        }
                        Console.WriteLine("again? Y - for yes, any other ONE letter - for no");
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
                        databaseConnect.SeeAllDiscountHistory();
                        Console.WriteLine();
                        Console.WriteLine("Search again? Y - for yes, any other ONE letter - for no");
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
                        databaseConnect.SeeAllDiscounts();
                        Console.WriteLine();
                        Console.WriteLine("Seach again? Y - for yes, any other ONE letter - for no");
                        char input = char.Parse(Console.ReadLine());
                        if (!input.Equals('Y'))
                        {
                            break;
                        }
                    }
                }
                else if (choice.Equals("5"))
                {
                    break;
                }
            }
        }

       
    }
}



