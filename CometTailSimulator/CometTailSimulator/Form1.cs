using CometTailSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CometTailSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataModelComet comet = new DataModelComet(200, 1.5, 10, 60, 0.5, 1.5, 100, 7, 2);
            SimulationManager m = new SimulationManager(comet);
            m.Start();
            m.Print();
        }
    }
}
