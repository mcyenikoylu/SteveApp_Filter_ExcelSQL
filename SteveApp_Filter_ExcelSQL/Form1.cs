using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteveApp_Filter_ExcelSQL
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conn.ConnDBLocal(true);

            //Cursor.Current = Cursors.WaitCursor;
            SqlCommand sqlCmd = new SqlCommand("S_Output", Conn.dbLocal);
            sqlCmd.CommandTimeout = 30000;
            //sqlCmd.Parameters.AddWithValue("@ID", ComapnyID);
            //sqlCmd.Parameters.AddWithValue("@Cell", cell);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            //gridControl1.DataSource = ds;
            //gcDashboard.ItemsSource = ds;

            Conn.ConnDBLocal(false);

            gridControl1.DataSource = dt;
        }
    }
}
