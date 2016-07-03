using System;
using System.ComponentModel;
using TrafficLights.BusinessLayer;

namespace TrafficLights.PresentationLayer
{
    public class DrawingRoadCross
    {
        public static void DrawRoadCross(RoadCross roadCross)
        {
            //vertical Road
            var leftTopCoords = new Point(roadCross.PlaygroundWidth/2 - roadCross.RoadWidth/2, 0);
            var rightTopCoords = new Point(leftTopCoords.XCoord + roadCross.RoadWidth, 0);
            var leftBottomCoords = new Point(leftTopCoords.XCoord, roadCross.PlaygroundHeight);
            var rightBottomCoords = new Point(rightTopCoords.XCoord, roadCross.PlaygroundHeight);

            //horizontal road
            var topLeftCoords = new Point(0, roadCross.PlaygroundHeight/2 - roadCross.RoadWidth/2);
            var bottomLeftCoords = new Point(0, topLeftCoords.YCoord + roadCross.RoadWidth);
            var topRightCoords = new Point(roadCross.PlaygroundWidth, topLeftCoords.YCoord);
            var bottomRightCoords = new Point(roadCross.PlaygroundWidth, bottomLeftCoords.YCoord);
        }

        public static void DrawRoadBorder(Point from, Point to, char symbol)
        {
            Point currentPosition = from;
            while(currentPosition.Equals(to));
        }
    }
}             