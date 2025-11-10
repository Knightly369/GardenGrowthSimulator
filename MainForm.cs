using System;
using System.Windows.Forms;

namespace GardenGrowthSimulator
{
    public partial class MainForm : Form
    {
        private Plant currentPlant;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "請輸入植物名稱並創建植物。";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("請輸入植物名稱！");
                return;
            }

            currentPlant = new Plant(txtName.Text);
            lblStatus.Text = $"🌱 已創建植物：{currentPlant.Name}";
        }

        private void btnGrow_Click(object sender, EventArgs e)
        {
            if (currentPlant == null)
            {
                MessageBox.Show("請先創建植物！");
                return;
            }

            int sun = trackSun.Value;
            int water = trackWater.Value;
            int fert = trackFert.Value;

            currentPlant.Grow(sun, water, fert);
            lblStatus.Text = $"🌻 {currentPlant.GetStatus()}";

            progressHealth.Value = currentPlant.Health;
            lblHealth.Text = $"健康：{currentPlant.Health}%";
        }
    }
}
