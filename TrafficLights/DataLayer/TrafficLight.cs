using System;
using System.Xml;

namespace TrafficLights.DataModel
{
    [Flags]
    public enum TrafficLightStates
    {
        Red = 0x1,
        Yellow = 0x2,
        Green = 0x4

    }

    public class TrafficLight
    {
        public Light TopLight { get; private set; }
        public Light MiddleLight { get; private set; }
        public Light BottomLight { get; private set; }

        public Point TrafficLightStartCoords { get; private set; }

        public TrafficLight(Point coords, char symbol)
        {
            TrafficLightStartCoords = coords;
            var middleLightCoords = new Point(TrafficLightStartCoords.XCoord, TrafficLightStartCoords.YCoord + 1);
            var bottomLightCoords = new Point(middleLightCoords.XCoord, middleLightCoords.YCoord + 1);
            TopLight = new Light(TrafficLightStartCoords, symbol, Light.LightColors.Red, Light.LightColors.None, Light.LightColors.None);
            MiddleLight = new Light(middleLightCoords, symbol, Light.LightColors.Yellow, Light.LightColors.None, Light.LightColors.None);
            BottomLight = new Light(bottomLightCoords, symbol, Light.LightColors.Green, Light.LightColors.None, Light.LightColors.None);
            
        }

        public void SetTrafficLightState(TrafficLightStates trafficLightState)
        {
            if ((trafficLightState & TrafficLightStates.Green) == TrafficLightStates.Green)
             {
                 ChangeLightState(this.BottomLight,true);
                 ChangeLightState(this.TopLight, false);
                 ChangeLightState(this.MiddleLight, false);
             }
            if ((trafficLightState & TrafficLightStates.Yellow) == TrafficLightStates.Yellow)
             {
                 ChangeLightState(this.BottomLight, false);
                 ChangeLightState(this.TopLight, false);
                 ChangeLightState(this.MiddleLight, true);
             }
            if ((trafficLightState & TrafficLightStates.Red) == TrafficLightStates.Red)
             {
                 ChangeLightState(this.BottomLight, false);
                 ChangeLightState(this.TopLight, true);
                 ChangeLightState(this.MiddleLight, false);
             }
            if ((trafficLightState ^ TrafficLightStates.Red) == TrafficLightStates.Yellow)
             {
                 ChangeLightState(this.BottomLight, false);
                 ChangeLightState(this.TopLight, true);
                 ChangeLightState(this.MiddleLight, true);
             }
        }

        public void ChangeLightState(Light light, bool turnOn)
        {
            if (turnOn)
            {
                Light.HighlightLight(light);
            }
            else
            {
                Light.ResetCurrentColorToEmpty(light);
            }
        }
    }
}