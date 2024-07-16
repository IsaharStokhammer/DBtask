using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBtask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDataBaseAsync(dataGridView1.Text);
        }




        public async void LoadDataBaseAsync(string name)
        {
            string connectionString2 =
                "Server=DESKTOP-F6TEN9G;" +
                "Database=gest;" +
                "User Id=sa;" +
                "Password=1234;" +
                "Trusted_Connection=true;";

            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                try
                {
                    await connection2.OpenAsync();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [dbo].[gest_table] ", connection2);
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));
                    dataGridView1.DataSource = table;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                }
            }
        }



    }
}
