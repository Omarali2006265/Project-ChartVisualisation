using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_ChartVisualisation
{
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=SHUber-ProjectDatabaseandSystemModelling.db.db");
            conn.Open();

            string query = "SELECT c.Cust_ID, c.Cust_Fname || \" \" || c.Cust_Lname AS \"Customer Name\", " +
               "COUNT(j.Journey_ID) AS total_rides_last_3_months, " +
               "ROUND(SUM(j.Cost) / 3) AS avg_monthly_spend, " +
               "COUNT(CASE WHEN r.Cust_Rating = 5 THEN 1 END) AS five_star_ratings " +
               "FROM Customer c " +
               "INNER JOIN Journey j ON (c.Cust_ID = j.Cust_ID) " +
               "INNER JOIN Rating r ON (j.Journey_ID = r.Journey_ID) " +
               "WHERE j.Journey_Date_Time BETWEEN '2025-08-01' AND '2025-10-31' " +
               "GROUP BY c.Cust_ID, \"Customer Name\" " +
               "HAVING COUNT(j.Journey_ID) >= 3 " +
               "AND (SUM(j.Cost) / 3) > 100 " +
               "AND COUNT(CASE WHEN r.Cust_Rating = 5 THEN 1 END) >= 5 " +
               "ORDER BY total_rides_last_3_months DESC " +
               "LIMIT 5;";





            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            Series series = new Series("Top 5 Customers");
            series.ChartType = SeriesChartType.Bar;
            series.XValueMember = "Customer Name";
            series.YValueMembers = "total_rides_last_3_months";
            series["BarLabelStyle"] = "Outside";
            series["BarLineColor"] = "Black";
            series.IsValueShownAsLabel = true;

            chart1.Series.Add(series);

            chart1.DataSource = dt;
            chart1.DataBind();

            chart1.ChartAreas["MainArea"].AxisX.Title = "Customer Name";
            chart1.ChartAreas["MainArea"].AxisY.Title = "Rides Taken while spending £100+ in the last 3 months across all 5-star rated rides";

            conn.Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mn = new MainMenu();
            mn.ShowDialog();
        }
    }
}

