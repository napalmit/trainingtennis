using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAlgoritmoFootwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Algoritmo alg = new Algoritmo(ModalitaAllenamento.TRE_SPOSTAMENTI_80_20);

            int i = 0;
            while (i < 10)
            {
                alg.Estrai();
                System.Threading.Thread.Sleep(500);
                i++;
            }

            alg.Stampa();

            System.Threading.Thread.Sleep(500000);
        }
    }
}
