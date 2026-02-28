using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Session6.Assessment1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session8
{
    //Project
    //Invoice Generation & Export System

    //System we have list of product which has name and price(don’t think about count)
    //User can create order by buying at least one product
    //Build a system that generates invoices for customer orders and
    //supports exporting them in different formats(PDF, Excel, JSON, XML,console.
    //List some product and ask user to enter which product need and number of items
    //user enter the product number and count

    //create order
    //ask user to enter export format for the invoice(1: PDF, 2: Excel, 3: JSON , 4 console):
    //if user choose PDF or Excel or Json
    //display procecing from PDF or Excel or Json
    //else if user choose console
    //display invoice in console with formate like
    //// datetime (today and hours)
    //// number item price totla
    //// 2 keybord 10$ 20$
    //// 3 mouses 20$ 60$
    //// 1 ipone 100$ 100$
    //// total = 180$
    //
    //DateTime.Now
    //=================================================================================================
    //|         Item         |           Qty            |           Price         |       Total       |
    //=================================================================================================
    //|Keyboard              |1                         |10                       |10                 |
    //|Mouse                 |2                         |20                       |40                 |
    //|Iphone                |3                         |100                      |300                |
    //|===============================================================================================|
    //|                                                                           |350                |
    //|===============================================================================================|
    public class Assessment1
    {



        public Assessment1()
        {
            Order Order = new Order();
            List<Product> Products = new List<Product>();

            InitializeProducts(Products);
            ShowMainMenu(Order, Products);
        }

        void ShowMainMenu(Order Order, List<Product> Products)
        {
            Console.WriteLine("Invoice Generation & Export System");
            Console.WriteLine(Environment.NewLine);
            if (Order.Details.Count == 0)
                Console.WriteLine("1. Create Order");
            else
                Console.WriteLine("1. Edit Order");

            Console.WriteLine("2. Export Invoice");
            Console.WriteLine("3. Exit");

            AskForMainMenuOperation(Order, Products);
        }

        void AskForMainMenuOperation(Order Order, List<Product> Products)
        {
            while (true)
            {
                Console.Write("Please enter your choice:");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int operation))
                {
                    switch (operation)
                    {
                        case (int)MainMenuOperations.CreateOrder:
                            AskForOrderOperation(Order, Products);
                            break;
                        case (int)MainMenuOperations.ExportInvoice:
                            AskForExportOperation(Order, Products);
                            break;
                        case (int)MainMenuOperations.Exit:
                            Environment.Exit(0);
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        void AskForOrderOperation(Order Order, List<Product> Products)
        {
            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Exit");
                Console.Write("Please enter your choice:");
                var line = Console.ReadLine();
                if (int.TryParse(line, out int operation))
                {
                    switch (operation)
                    {
                        case (int)OrderOperations.AddProduct:
                            AskForProductId(Order, Products);
                            break;
                        case (int)OrderOperations.Exit:
                            ShowMainMenu(Order, Products);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        enum OrderOperations
        {
            AddProduct = 1,
            Exit = 2
        }

        void AskForProductId(Order Order, List<Product> Products)
        {
            while (true)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    Console.WriteLine($"{Products[i].Id}. {Products[i].Name} - {Products[i].Price}$");
                }
                Console.Write("Please enter the product id:");
                var line = Console.ReadLine();
                if (int.TryParse(line, out int productId))
                {
                    var product = Products.FirstOrDefault(x => x.Id == productId);
                    if (product != null)
                    {
                        AskForProductQty(Order, product);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Product not found. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        void AskForProductQty(Order Order, Product product)
        {
            while (true)
            {
                Console.Write("Please enter the product quantity:");
                var line = Console.ReadLine();
                if (double.TryParse(line, out double qty))
                {
                    Order.AddOrderDetail(new OrderDetail(product, qty));
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        void AskForExportOperation(Order Order, List<Product> Products)
        {
            if (Order.Details.Count > 0)
            {
                while (true)
                {
                    ExportInvoice exportInvoice;

                    Console.WriteLine("1. PDF");
                    Console.WriteLine("2. Excel");
                    Console.WriteLine("3. JSON");
                    Console.WriteLine("4. Console");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose Format: ");

                    var line = Console.ReadLine();
                    if (int.TryParse(line, out int result))
                    {
                        switch (result)
                        {
                            case (int)ExportOperations.PDF:
                                exportInvoice = new PDFExportInvoice(Order);
                                exportInvoice.Process();
                                break;
                        }
                        switch (result)
                        {
                            case (int)ExportOperations.Excel:
                                exportInvoice = new ExcelExportInvoice(Order);
                                exportInvoice.Process();
                                break;
                        }
                        switch (result)
                        {
                            case (int)ExportOperations.JSON:
                                exportInvoice = new JSONExportInvoice(Order);
                                exportInvoice.Process();
                                break;
                        }
                        switch (result)
                        {
                            case (int)ExportOperations.Console:
                                exportInvoice = new ConsoleExportInvoice(Order);
                                exportInvoice.Process();
                                break;
                        }
                        switch (result)
                        {
                            case (int)ExportOperations.Exit:
                                ShowMainMenu(Order, Products);
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No details to print.");
            }
        }



        enum MainMenuOperations
        {
            CreateOrder = 1,
            ExportInvoice = 2,
            Exit = 3
        }

        enum ExportOperations
        {
            PDF = 1,
            Excel = 2,
            JSON = 3,
            Console = 4,
            Exit = 5
        }
        public void InitializeProducts(List<Product> Products)
        {
            Products.Add(new Product(1, "Keyboard", 10));
            Products.Add(new Product(2, "Mouse", 20));
            Products.Add(new Product(3, "Iphone", 100));
        }
    }

    public class Order
    {
        public List<OrderDetail> Details { get; private set; } = new List<OrderDetail>();
        public DateTime CreatedOn { get; private set; } = DateTime.MinValue;
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (Details.Count == 0)
                CreatedOn = DateTime.Now;
            Details.Add(orderDetail);
        }
        public double GetTotalPrice()
        {
            return Details.Sum(x => x.GetTotalPrice());
        }
    }
    public class OrderDetail
    {
        public Product Item { get; private set; }
        public double Qty { get; private set; }

        public OrderDetail(Product item, double qty)
        {
            Item = item;
            Qty = qty;
        }

        public double GetTotalPrice()
        {
            return Item.Price * Qty;
        }

    }
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public abstract class ExportInvoice
    {
        protected Order Order;
        public abstract void Process();
    }

    public class PDFExportInvoice : ExportInvoice
    {
        public PDFExportInvoice(Order order)
        {
            Order = order;
        }
        public override void Process()
        {
            Console.WriteLine("Processing PDF...............");
        }
    }

    public class ExcelExportInvoice : ExportInvoice
    {
        public ExcelExportInvoice(Order order)
        {
            Order = order;
        }
        public override void Process()
        {
            Console.WriteLine("Processing Excel..........");
        }
    }

    public class JSONExportInvoice : ExportInvoice
    {
        public JSONExportInvoice(Order order)
        {
            Order = order;
        }
        public override void Process()
        {
            Console.WriteLine("Processing JSON...........");
        }
    }

    public class ConsoleExportInvoice : ExportInvoice
    {
        public ConsoleExportInvoice(Order order)
        {
            Order = order;
        }
        public override void Process()
        {
            const int itemLength = 22;
            const int qtyLength = 26;
            const int priceLength = 25;
            const int totalLine = 19;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Order.CreatedOn);
            Console.WriteLine("=================================================================================================");
            Console.WriteLine("|         Item         |           Qty            |           Price         |       Total       |");
            Console.WriteLine("=================================================================================================");
            foreach (var detail in Order.Details)
                Console.WriteLine($"|{detail.Item.Name,-itemLength}|{detail.Qty,-qtyLength}|{detail.Item.Price,-priceLength}|{detail.GetTotalPrice(),-totalLine}|");
            //Console.WriteLine("=============================================================================");
            Console.WriteLine("|===============================================================================================|");
            Console.WriteLine($"|                                                                           |{Order.GetTotalPrice(),-totalLine}|");
            Console.WriteLine("|===============================================================================================|");

        }
    }
}