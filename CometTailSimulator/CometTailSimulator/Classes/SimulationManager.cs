using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CometTailSimulator.Classes
{
    class SimulationManager
    {
        private DataManager dataProvider;
        private Comet comet;
        private List<Particle> allParticles;

        //TEST SUBJECT
        private List<KeyValuePair<int, int>> cometTrail;

        public SimulationManager(DataModelComet cometData)
        {
            this.comet = new Comet(cometData);
            dataProvider = new DataManager("data.txt");
            allParticles = new List<Particle>();

            //TEST SUBJECT
            this.cometTrail = new List<KeyValuePair<int, int>>();
        }

        private void UpdateParticles()
        {
            foreach (var particle in this.allParticles)
            {
                particle.Update();
            }
        }
        public void Start()
        {
            if (dataProvider.ReadData())
            {
                DataModel currData = dataProvider.NextData();
                while (currData != null)
                {
                    comet.Update(currData);

                    //TEST SUBJECT
                    comet.AddNewLayer(allParticles,cometTrail);

                    this.UpdateParticles();

                    currData = dataProvider.NextData();
                }

            }
            else
            {
                MessageBox.Show("Error in the data file");
            }
        }


        //Actually is always black
        /*private void BlackenBitmap(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    img.SetPixel(i, j, Color.Black);
                }
            }
        }*/

        public void Print()
        {
            Bitmap testImg = new Bitmap(1000, 800);
            testImg.SetPixel(Constants.centralMassX+300, Constants.centralMassY+300, Color.Red);
            foreach (var item in this.cometTrail)
            {
                testImg.SetPixel(item.Key+300, item.Value+300, Color.Yellow);
            }
            
            
            

            foreach (var particle in allParticles)
            {
                //to add difference in color
                testImg.SetPixel((int)particle.X+300,(int)particle.Y+300, Color.White);
            }

            testImg.Save("TestSim.jpg");
            // + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()
        }
    }
}
