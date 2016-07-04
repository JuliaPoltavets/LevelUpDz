// © 2015 Sitecore Corporation A/S. All rights reserved.

using System;
using TrafficLights.BusinessLayer;

namespace TrafficLights.PresentationLayer
{
    public class DrawingDirectionArrows
    {
        public static void DrawArrow(DirectionArrow arrow)
        {
            Console.ForegroundColor = (ConsoleColor)arrow.CurrentDirectionArrowColor;
            Console.SetCursorPosition(arrow.DirectionArrowCoord.XCoord, arrow.DirectionArrowCoord.YCoord);
            Console.Write(arrow.DirectionArrowSymbol);
            Console.ResetColor();
        }

        public static void DrawRoadCrossDirections(CrossRoadDirections setOfDirections)
        {
            DrawArrow(setOfDirections.BottomTopDirection);
            DrawArrow(setOfDirections.LeftRightDirection);
            DrawArrow(setOfDirections.RightLeftDirection);
            DrawArrow(setOfDirections.TopBottomDirection);
        }
    }
}