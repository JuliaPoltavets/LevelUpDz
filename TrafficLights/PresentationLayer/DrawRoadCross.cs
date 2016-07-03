using System.ComponentModel;
using TrafficLights.DataModel;

namespace TrafficLights.PresentationLayer
{
    public class DrawRoadCross
    {
       // [DefaultValue()]
        public char VerticalBorderSymbol { get; set; }
        public char HorizontalBorderSymbol { get; set; }
        public int RoadWidth { get; set; }
        public int PlaygroundWidth { get; set; }
        public int PlaygroundHeight { get; set; }

      //  public DrawRoadCross()

    }
}