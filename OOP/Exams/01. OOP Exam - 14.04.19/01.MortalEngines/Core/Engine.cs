namespace MortalEngines.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private MachinesManager machineManager;

        public Engine()
        {
            this.machineManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];

                if (command == "Quit")
                {
                    return;
                }

                string output = string.Empty;

                switch (command)
                {
                    case "HirePilot":
                        output = machineManager.HirePilot(input[1]);
                        break;
                    case "PilotReport":
                        output = machineManager.PilotReport(input[1]);
                        break;
                    case "ManufactureTank":
                        output = machineManager.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;
                    case "ManufactureFighter":
                        output = machineManager.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;
                    case "MachineReport":
                        output = machineManager.MachineReport(input[1]);
                        break;
                    case "AggressiveMode":
                        output = machineManager.ToggleFighterAggressiveMode(input[1]);
                        break;
                    case "DefenseMode":
                        output = machineManager.ToggleTankDefenseMode(input[1]);
                        break;
                    case "Engage":
                        output = machineManager.EngageMachine(input[1], input[2]);
                        break;
                    case "Attack":
                        output = machineManager.AttackMachines(input[1], input[2]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(output);
            }
        }
    }
}
