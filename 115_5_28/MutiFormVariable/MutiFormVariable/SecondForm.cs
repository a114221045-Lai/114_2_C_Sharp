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
    public partial class SecondForm : Form
    {
        public MainForm mainForm;
        public SecondForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        public void SecondForm_Load(object sender, EventArgs e)
        {
            label1.Text = mainForm.Username;
        }
    }
}
