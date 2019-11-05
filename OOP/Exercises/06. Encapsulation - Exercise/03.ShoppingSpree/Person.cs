using System;
using System.Collections.Generic;
using System.Linq;
namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<string> products;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Money
        {
            get => this.money;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            int temp = this.Money - product.Cost;

            if(temp < 0)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.products.Add(product.Name);

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if(this.products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.products)}";
        }
    }
}
