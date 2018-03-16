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

        SimulationManager(DataModelComet cometData)
        {
            this.comet = new Comet(cometData);
            dataProvider = new DataManager("data.txt");
            allParticles = new List<Particle>();
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
                    comet.AddNewLayer(allParticles);
                    this.UpdateParticles();

                    currData = dataProvider.NextData();
                }

            }
            else
            {
                MessageBox.Show("Error in the data file");
            }
        }

        private void BlackenBitmap(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    img.SetPixel(i, j, Color.Black);
                }
            }
        }

        public void Print()
        {
            int width = (int)(allParticles[allParticles.Count - 1].X) + 100;
            int height = (int)(allParticles[allParticles.Count - 1].Y) + 200;

            Bitmap image = new Bitmap(width, height);

            this.BlackenBitmap(image);

            foreach (var particle in allParticles)
            {
                //to add difference in color
                image.SetPixel((int)particle.X, (int)particle.Y, Color.White);
            }

            image.Save("Simulation-" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
        }
    }
}
