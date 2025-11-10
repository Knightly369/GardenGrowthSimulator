using System;

namespace GardenGrowthSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant plant = new Plant("Sunflower");

            Console.WriteLine("🌱 Welcome to the Garden Growth Simulator!");
            Console.WriteLine("Adjust conditions to help your plant grow.");
            Console.WriteLine("Enter sunlight (0-10), water (0-10), fertilizer (0-10):");

            for (int day = 1; day <= 7; day++)
            {
                Console.WriteLine($"\nDay {day}:");
                Console.Write("☀️ Sunlight: ");
                int sun = Read01();
                Console.Write("💧 Water: ");
                int water = Read01();
                Console.Write("🌾 Fertilizer: ");
                int fert = Read01();

                plant.Grow(sun, water, fert);
                Console.WriteLine($"→ Growth: {plant.Height}cm | Health: {plant.Health}%");
            }

            Console.WriteLine("\n🌻 Simulation complete!");
        }

        static int Read01()
        {
            // 安全讀取 0–10 的整數
            while (true)
            {
                var s = Console.ReadLine();
                if (int.TryParse(s, out var v) && v >= 0 && v <= 10) return v;
                Console.Write("Please enter a number 0–10: ");
            }
        }
    }
}
