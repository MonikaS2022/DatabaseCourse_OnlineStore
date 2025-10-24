using System;
using System.Diagnostics.Metrics;
using System.Net;
using Npgsql;

namespace OnlineStore
{
	public class DatabaseConnect
	{
		public DatabaseConnect()
		{

		}

        public void CreateCustomer(string firstname, string lastname, string email, string address, string city, string country, string phonenumber)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();
            
            string sql = "call CreateCustomer(@Fname, @Lname, @Cemail, @Caddress, @Ccity, @Ccountry, @CphoneNumber)";
            using var cmd = new NpgsqlCommand(sql, con);
            
            cmd.Parameters.AddWithValue("@Fname", firstname);
            cmd.Parameters.AddWithValue("@Lname", lastname);
            cmd.Parameters.AddWithValue("@Cemail", email);
            cmd.Parameters.AddWithValue("@Caddress", address);
            cmd.Parameters.AddWithValue("@Ccity", city);
            cmd.Parameters.AddWithValue("@Ccountry", country);
            cmd.Parameters.AddWithValue("@CphoneNumber", phonenumber);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void ShowProductsAll()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Product Order by psupplier, pcode";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    Console.WriteLine("----------------------------------");
            //    Console.WriteLine("Code: " + rdr.GetString(0));
            //    Console.WriteLine("Name: " + rdr.GetString(1));
            //    Console.WriteLine("Quantity: " + rdr.GetInt32(2));
            //    Console.WriteLine("Price: " + rdr.GetInt32(3));
            //    Console.WriteLine("Supplier: " + rdr.GetInt32(4));
            //    Console.WriteLine("----------------------------------");
            //}
            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", "Code", "Name", "Quantity", "Price", "Supplier");

            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4));
            }
            
            con.Close();
        }

        public void ShowProductsByCode(string search)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Product WHERE pcode = '" +search +"'";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    Console.WriteLine("----------------------------------");
            //    Console.WriteLine("Code: " + rdr.GetString(0));
            //    Console.WriteLine("Name: " + rdr.GetString(1));
            //    Console.WriteLine("Quantity: " + rdr.GetInt32(2));
            //    Console.WriteLine("Price: " + rdr.GetInt32(3));
            //    Console.WriteLine("Supplier: " + rdr.GetInt32(4));
            //    Console.WriteLine("----------------------------------");

            //}
            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", "Code", "Name", "Quantity", "Price", "Supplier");

            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4));
            }
            con.Close();
        }
       
        public void ShowProductsByProductName(string search)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = $"SELECT * FROM Product WHERE pname = '" + search + "'order by psupplier";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    Console.WriteLine("----------------------------------");
            //    Console.WriteLine("Code: " + rdr.GetString(0));
            //    Console.WriteLine("Name: " + rdr.GetString(1));
            //    Console.WriteLine("Quantity: " + rdr.GetInt32(2));
            //    Console.WriteLine("Price: " + rdr.GetInt32(3));
            //    Console.WriteLine("Supplier: " + rdr.GetInt32(4));
            //    Console.WriteLine("----------------------------------");
            //}

            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", "Code", "Name", "Quantity", "Price", "Supplier");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4));
            }

            con.Close();
        }
        
        public void ShowProductsBySupplierId(int search)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Product join supplier on product.psupplier = supplier.id Where supplier.id = " + search + " order by pcode";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", "Code", "Name", "Quantity", "Price", "Supplier");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4));
            }
            con.Close();
        }

        public void ShowProductsByPrice(int lowestPrice, int highestprice)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Product Where pprice >= " + lowestPrice + " and pprice <= " + highestprice + "order by pprice";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10}", "Code", "Name", "Quantity", "Price");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
            }
            con.Close();
        }

        public void EditQuantity(string productCode, int quantity)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call EditQuantityProduct(@pcodeIn, @quantity)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@pcodeIn", productCode);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void DeleteProduct(string productCode)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call DeleteProduct(@pcodeIn)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@pcodeIn", productCode);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void AddProduct(string pcode, string pname, int pquantity, int pprice, int psupplier)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call AddProduct(@Pcode, @Pname, @Pquantity, @Pprice, @Psupplier)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Pcode", pcode);
            cmd.Parameters.AddWithValue("@Pname", pname);
            cmd.Parameters.AddWithValue("@Pquantity", pquantity);
            cmd.Parameters.AddWithValue("@Pprice", pprice);
            cmd.Parameters.AddWithValue("@Psupplier", psupplier);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void CreateOrder(string email)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call CreateOrder(@cemail)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cemail", email);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void CreateSupplier(int id, string sphonenumber, string saddress)
        {
           
                var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";


                using var con = new NpgsqlConnection(cs);
                con.Open();

                var transaction = con.BeginTransaction();

                string sql = "call CreateSupplier(@id, @sphonenumber, @saddress)";
                using var cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sphoneNumber", sphonenumber);
                cmd.Parameters.AddWithValue("@saddress", saddress);

                int affected = cmd.ExecuteNonQuery();

                transaction.Commit();
                con.Close();
            

            //catch (Exception ex)
            //{
            //    Console.WriteLine("Something went wrong");
            //}
        }

        public void AddToOrder(int orderId, string productCode, int quantity)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";


            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call addtoorder(@oid, @pcode, @oquantity)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@oid", orderId);
            cmd.Parameters.AddWithValue("@pcode", productCode);
            cmd.Parameters.AddWithValue("@oquantity", quantity);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void SeeAllOrdersByEmail(string search)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql1 = $"SELECT * FROM OrderConfirmation WHERE (cemail like '%{search}%')";
            string sql = "SELECT * FROM OrderConfirmation WHERE cemail= '" +search +"'";

            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

           

            Console.WriteLine("{0, 10} {1, 10} {2, 10} ", "Order nr", "Confirmation", "Email");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", rdr.GetInt32(0), rdr.GetBoolean(1), rdr.GetString(2));
            }
            con.Close();
            
        }

        public void DeleteOrder(int orderNr)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call removeOrder2(@orderNr)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@orderNr", orderNr);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();

        }

        public void DeleteOrderId(int orderNr) //make sure to delete just false orders - fails when trying to delete orders which are approved
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "Delete from orderconfirmation where oid = " + orderNr;
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@orderNr", orderNr);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();

        }

        public void SeeAllOrders()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM OrderConfirmation order by oid";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} ", "Order nr", "Confirmation", "Email");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", rdr.GetInt32(0), rdr.GetBoolean(1), rdr.GetString(2));
            }
            con.Close();
           
        }

        public void ApproveOrder(int orderId)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";


            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "update orderconfirmation set confirmation = 'true' where oid = "  + orderId;
            using var cmd = new NpgsqlCommand(sql, con);
            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }
                
        public void CreateNewDiscount(string dcode, int dpercentage, string dreason)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";


            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call creatediscount(@dcodein, @dpercentagein, @dreasonin)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@dcodein", dcode);
            cmd.Parameters.AddWithValue("@dpercentagein", dpercentage);
            cmd.Parameters.AddWithValue("@dreasonin", dreason);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void CreateNewDiscountHistory(DateOnly startDate, DateOnly endDate, string dcode, string pcode)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            var transaction = con.BeginTransaction();

            string sql = "call adddiscounthistory(@dhdatestart, @dhdateend, @dcode, @pcode)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@dhdatestart", startDate);
            cmd.Parameters.AddWithValue("@dhdateend", endDate);
            cmd.Parameters.AddWithValue("@dcode", dcode);
            cmd.Parameters.AddWithValue("@pcode", pcode);

            int affected = cmd.ExecuteNonQuery();

            transaction.Commit();
            con.Close();
        }

        public void SeeAllDiscountHistory()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "select distinct(p.pcode), p.pname, d.dhdatestart, d.dhdateend, disc.dreason, p.pprice, disc.dpercentage, ((100-disc.dpercentage)/100 *p.pprice) as newprice from product as p join discounthistory as d on p.pcode = d.pcode join discount as disc on disc.dcode = d.dcode order by p.pcode";
            //string sql = "select p.pcode, p.pname, d.dhdatestart, d.dhdateend, disc.dreason, p.pprice, disc.dpercentage from product as p join discounthistory as d on p.pcode = d.pcode join discount as disc on disc.dcode = d.dcode join orderlist as o on p.pcode = o.pcode";

            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 20} {4, 20} {5, 10} {6, 10} {7, 10}", " Code  ", "Name", "Start date     ", "End date     ", "Reason", "Price", "          Percentage", "New price");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 20} {4, 20} {5, 10} {6, 10} {7, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetDateTime(2), rdr.GetDateTime(3), rdr.GetString(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7));
            }
            con.Close();
        }

        public void ShowAllProductsWithDiscounts()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "select distinct(p.pcode), p.pname, d.dhdatestart, d.dhdateend, disc.dreason, p.pprice, disc.dpercentage, ((100 - disc.dpercentage) / 100 * p.pprice) as newprice from product as p full join discounthistory as d on p.pcode = d.pcode full join discount as disc on disc.dcode = d.dcode where CURRENT_DATE between d.dhdatestart and dhdateend order by p.pcode";
            //string sql = "select p.pcode, p.pname, d.dhdatestart, d.dhdateend, disc.dreason, p.pprice, disc.dpercentage from product as p join discounthistory as d on p.pcode = d.pcode join discount as disc on disc.dcode = d.dcode join orderlist as o on p.pcode = o.pcode";

            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 20} {4, 20} {5, 10} {6, 10} {7, 10}", " Code  ", "Name", "Start date     ", "End date     ", "Reason", "Price", "          Percentage", "New price");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 20} {4, 20} {5, 10} {6, 10} {7, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetDateTime(2), rdr.GetDateTime(3), rdr.GetString(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7));
            }
            con.Close();
        }

        public void Calculatefullprice(int orderid)
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = $" select p.pprice, d.dpercentage, o.oquantity from product as p join orderlist as o on o.pcode = p.pcode full join discounthistory as disc on disc.pcode = p.pcode full join discount as d on d.dcode = disc.dcode where o.oid = {orderid}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            float sum = 0;

            while (rdr.Read())
            {
               
                if (rdr.IsDBNull(1))
                {
                    sum += rdr.GetInt32(0) * rdr.GetInt32(2);
                }
                else
                {
                    float percentage = rdr.GetInt32(1);
                    float adjustedPercentage = percentage / 100;
                    sum += (rdr.GetInt32(0) * rdr.GetInt32(2)) * (1 - adjustedPercentage);
                }

            }

            Console.WriteLine("Total sum of order: " + sum);
            con.Close();
        }

        public void SeeAllDiscounts()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "select * from discount";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();


            Console.WriteLine("{0, 10} {1, 10} {2, 10} ", "DiscountCode", "Percentage", "Reason");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", rdr.GetString(0), rdr.GetFloat(1), rdr.GetString(2));
            }
            con.Close();
        }

        public void FullPriceForOrder()
        {

        }

        public void ShowCustomersAll()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Customer Order by fname";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
                       
            Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10} {5, 10} {6, 10} {7, 10}", "Name", "Lastname", "Email", "Address", "City", "Country", "Phone");

            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10} {3, 10} {4, 10} {5, 10} {6, 10} {7, 10}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6));
            }

            con.Close();
        }

        public void ShowSuppliersAll()
        {
            var cs = "Host=pgserver.mau.se;Username=an5238;Password=wilhay09;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM Supplier Order by id";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10} ", "Code", "PhoneNR", "Address");

            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }

            con.Close();
        }

        public void SeeProductsbyOrderId(int search)
        {
            var cs = "Host=pgserver.mau.se;Username=am9046;Password=313rfb57;Database=onlinestorex";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM orderlist where oid = " +search + "order by pcode";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("{0, 10} {1, 10} {2, 10}", "orderId", "Product code", "Quantity");
            while (rdr.Read())
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
            }
            con.Close();
        }
        
    }
}

