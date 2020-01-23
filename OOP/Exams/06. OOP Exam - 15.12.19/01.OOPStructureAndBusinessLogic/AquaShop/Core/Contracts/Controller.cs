namespace AquaShop.Core.Contracts
{
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities.Messages;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            if (aquarium == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (fish == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            string result = string.Empty;

            if (aquarium.GetType().Name.StartsWith("Freshwater") != (fish.GetType().Name == "FreshwaterFish"))
            {
                result = string.Format(OutputMessages.UnsuitableWater);
            }
            else if(aquarium.GetType().Name.StartsWith("Saltwater") != (fish.GetType().Name == "SaltwaterFish"))
            {
                result = string.Format(OutputMessages.UnsuitableWater);
            }
            else
            {
                aquarium.AddFish(fish);
                result = string.Format(OutputMessages.FishAdded, fishType, aquariumName);
            }

            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);
                     
            decimal fishPrice = aquarium.Fish.Sum(x => x.Price);
            decimal decorationPrice = aquarium.Decorations.Sum(x => x.Price);

            decimal totalPrice = fishPrice + decorationPrice;
            
            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{totalPrice:F2}");
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);

            int count = 0;

            foreach (var item in aquarium.Fish)
            {
                item.Eat();
                count++;
            }

            return string.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.aquariums)
            {
                sb.AppendLine($"{item.GetInfo()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
