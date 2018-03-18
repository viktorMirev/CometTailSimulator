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
            DataModelComet comet = new DataModelComet(1000, 1.5,15, 34,0.1, 50, 5, 9, 2);
           // DataModelComet comet = new DataModelComet(5000, 1.5, 15, 34, 0.1, 50, 25, 9, 2);
            SimulationManager m = new SimulationManager(comet);
            m.Start();
            m.Print();
        }
    }
}
