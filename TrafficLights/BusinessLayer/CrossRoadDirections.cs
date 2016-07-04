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
            LeftRightDirection = new DirectionArrow((char)16, leftRightDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            RightLeftDirection = new DirectionArrow((char)17, rightLeftDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            BottomTopDirection = new DirectionArrow((char)30, bottomTopDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
            TopBottomDirection = new DirectionArrow((char)31, topBottomDirCoords, DirectionArrow.DirectionArrowColors.Inactive);
        }

        public void SetPossibleCrossRoadMoveDirections(TrafficLightStates leftTopTrafficLightState)
        {
            if (leftTopTrafficLightState == TrafficLightStates.Green)
            {
                DirectionArrow.ResetCurrentColorToEmpty(LeftRightDirection);
                DirectionArrow.ResetCurrentColorToEmpty(RightLeftDirection);
                DirectionArrow.HighlightLight(TopBottomDirection);
                DirectionArrow.HighlightLight(BottomTopDirection);
            }
            if (leftTopTrafficLightState == TrafficLightStates.Yellow)
            {
                DirectionArrow.ResetCurrentColorToEmpty(LeftRightDirection);
                DirectionArrow.ResetCurrentColorToEmpty(RightLeftDirection);
                DirectionArrow.ResetCurrentColorToEmpty(TopBottomDirection);
                DirectionArrow.ResetCurrentColorToEmpty(BottomTopDirection);
            }
            if (leftTopTrafficLightState == TrafficLightStates.Red)
            {
                DirectionArrow.HighlightLight(LeftRightDirection);
                DirectionArrow.HighlightLight(RightLeftDirection);
                DirectionArrow.ResetCurrentColorToEmpty(TopBottomDirection);
                DirectionArrow.ResetCurrentColorToEmpty(BottomTopDirection);

            }
            if (leftTopTrafficLightState == (TrafficLightStates.Red | TrafficLightStates.Yellow))
            {
                DirectionArrow.ResetCurrentColorToEmpty(LeftRightDirection);
                DirectionArrow.ResetCurrentColorToEmpty(RightLeftDirection);
                DirectionArrow.ResetCurrentColorToEmpty(TopBottomDirection);
                DirectionArrow.ResetCurrentColorToEmpty(BottomTopDirection);
            }
        }
    }
}