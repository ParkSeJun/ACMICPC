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

            public override bool Equals(object obj)
            {
                Key other = obj as Key;
                if (other == null)
                    return false;

                return index == other.index && leftAdd == other.leftAdd && leftSub == other.leftSub && leftMul == other.leftMul && leftDiv == other.leftDiv;
            }
        }

        public class Value
        {
            public int min;
            public int max;

            public override bool Equals(object obj)
            {
                Value other = obj as Value;
                if (other == null)
                    return false;

                return min == other.min && max == other.max;
            }
        }

        static Dictionary<Key, 

        static void Main(string[] args)
        {
        }
    }
}
