using plantdbfirst_console.Models;

namespace plantdbfirst_console.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("--- Plant Management System ---");
                Console.WriteLine("1. View All Plants");
                Console.WriteLine("2. Add New Plant");
                Console.WriteLine("3. Update Plant");
                Console.WriteLine("4. Delete Plant");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewPlants();
                        break;
                    case "2":
                        AddPlant();
                        break;
                    case "3":
                        UpdatePlant();
                        break;
                    case "4":
                        DeletePlant();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ViewPlants()
        {
            using var context = new KaniniContext();
            var plants = context.Plants.ToList();

            Console.WriteLine("--- List of Plants ---");
            foreach (var plant in plants)
            {
                Console.WriteLine($"{plant.PlantId} - {plant.PlantName} - Price: {plant.Price} - Quantity: {plant.Quantity}");
            }
        }

        static void AddPlant()
        {
            using var context = new KaniniContext();

            Console.Write("Enter Plant Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            var plant = new Plant
            {
                PlantName = name,
                Price = price,
                Quantity = qty
            };

            context.Plants.Add(plant);
            context.SaveChanges();

            Console.WriteLine(" Plant added successfully!");
        }

        static void UpdatePlant()
        {
            using var context = new KaniniContext();

            Console.Write("Enter Plant ID to Update: ");
            int id = int.Parse(Console.ReadLine());

            var plant = context.Plants.Find(id);
            if (plant != null)
            {
                Console.Write("Enter New Plant Name: ");
                plant.PlantName = Console.ReadLine();

                Console.Write("Enter New Price: ");
                plant.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter New Quantity: ");
                plant.Quantity = int.Parse(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine(" Plant updated successfully!");
            }
            else
            {
                Console.WriteLine(" Plant not found.");
            }
        }

        static void DeletePlant()
        {
            using var context = new KaniniContext();

            Console.Write("Enter Plant ID to Delete: ");
            int id = int.Parse(Console.ReadLine());

            var plant = context.Plants.Find(id);
            if (plant != null)
            {
                context.Plants.Remove(plant);
                context.SaveChanges();
                Console.WriteLine(" Plant deleted successfully!");
            }
            else
            {
                Console.WriteLine(" Plant not found.");
            }
        }
    }
}
