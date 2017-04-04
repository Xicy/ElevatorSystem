using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ElevatorSystem
{
    class Program
    {
        static List<int> insideElevator = new List<int>();
        static List<int> outsideElevator = new List<int>();
        private static int currentFloor;

        static void MoveElevator()
        {
            int goingFloor1 = currentFloor;
            int goingFloor2 = currentFloor;
            int checkPointIn1 = int.MaxValue;
            int checkPointIn2 = int.MaxValue;
            int checkPointOut1 = int.MaxValue;
            int checkPointOut2 = int.MaxValue;

            //Calculate distance of inside elevator button click inside
            for (int i = 0; i < insideElevator.Count; i++)
            {
                if (checkPointIn2 > Math.Abs(currentFloor - insideElevator[i]))
                {
                    checkPointIn2 = Math.Abs(checkPointIn1 = currentFloor - insideElevator[i]);
                    if (checkPointIn1 <= checkPointIn2)
                    {
                        goingFloor1 = i;
                    }
                }
            }
            //Calculate distance of outside elevator button click
            for (int i = 0; i < outsideElevator.Count; i++)
            {
                if (checkPointOut2 > Math.Abs(currentFloor - outsideElevator[i]))
                {
                    checkPointOut2 = Math.Abs(checkPointOut1 = currentFloor - outsideElevator[i]);
                    if (checkPointOut1 <= checkPointOut2)
                    {
                        goingFloor2 = i;
                    }
                }
            }

            //Move 
            if (checkPointOut2 < checkPointIn2 &&
                (checkPointIn1 < 0 && checkPointOut1 < 0 || checkPointIn1 > 0 && checkPointOut1 > 0))
            {
                if (currentFloor == outsideElevator[goingFloor2])
                    Debug.WriteLine("Waiting " + currentFloor);
                else
                {
                    currentFloor = outsideElevator[goingFloor2];
                    Debug.WriteLine("Going for outside to " + currentFloor);
                }
                outsideElevator.RemoveAt(goingFloor2);
            }
            else
            {
                if (currentFloor == insideElevator[goingFloor1])
                    Debug.WriteLine("Waiting " + currentFloor);
                else
                {
                    currentFloor = insideElevator[goingFloor1];
                    Debug.WriteLine("Going for inside to " + currentFloor);
                }
                insideElevator.RemoveAt(goingFloor1);
            }
        }

        static void MoveInside(int floor)
        {
            insideElevator.Add(floor);
        }

        static void MoveOutside(int floor)
        {
            outsideElevator.Add(floor);
        }

        static void Main(string[] args)
        {
            currentFloor = 3;

            //Click inside
            MoveInside(4);
            MoveInside(10);
            MoveInside(9);
            //Click Out side
            MoveOutside(5);
            MoveOutside(9);
            MoveOutside(2);

            int testCounter = insideElevator.Count + outsideElevator.Count;
            for (int i = 0; i < testCounter; i++)
                MoveElevator();
        }
    }
}
