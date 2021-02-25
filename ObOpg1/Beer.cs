using System;

namespace ObOpg1
{
    public class Beer
    {
        private string _name;
        private double _price;
        private int _abv;

        public Beer()
        {

        }

        public Beer(int id, string name, double price, int abv)
        {
            Id = id;
            Name = name;
            Price = price;
            ABV = abv;
        }

        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Name must be at least 4 characters.");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be greater than 0");
                }
                else
                {
                    _price = value;
                }
            }
        }
        public int ABV
        {
            get => _abv;
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("ABV must be between 0 and 100");
                }
                else
                {
                    _abv = value;
                }
            }
        }

    }
}
