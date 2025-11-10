using System;

namespace GardenGrowthGUI
{
    public class Plant
    {
        public string Name { get; }
        public int Day { get; private set; }
        public int Height { get; private set; }
        public int WaterLevel { get; private set; }   // 0~10
        public int GrowthStage { get; private set; }  // 0~5
        public bool IsAlive { get; private set; } = true;

        public string StageText => GrowthStage switch
        {
            0 => "種子",
            1 => "發芽",
            2 => "幼苗",
            3 => "成長中",
            4 => "開花",
            5 => "成熟",
            _ => "未知"
        };

        public Plant(string name)
        {
            Name = name;
            Day = 1;
            Height = 0;
            WaterLevel = 5;
            GrowthStage = 0;
        }

        // --- 新增簡易接口（與舊按鈕事件相容）---
        public void AddWater()
        {
            if (!IsAlive) return;
            WaterLevel = Math.Min(10, WaterLevel + 1);
        }

        public void AddSun()
        {
            if (!IsAlive) return;

            if (WaterLevel >= 2)
            {
                Height += Math.Min(3, GrowthStage + 1);
                WaterLevel = Math.Max(0, WaterLevel - 2);

                if (Height >= (GrowthStage + 1) * 10 && GrowthStage < 5)
                    GrowthStage++;
            }
            else
            {
                // 缺水狀態曬太陽，植物會乾枯
                WaterLevel = Math.Max(0, WaterLevel - 1);
                if (WaterLevel == 0)
                    IsAlive = false;
            }
        }

        // --- 核心模擬邏輯 ---
        public void Water()
        {
            if (!IsAlive) return;
            WaterLevel = Math.Min(10, WaterLevel + 2);
        }

        public void Sun()
        {
            if (!IsAlive) return;

            if (WaterLevel >= 3)
            {
                Height += Math.Min(3, GrowthStage + 1);
                WaterLevel = Math.Max(0, WaterLevel - 3);

                if (Height >= (GrowthStage + 1) * 10 && GrowthStage < 5)
                    GrowthStage++;
            }
            else
            {
                WaterLevel = Math.Max(0, WaterLevel - 1);
                if (WaterLevel == 0)
                    IsAlive = false;
            }
        }

        public void NextDay()
        {
            if (!IsAlive) return;
            Day++;

            // 蒸散導致水分下降
            WaterLevel = Math.Max(0, WaterLevel - 1);
            if (WaterLevel == 0)
                IsAlive = false;

            // 每天自然微幅成長
            if (IsAlive)
                Height += GrowthStage;
        }
    }
}
