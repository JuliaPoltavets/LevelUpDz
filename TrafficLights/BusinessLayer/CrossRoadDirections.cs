// © 2015 Sitecore Corporation A/S. All rights reserved.
namespace TrafficLights.BusinessLayer
{
    public class CrossRoadDirections
    {
        public DirectionArrow LeftRightDirection { get; private set; }
        public DirectionArrow RightLeftDirection { get; private set; }
        public DirectionArrow BottomTopDirection { get; private set; }
        public DirectionArrow TopBottomDirection { get; private set; }

        public CrossRoadDirections(Point startCoords)
        {
            var leftRightDirCoords = new Point(startCoords.XCoord+1, startCoords.YCoord);
            var rightLeftDirCoords = new Point(startCoords.XCoord - 1, startCoords.YCoord);
            var bottomTopDirCoords = new Point(startCoords.XCoord, startCoords.YCoord - 1);
            var topBottomDirCoords = new Point(startCoords.XCoord, startCoords.YCoord + 1);
            LeftRightDirection = new DirectionArrow((char)26, leftRightDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            RightLeftDirection = new DirectionArrow((char)27, rightLeftDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            BottomTopDirection = new DirectionArrow((char)24, bottomTopDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            TopBottomDirection = new DirectionArrow((char)25, topBottomDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
        }
    }
}