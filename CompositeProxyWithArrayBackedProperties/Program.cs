using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompositeProxyWithArrayBackedProperties
{
    public class House
    {
        private readonly bool[] flags = new bool[3];

        public bool Pillars
        {
            get => flags[0];
            set => flags[0] = value;
        }
        public bool Walls
        {
            get => flags[1];
            set => flags[1] = value;
        }
        public bool Floors
        {
            get => flags[2];
            set => flags[2] = value;
        }

        public bool? All
        {
            get
            {
                if (flags.Skip(1).All(f => f == flags[0]))
                    return flags[0];
                return null;
            }
            set
            {
                if (!value.HasValue) return;
                for (int i = 0; i < flags.Length; i++)
                {
                    flags[i] = value.Value;
                }
            }
        }

        public override string ToString()
        {
            return $"Has Pillars {flags[0]}{Environment.NewLine}" +
                   $"Has Walls {flags[1]}{Environment.NewLine}" +
                   $"Has Floors {flags[2]}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var house1 = new House();
            house1.All = true;
            Console.WriteLine($"House1: {Environment.NewLine}{house1}");

            var house2 = new House();
            house2.Pillars = true;
            Console.WriteLine($"House2: {Environment.NewLine}{house2}");

            var house3 = new House();
            house3.Walls = true;
            house3.Floors = true;
            Console.WriteLine($"House3: {Environment.NewLine}{house3}");
        }
    }
}
