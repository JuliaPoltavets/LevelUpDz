using System;
using System.Net.Mime;
using TrafficLights.BusinessLayer;

namespace TrafficLights.PresentationLayer
{
    public static class Drawing
    {
        public static void DrawLight(Light light)
        {
            Console.ForegroundColor = (ConsoleColor) light.CurrentLightColor;
            Console.SetCursorPosition(light.LightCoord.XCoord, light.LightCoord.YCoord);
            Console.Write(light.LightSymbol);
            Console.ResetColor();
        }

        public static void DrawTrafficLight(TrafficLight trafficLight)
        {
            //top light 
            DrawLight(trafficLight.TopLight);
            DrawLight(trafficLight.MiddleLight);
            DrawLight(trafficLight.BottomLight);
        }
    }
}