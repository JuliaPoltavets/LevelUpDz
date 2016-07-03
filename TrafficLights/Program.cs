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
            var roadCross = new RoadCross(Console.WindowWidth,Console.WindowHeight,6);
            DrawingRoadCross.DrawRoadCross(roadCross);
            Console.ReadLine();
            //var now = DateTime.UtcNow ;
            //var trlight = new TrafficLight(new Point(5,5), (char)15);
            //var stepMs = 10000;
            //do
            //{
            //   // trlight.SetTrafficLightState(TrafficLightStates.Green);
            //   // Drawing.DrawTrafficLight(trlight);
            //   // System.Threading.Thread.Sleep(5000);
            //   // trlight.SetTrafficLightState(TrafficLightStates.Yellow);
            //   // Drawing.DrawTrafficLight(trlight);
            //   // System.Threading.Thread.Sleep(1000);
            //   // trlight.SetTrafficLightState(TrafficLightStates.Red);
            //   // Drawing.DrawTrafficLight(trlight);
            //   // System.Threading.Thread.Sleep(5000);
            //   // trlight.SetTrafficLightState(TrafficLightStates.Red|TrafficLightStates.Yellow);
            //   // Drawing.DrawTrafficLight(trlight);
            //   // System.Threading.Thread.Sleep(1000);
            //} while (now.AddMinutes(1) >= now);

        }
    }
}
