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

            DrawRoadBorder(leftTopCoords, leftBottomCoords, roadCross.VerticalBorderSymbol);
            DrawRoadBorder(rightTopCoords, rightBottomCoords, roadCross.VerticalBorderSymbol);

            DrawRoadBorder(topLeftCoords, topRightCoords, roadCross.HorizontalBorderSymbol);
            DrawRoadBorder(bottomLeftCoords, bottomRightCoords, roadCross.HorizontalBorderSymbol);
        }

        public static void DrawRoadBorder(Point from, Point to, char symbol)
        {
            if ((from.XCoord < to.XCoord)&&(from.YCoord == to.YCoord))
            {
                for (int x = from.XCoord; x < to.XCoord; x++)
                {
                    Console.SetCursorPosition(x, from.YCoord);
                    Console.Write(symbol);
                }

            }
            if ((from.YCoord < to.YCoord) && (from.XCoord == to.XCoord))
            {
                for (int y = from.YCoord; y < to.YCoord; y++)
                {
                    Console.SetCursorPosition(from.XCoord, y);
                    Console.Write(symbol);
                }
            }
        }
    }
}             