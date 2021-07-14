using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeProxySoAAoS
{
    class Creature
    {
        public byte age;
        public int x, y;
    }
    class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }
        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;
            public CreatureProxy(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new CreatureProxy(this, pos);
        }

    }
    class Program
    {
        // AoS/SoA duality
        static void Main(string[] args)
        {
            // Arrays of Struct
            var creatures1 = new Creature[100];
            foreach (var c in creatures1)
            {
                c.x++;
            }
            // Struct of arrays
            var creatures2 = new Creatures(100);
            foreach (var c in creatures2)
            {
                c.X++;
            }
        }
    }
}
