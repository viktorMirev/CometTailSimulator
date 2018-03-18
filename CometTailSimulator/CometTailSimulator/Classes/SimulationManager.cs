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
                    comet.AddNewLayer(allParticles, cometTrail);

                    this.UpdateParticles();

                    currData = dataProvider.NextData();
                }

            }
            else
            {
                MessageBox.Show("Error in the data file");
            }
        }


        public void Print()
        {
            
            var width = 6000;
            int height = 4000;
            int offset = 2000;
            Bitmap testImg = new Bitmap(width, height);
            testImg.SetPixel(Constants.centralMassX, Constants.centralMassY + offset, Color.Red);
            foreach (var item in this.cometTrail)
            {
                testImg.SetPixel(item.Key, item.Value + offset, Color.Yellow);
            }




            foreach (var particle in allParticles)
            {
               //if (particle.X < 0 || particle.X > width || particle.Y < 0 || particle.Y > height ) continue;
                
                Color currColor = Color.White;
                if (particle.Size >= 3 && particle.Size <= 5) currColor = Color.Aqua;
                if (particle.Size > 5) currColor = Color.Blue;
                

                testImg.SetPixel((int)particle.X, (int)particle.Y + offset, currColor);
                


            }
            testImg.Save("Sim" + DateTime.Now.Ticks + ".jpg");
            MessageBox.Show("DONE!");
            
        }
    }
}