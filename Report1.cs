using System;
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
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=SHUber-ProjectDatabaseandSystemModelling.db.db");
            conn.Open();

            string query = "SELECT d.Driver_ID AS 'Driver ID', " +
            "d.Driver_Fname || \" \" || d.Driver_Lname AS 'Driver Name', " +
            "count(Journey_ID) AS 'Number of Journeys with or more than a 4.5 Rating' " +
            "FROM Journey j " +
            "INNER JOIN Driver d on (j.Driver_ID = d.Driver_ID) " +
            "WHERE Driver_Rating >= 4.5 " +
            "GROUP BY j.Driver_ID " + "" +
            "ORDER BY count(*) DESC " +
            "LIMIT 5;";

            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            Series series = new Series("Top 5 Drivers");
            series.ChartType = SeriesChartType.Bar;
            series.XValueMember = "Driver Name";
            series.YValueMembers = "Number of Journeys with or more than a 4.5 Rating";
            series["BarLabelStyle"] = "Outside";
            series["BarLineColor"] = "Black";
            series.IsValueShownAsLabel = true;

            chart1.Series.Add(series);

            chart1.DataSource = dt;
            chart1.DataBind();

            chart1.ChartAreas["MainArea"].AxisX.Title = "Driver Name";
            chart1.ChartAreas["MainArea"].AxisY.Title = "Number of Journeys with or more than a 4.5 Rating";

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
