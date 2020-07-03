using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _20200702_14888
{
    class Program
    {
        public class Key
        {
            public int index;
            public int leftAdd;
            public int leftSub;
            public int leftMul;
            public int leftDiv;

            public Key(int index, int leftAdd, int leftSub, int leftMul, int leftDiv)
            {
                this.index = index;
                this.leftAdd = leftAdd;
                this.leftSub = leftSub;
                this.leftMul = leftMul;
                this.leftDiv = leftDiv;
            }

            public override bool Equals(object obj)
            {
                Key other = obj as Key;
                if (other == null)
                    return false;

                return index == other.index && leftAdd == other.leftAdd && leftSub == other.leftSub && leftMul == other.leftMul && leftDiv == other.leftDiv;
            }

            public override int GetHashCode()
            {
                return index.GetHashCode() + leftAdd.GetHashCode() + base.GetHashCode();
            }
        }

        public class Value
        {
            public static Value Default = new Value(int.MaxValue, int.MinValue);

            public int min;
            public int max;

            public override bool Equals(object obj)
            {
                Value other = obj as Value;
                if (other == null)
                    return false;

                return min == other.min && max == other.max;
            }

            public override int GetHashCode()
            {
                return min.GetHashCode() + max.GetHashCode() + base.GetHashCode();
            }

            public Value(int min, int max)
            {
                this.min = min;
                this.max = max;
            }
        }

        static List<int> n = new List<int>();
        static Dictionary<Key, Value> table = new Dictionary<Key, Value>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var row = Console.ReadLine().Split(' ');
            for (int i = 0; i < count; i++)
                n.Add(int.Parse(row[i]));
            row = Console.ReadLine().Split(' ');
            int add = int.Parse(row[0]);
            int sub = int.Parse(row[1]);
            int mul = int.Parse(row[2]);
            int div = int.Parse(row[3]);

            var data = new Key(0, add, sub, mul, div);
            n.Reverse();

            Value a = Solve(data);
            Console.WriteLine(a.max);
            Console.WriteLine(a.min);

        }

        static Value Solve(Key key)
        {
            if (key.index == n.Count - 1)
                return new Value(n[key.index], n[key.index]);

            int min = int.MaxValue, max = int.MinValue;
            Value add = Value.Default, sub = Value.Default, mul = Value.Default, div = Value.Default;
            if (key.leftAdd > 0)
            {
                add = Solve(new Key(key.index + 1, key.leftAdd - 1, key.leftSub, key.leftMul, key.leftDiv));
                add.min += n[key.index] ;
                add.max += n[key.index] ;
            }
            if (key.leftSub > 0)
            {
                sub = Solve(new Key(key.index + 1, key.leftAdd, key.leftSub - 1, key.leftMul, key.leftDiv));
                sub.min -= n[key.index] ;
                sub.max -= n[key.index];
            }
            if (key.leftMul > 0)
            {
                mul = Solve(new Key(key.index + 1, key.leftAdd, key.leftSub, key.leftMul - 1, key.leftDiv));
                mul.min *= n[key.index] ;
                mul.max *= n[key.index] ;
            }
            if (key.leftDiv > 0)
            {
                div = Solve(new Key(key.index + 1, key.leftAdd, key.leftSub, key.leftMul, key.leftDiv - 1));
                div.min /= n[key.index];
                div.max /= n[key.index] ;
            }

            min = Math.Min(add.min, Math.Min(sub.min, Math.Min(mul.min, div.min)));
            max = Math.Max(add.max, Math.Max(sub.max, Math.Max(mul.max, div.max)));

            return new Value(min, max);
        }
    }
}
