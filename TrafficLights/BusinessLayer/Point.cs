namespace TrafficLights.BusinessLayer
{
    public class Point
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public Point(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }
    }
}