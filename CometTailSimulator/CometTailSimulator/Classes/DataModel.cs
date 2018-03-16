namespace CometTailSimulator.Classes
{
    class DataModel
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
            private set => distance = value/Constants.scale;
        }
        public double SunAngle      { get => sunAngle; private set => sunAngle = value; }
        public double VelocityAngle { get => velocityAngle;private set => velocityAngle = value; }
        public double VelocitySpeed { get => velocitySpeed;private set => velocitySpeed = value; }
    }
}
