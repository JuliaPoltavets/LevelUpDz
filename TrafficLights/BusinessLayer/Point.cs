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

        public bool Equals(Point p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (XCoord == p.XCoord) && (YCoord == p.YCoord);
        }
    }
}