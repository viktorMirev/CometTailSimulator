using CometTailSimulator.Classes;
using System;
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
            //DataModelComet comet = new DataModelComet(1000, 1.5,15, 34,0.1, 50, 5, 9, 2);
            // DataModelComet comet = new DataModelComet(5000, 1.5, 15, 34, 0.1, 50, 25, 9, 2);
            //DataModelComet comet = new DataModelComet(500, 2.5, 20, 35, 0.5, 50, 10, 9, 0.6);


            //SCHWASSMAN WACHMAN
            // DataModelComet comet = new DataModelComet(61.95, 2.5, 30, 35, 0.2, 1, 50, 10, 0.6);

            //ASASSN1
            //DataModelComet comet = new DataModelComet(500, 2.5, 20, 35, 0.2, 1, 100, 10, 0.6);

            //McNAUGHT
            // DataModelComet comet = new DataModelComet(255, 0.3, 10, 60, 0.2, 0.0, 40, 9, 0.6);

            DataModelComet comet = new DataModelComet(555, 0.6, 10, 60, 0.2, 0.0, 40, 9, 0.6);

            SimulationManager m = new SimulationManager(comet);
            m.Start();
            m.Print();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
