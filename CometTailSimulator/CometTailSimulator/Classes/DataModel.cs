using System.Text;

namespace CometTailSimulator.Classes
{
    public class DataModel
    {
        private double distance;
        private double sunAngle;
        private double velocityAngle;
        private double velocitySpeed;

        public DataModel(double dis, double sun, double velA, double velS)
        {
            this.Distance = dis;
            this.SunAngle = sun;
            this.VelocityAngle = velA;
            this.VelocitySpeed = velS;
        }

        public double Distance
        {
            get => distance;
            private set => distance = value*Constants.AU/Constants.scale;
        }
        public double SunAngle      { get => sunAngle; private set => sunAngle = value; }
        public double VelocityAngle { get => velocityAngle;private set => velocityAngle = value; }
        public double VelocitySpeed { get => velocitySpeed;private set => velocitySpeed = value; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(distance);
            output.Append("      ");
            output.Append(sunAngle);
            output.Append("      ");
            output.Append(velocityAngle);
            output.Append("      ");
            output.Append(velocitySpeed);

            return output.ToString();
        }
    }
}
