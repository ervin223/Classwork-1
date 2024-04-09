using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv23_C_põhikonstruktsioonid
{
    public class Funktisioonid
    {
        public static void Tervitus(string nimi)
        {
            Console.WriteLine("Tere kallis {0}", nimi);
        }

        public static int Korruta(int arv1, int arv2)
        {
            return arv1 * arv2;
        }
    }
}