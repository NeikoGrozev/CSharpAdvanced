namespace MortalEngines.Core
{
    using Common;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public string HirePilot(string name)
        {
            if (!this.pilots.ContainsKey(name))
            {
                this.pilots.Add(name, new Pilot(name));

                return string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (!this.machines.ContainsKey(name))
            {
                ITank tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(name, tank);

                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }
            else
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, name);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (!this.machines.ContainsKey(name))
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(name, fighter);

                string aggressiveStatus = fighter.AggressiveMode ? "ON" : "OFF";

                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, aggressiveStatus);
            }
            else
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (!this.machines.ContainsKey(selectedMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (this.machines[selectedMachineName].Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            this.machines[selectedMachineName].Pilot = this.pilots[selectedPilotName];
            this.pilots[selectedPilotName].AddMachine(this.machines[selectedMachineName]);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if(!this.machines.ContainsKey(attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if(!this.machines.ContainsKey(defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if(this.machines[attackingMachineName].HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if(this.machines[defendingMachineName].HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            this.machines[attackingMachineName].Attack(this.machines[defendingMachineName]);
            double healthOfDefenderMachine = this.machines[defendingMachineName].HealthPoints;

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, healthOfDefenderMachine);
        }

        public string PilotReport(string pilotReporting)
        {
            if (!this.pilots.ContainsKey(pilotReporting))
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            return this.pilots[pilotReporting].Report();
        }

        public string MachineReport(string machineName)
        {
            if (!this.machines.ContainsKey(machineName))
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            return this.machines[machineName].ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.ContainsKey(fighterName))
            {
                if (this.machines[fighterName] is Fighter fighter)
                {
                    fighter.ToggleAggressiveMode();

                    return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
                }
            }

            return string.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.ContainsKey(tankName))
            {
                if (this.machines[tankName] is Tank tank)
                {
                    tank.ToggleDefenseMode();

                    return string.Format(OutputMessages.TankOperationSuccessful, tankName);
                }
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}