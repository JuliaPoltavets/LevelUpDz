namespace TrafficLights.BusinessLayer
{
    public class Light
    {
        public enum LightColors
        {
            None = System.ConsoleColor.Gray,
            Red = System.ConsoleColor.Red,
            Yellow = System.ConsoleColor.Yellow,
            Green = System.ConsoleColor.Green
        }

        public bool LightState { get; private set; }

        public LightColors CurrentLightColor { get; private set; }

        public LightColors DefaultLightColor { get; private set; }

        public LightColors EmptyLightColor { get; set; }

        public Point LightCoord { get; private set; }

        public char LightSymbol { get; private set; }

        public Light(Point coords, char symbol, LightColors defaultColor, LightColors currentColor, LightColors emptyLight)
        {
            LightCoord = coords;
            LightSymbol = symbol;
            DefaultLightColor = defaultColor;
            CurrentLightColor = currentColor;
            EmptyLightColor = emptyLight;
        }

        public static void ResetCurrentColorToEmpty(Light light)
        {
            light.CurrentLightColor = light.EmptyLightColor;
            light.LightState = false;
        }

        public static void HighlightLight(Light light)
        {
            light.CurrentLightColor = light.DefaultLightColor;
            light.LightState = true;
        }

        public void SetLightColor(LightColors color)
        {
            if (color == LightColors.None)
            {
                ResetCurrentColorToEmpty(this);
            }
            else
            {
                CurrentLightColor = color;
                LightState = true;
            }
        }
    }
}
