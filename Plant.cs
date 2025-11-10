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
            Height = 1;   // 初始高度
            Health = 100; // 初始健康
        }

        // 最簡單邏輯：平均越高，長越快；太低會掉血
        public void Grow(int sun, int water, int fert)
        {
            int balance = (sun + water + fert) / 3; // 0–10
            if (balance >= 6)
            {
                Height += balance / 2;             // +0~5
                Health = Math.Min(100, Health + 2);
            }
            else
            {
                Height += 1;                       // 低配也會微增
                Health = Math.Max(0, Health - 5);  // 但健康下降
            }
        }
    }
}
