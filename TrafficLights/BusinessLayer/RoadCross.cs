namespace TrafficLights.BusinessLayer
{
    public class RoadCross
    {
        public char VerticalBorderSymbol { get; private set; }
        public char HorizontalBorderSymbol { get; private set; }

        public int RoadWidth { get; private set; }
        public int PlaygroundWidth { get; private set; }
        public int PlaygroundHeight { get; private set; }

        public RoadCross(int pgWidth, int pgHeight, int roadWidth, char verSymb = (char)124, char horzSymb = (char)173)
        {
            PlaygroundWidth = pgWidth;
            PlaygroundHeight = pgHeight;
            RoadWidth = roadWidth;
            VerticalBorderSymbol = verSymb;
            HorizontalBorderSymbol = horzSymb;
        } 
    }
}