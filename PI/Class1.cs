using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI
{
    class Class1
    {
        public static List<string> ListOfQueries = new List<string>();
        public static int Sum = 0;
        public static void Add(string query, int sum)
        {
            ListOfQueries.Add(query);
            Sum += sum;
        }
        public static void Clear()
        {
            Sum = 0;
            ListOfQueries.Clear();
        }
    }
}
