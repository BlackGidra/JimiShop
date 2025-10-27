using System;
using System.Collections.Generic;

class Program
{
    public static void Main(String[] args)
    {
        //Welcome customer ---
        //Say about special offer, buy 2 pies get one free ???
        //Show menu ----
        //Ask what user wants to order ---
        //Get order ---
        //Get Quantity ---
        //Show price --
        //Ask to confirm --
        //Go back to the menu ---
        //show total price and order ---

        Menu[] menu = new Menu[] {
            new Menu { Name = "1 - Scotch Eggs", Price = 0.89m },
            new Menu { Name = "2 - Pork Pies", Price = 0.76m },
            new Menu { Name = "3 - Macaroni Pie", Price = 1.49m },
            new Menu { Name = "4 - Steak and Gravy Pie", Price = 1.55m },
            new Menu { Name = "5 - Scotch Pie", Price = 1.20m },
            new Menu { Name = "6 - Sausage Roll", Price = 0.99m },
            new Menu { Name = "7 - Onion Bridie", Price = 1.39m },
            new Menu { Name = "8 - Quiche Tarts", Price = 1.45m }
        };
        List<Order> orders = new List<Order>();
        decimal totalPrice = 0;

        Console.WriteLine("Hello!");
        Console.WriteLine("Welcome to Pete Porker's Pie Emporium!");

        while (true) {
            Console.WriteLine(" ");
            Console.WriteLine("Look at the menu and choose what you want to order");
            Console.WriteLine("If nothing, enter '0'");
            Console.WriteLine(" ");

            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Name} - £{item.Price:F2}");
            }

            Console.WriteLine("\nWhat do you want to order?");
            Console.Write("Enter the number: ");
            int orderNum = int.Parse(Console.ReadLine());

            if (orderNum == 0) {
                Console.WriteLine("Your order:");
                foreach (var ordered in orders)
                {
                    Console.WriteLine($"{ordered.Name} x{ordered.Quantity} - £{totalPrice:F2}");
                }
                Console.WriteLine($"Total price: £{totalPrice:F2}");
                break;
            }

                Console.Write("How many? ");
            int quantity = int.Parse(Console.ReadLine());

            var chosen = menu[orderNum - 1];
            decimal itemsPrice = chosen.Price * quantity;

            if (orderNum == 2 && quantity > 2 || orderNum == 3 && quantity > 2 ||
                    orderNum == 4 && quantity > 2 || orderNum == 5 && quantity > 2)
            {
                itemsPrice -= chosen.Price;
            }

            Console.WriteLine($"You get {chosen.Name} for £{itemsPrice:F2}");
            Console.Write("Is that right? (YES/NO): ");
            string conf = Console.ReadLine();

            if (conf.ToUpper() == "YES")
            {
                orders.Add(new Order
                {
                    Name = chosen.Name,
                    Price = itemsPrice,
                    Quantity = quantity
                });
                totalPrice += itemsPrice;
                Console.WriteLine("Item added to your order!");
            }

            Console.WriteLine("Your current order:");
            foreach (var ordered in orders)
            {
                Console.WriteLine($"{ordered.Name} x{ordered.Quantity} - £{totalPrice:F2}");
            }
            Console.WriteLine($"Total price: £{totalPrice:F2}");
        }
    }

    public class Menu
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

