using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.BusinessLayer;
using TrafficLights.PresentationLayer;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftTopRightBottomStates = new[]
            {
                TrafficLightStates.Green,
                TrafficLightStates.Yellow,
                TrafficLightStates.Red,
                TrafficLightStates.Red | TrafficLightStates.Yellow
            };
            var rightTopleftBottomStates = new[]
            {
                TrafficLightStates.Red,
                TrafficLightStates.Red | TrafficLightStates.Yellow,
                TrafficLightStates.Green,
                TrafficLightStates.Yellow
            };

            //Draw the Road
            var roadCross = new RoadCross(Console.WindowWidth, Console.WindowHeight, 6);
            DrawingRoadCross.DrawRoadCross(roadCross);

            //Define Traffic Lights
            var leftTopTrafficLight = new TrafficLight(new Point(35, 5), (char)15);
            var rightTopTrafficLight = new TrafficLight(new Point(45, 5), (char)15);
            var leftBottomTrafficLight = new TrafficLight(new Point(35, 16), (char)15);
            var rightBottomTrafficLight = new TrafficLight(new Point(45, 16), (char)15);

            //Define Cross Road Traffic Directions
            var crossRoadDirections = new CrossRoadDirections(new Point(Console.WindowWidth/2, Console.WindowHeight/2));
            DrawingDirectionArrows.DrawRoadCrossDirections(crossRoadDirections);

            var endDate = DateTime.UtcNow.AddMinutes(1);
            while (DateTime.UtcNow <= endDate)
            {
                int stateNum = 0;
                for (;stateNum < rightTopleftBottomStates.Length; stateNum++)
                {
                    leftTopTrafficLight.SetTrafficLightState(leftTopRightBottomStates[stateNum]);
                    rightBottomTrafficLight.SetTrafficLightState(leftTopRightBottomStates[stateNum]);
                    DrawingTrafficLight.DrawTrafficLight(leftTopTrafficLight);
                    DrawingTrafficLight.DrawTrafficLight(rightBottomTrafficLight);

                    rightTopTrafficLight.SetTrafficLightState(rightTopleftBottomStates[stateNum]);
                    leftBottomTrafficLight.SetTrafficLightState(rightTopleftBottomStates[stateNum]);
                    DrawingTrafficLight.DrawTrafficLight(rightTopTrafficLight);
                    DrawingTrafficLight.DrawTrafficLight(leftBottomTrafficLight);
                    System.Threading.Thread.Sleep(1000);
                }

            }
            Console.ReadLine();
        }
    }
}
