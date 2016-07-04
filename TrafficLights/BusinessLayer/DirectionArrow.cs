namespace TrafficLights.BusinessLayer
{
    public class DirectionArrow
    {
        public enum DirectionArrowColors
        {
            Inactive = System.ConsoleColor.Gray,
            Active = System.ConsoleColor.Yellow
        }

        public bool DirectionArrowState { get; private set; }

        public DirectionArrowColors CurrentDirectionArrowColor { get; private set; }

        public Point DirectionArrowCoord { get; private set; }

        public char DirectionArrowSymbol { get; private set; }

        public DirectionArrow(char symbol, Point coords, DirectionArrowColors color)
        {
            DirectionArrowSymbol = symbol;
            DirectionArrowCoord = coords;
            CurrentDirectionArrowColor = color;
        }

        public static void ResetCurrentColorToEmpty(DirectionArrow arrow)
        {
            arrow.CurrentDirectionArrowColor = DirectionArrowColors.Inactive;
            arrow.DirectionArrowState = false;
        }

        public static void HighlightLight(DirectionArrow arrow)
        {
            arrow.CurrentDirectionArrowColor = DirectionArrowColors.Active;
            arrow.DirectionArrowState = true;
        }

    }
}
