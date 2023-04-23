using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface1
{
    public partial class InfoEquipment : Form
    {
        public InfoEquipment()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Данные не найденны");
            Close();
        }
    }
}
