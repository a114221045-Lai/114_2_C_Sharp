using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutiFormVariable
{
    public partial class MainForm : Form
    {
        private string username = "Jessica";

        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecondForm secondForm = new SecondForm(this);
            secondForm.Show();
        }
    }
}
