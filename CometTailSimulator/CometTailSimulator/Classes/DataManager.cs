/*
 *  The basic idea behind this class is to give the possibility for the user to include 
 *  more than 1 files in order to use them simultaniously
 *  this gives the program more flexibility аnd an opportunity to simulate multiple objects at once
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace CometTailSimulator.Classes
{
    class DataManager
    {
        private string directory;
        private List<DataModel> data;
        private int dataIndex;

        public DataManager(string dir)
        {
            this.dataIndex = 0;
            this.directory = dir;
            data = new List<DataModel>();
        }

        public bool ReadData() //tells if the reading was successful
        {
            if (File.Exists(directory))   //file validation
            {
                var rawData = File.ReadAllLines(directory);

                //data validation
                if (rawData.Length == 0) return false;

                foreach (var line in rawData)
                {
                    var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                    //creating new dataModel
                    data.Add(new 
                        DataModel(double.Parse(tokens[0]),double.Parse(tokens[1]), double.Parse(tokens[2]),double.Parse(tokens[3])));
                }
                return true;
            }
            return false;

        }

        public DataModel NextData()
        {
            if (dataIndex == data.Count) return null;

            return data[this.dataIndex++];
        }
    }
}
