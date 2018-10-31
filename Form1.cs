using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBTest
{
    public partial class Form1 : Form
    {
        MongoDBHelper MDB = new MongoDBHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            MDB.ConnectDB();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            MDB.Insert();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            MDB.Query();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            MDB.Delete();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            MDB.Update();
        }


    }
}
