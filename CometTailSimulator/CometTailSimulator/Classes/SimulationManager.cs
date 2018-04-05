using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private void WhiteIt(Bitmap b)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    b.SetPixel(i, j, Color.White);
                }
            }
        }
        

        public void Print()
        {
            
         //  var width = 5000;
         //  int height = 3000;
         //  int offsetX = 2000;
         //  int offsetY = 500;

            Bitmap testImg = new Bitmap(Constants.pixelXoffSet*3, Constants.pixelYoffSet*4);

            //WhiteIt(testImg);

            //this.WhiteIt(testImg);
            //finding the last comet coordinates
            int currCometX = this.cometTrail.ElementAt(this.cometTrail.Count-1).Key;
            int currCometY = this.cometTrail.ElementAt(this.cometTrail.Count - 1).Value;
            //everything outside these coordinates +- offsets wont we considered in the bitmap

            int minX = currCometX - Constants.pixelXoffSet;
            int maxX = currCometX + (int)(Constants.pixelXoffSet*2);
            int minY = currCometY - Constants.pixelYoffSet;
            int maxY = currCometY + (int)(Constants.pixelYoffSet*3);

            testImg.SetPixel(Constants.pixelXoffSet, Constants.pixelYoffSet, Color.Red);

            foreach (var item in this.cometTrail)
            {
                if(item.Key>minX && item.Key<maxX && item.Value>minY && item.Value<maxY)
                {
                    testImg.SetPixel(item.Key - minX, item.Value - minY, Color.Yellow);
                }
               
            }

            


            foreach (var particle in allParticles.OrderBy(a => a.Size))
            {


                //Color compare = Color.FromArgb(190, 190, 190);
              //  Color currColor = testImg.GetPixel((int)particle.X+offsetX, (int)particle.Y+offsetY);
               // uint number = (uint)((compare.A << 24) | (compare.R << 16) | (compare.G << 8) | (compare.B));
               //if (currColor.ToArgb()>= number)
               //    {
               //    continue;
               //    }
               // if (particle.X < 0 || particle.X > width || particle.Y < 0 || particle.Y > height ) continue;

                //for black background
                int colorIndex = (int)(64 + 19.1 * particle.Size);

                //for white background 
                //colorIndex = 250 - colorIndex;

                Color myColor = Color.FromArgb(colorIndex,colorIndex,colorIndex);
                //
                //if (particle.Size >= 3 && particle.Size <= 5) currColor = Color.Aqua;
                //if (particle.Size > 5) currColor = Color.Blue;
                //

                //testImg.SetPixel((int)particle.X+offsetX, (int)particle.Y + offsetY, myColor);
                if (particle.X > minX && particle.X < maxX && particle.Y > minY && particle.Y < maxY)
                {
                    testImg.SetPixel((int)(particle.X - minX),(int)( particle.Y - minY), myColor);
                }



            }
            testImg.Save("Sim" + DateTime.Now.Ticks + ".bmp");
            MessageBox.Show("DONE!");
            
        }
    }
}