using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_AboutClasses.Client.Classes
{
    public class Calcular
    {
        public static int Somar(int n1, int n2) => n1 + n2;
        public static int Subtrair(int n1, int n2) => n1 - n2;
        public static int Multiplicar(int n1, int n2) => n1 * n2;
    }
}
