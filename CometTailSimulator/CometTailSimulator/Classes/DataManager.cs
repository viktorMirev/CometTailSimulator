using System.Collections.Generic;
using System.IO;

namespace CometTailSimulator.Classes
{
    class DataManager
    {
        private string dir;
        private List<DataModel> data;
        private int dataIndex;

        DataManager(string dir)
        {
            this.dataIndex = 0;
            this.dir = dir;
        }

        public void ReadData()
        {
            var data = File.ReadAllLines(dir);
            // split devide create the new data list
           
        }

        public DataModel NextData()
        {
            return data[this.dataIndex++];
        }
    }
}
