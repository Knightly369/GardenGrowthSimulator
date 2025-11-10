using System;

namespace GardenGrowthSimulator
{
    public class Plant
    {
        public string Name { get; }
        public int Height { get; private set; }
        public int Health { get; private set; }

        public Plant(string name)
        {
            Name = name;
            Height = 1;
            Health = 100;
        }

        public void Grow(int sun, int water, int fert)
        {
            int balance = (sun + water + fert) / 3;

            if (balance >= 6)
            {
                Height += balance / 2;
                Health = Math.Min(100, Health + 2);
            }
            else
            {
                Height += 1;
                Health = Math.Max(0, Health - 5);
            }
        }

        public string GetStatus()
        {
            return $"{Name}：高度 {Height}，健康 {Health}";
        }
    }
}
