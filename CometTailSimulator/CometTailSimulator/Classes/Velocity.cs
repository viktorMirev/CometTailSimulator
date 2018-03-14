namespace CometTailSimulator.Classes
{
    public class Velocity
    {
        private double x;
        private double y;
        public Velocity(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Velocity Add(Velocity second)
        {
            double newX = this.X + second.X;
            double newY = this.Y + second.Y;

            return new Velocity(newX, newY);
        }
    }
}
