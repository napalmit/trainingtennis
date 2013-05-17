using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAlgoritmoFootwork
{
    public class Algoritmo
    {
        /*GruppoSpostamento GRUPPO_1;
        GruppoSpostamento GRUPPO_2;
        List<GruppoSpostamento> listaGruppo1 = new List<GruppoSpostamento>();
        List<GruppoSpostamento> listaGruppo2 = new List<GruppoSpostamento>();*/
        float PERCENTUALE_GRUPPO_1 = 80;
        float PERCENTUALE_GRUPPO_2 = 20;
        List<int> listaDaEstrarre = new List<int>();
        List<int> listaNumeroUsciti = new List<int>();
        int modalitaAllenamento;
        public Algoritmo(int modalitaAllenamento)
        {
            this.modalitaAllenamento = modalitaAllenamento;
            if (this.modalitaAllenamento == ModalitaAllenamento.TRE_SPOSTAMENTI_80_20)
            {
                PERCENTUALE_GRUPPO_1 = 80;
                PERCENTUALE_GRUPPO_2 = 20;
                listaDaEstrarre.Add(TipologiaSpostamenti.DESTRA);
                listaDaEstrarre.Add(TipologiaSpostamenti.DESTRA);
                listaDaEstrarre.Add(TipologiaSpostamenti.SINISTRA);
                listaDaEstrarre.Add(TipologiaSpostamenti.SINISTRA);
                listaDaEstrarre.Add(TipologiaSpostamenti.AVANTI);
            }
        }

        public void Estrai()
        {
            try
            {
                int rnd = new Random().Next(0, listaDaEstrarre.Count);
                int numeroUscito = listaDaEstrarre.ElementAt(rnd);
                listaNumeroUsciti.Add(numeroUscito);
                //Console.WriteLine(rnd + "|numeroUscito:" + numeroUscito);

            }
            catch (Exception e) { }
        }

        /*private void CreaListaDaEstrarre()
        {
            GRUPPO_1 = new GruppoSpostamento();
            GRUPPO_1.listaSpostamenti = new List<int>();
            GRUPPO_1.listaSpostamenti.Add(TipologiaSpostamenti.DESTRA);
            GRUPPO_1.listaSpostamenti.Add(TipologiaSpostamenti.SINISTRA);
            GRUPPO_1.percentualeUscita = PERCENTUALE_GRUPPO_1;

            GRUPPO_2 = new GruppoSpostamento();
            GRUPPO_2.listaSpostamenti = new List<int>();
            GRUPPO_2.listaSpostamenti.Add(TipologiaSpostamenti.AVANTI);
            GRUPPO_2.percentualeUscita = PERCENTUALE_GRUPPO_2;

            int countListaSpostamentiGruppo1 = GRUPPO_1.listaSpostamenti.Count;
            int countListaSpostamentiGruppo2 = GRUPPO_2.listaSpostamenti.Count;
        }*/

        internal void Stampa()
        {
            for (int i = 0; i < listaNumeroUsciti.Count; i++)
            {
                Console.WriteLine("numeroUscito:" + listaNumeroUsciti[i]);
            }

            PercentualiUscite();
        }

        internal void PercentualiUscite()
        {
            try
            {
                int numeroEstrazioni = listaNumeroUsciti.Count;

                //100 : numeroEstrazioni = 
                if (this.modalitaAllenamento == ModalitaAllenamento.TRE_SPOSTAMENTI_80_20)
                {
                    int NUMERO_USCITE_DESTRA = listaNumeroUsciti.Where(i => i == TipologiaSpostamenti.DESTRA).Count();
                    int NUMERO_USCITE_SINISTRA = listaNumeroUsciti.Where(i => i == TipologiaSpostamenti.SINISTRA).Count();
                    int NUMERO_USCITE_AVANTI = listaNumeroUsciti.Where(i => i == TipologiaSpostamenti.AVANTI).Count();
                    

                    float PERC_USCITE_DESTRA = NUMERO_USCITE_DESTRA * 100 / numeroEstrazioni;
                    float PERC_USCITE_SINISTRA = NUMERO_USCITE_SINISTRA * 100 / numeroEstrazioni;
                    float PERC_USCITE_AVANTI = NUMERO_USCITE_AVANTI * 100 / numeroEstrazioni;

                    Console.WriteLine("NUMERO_USCITE_DESTRA (1):" + NUMERO_USCITE_DESTRA + "|" + PERC_USCITE_DESTRA+"%");
                    Console.WriteLine("NUMERO_USCITE_SINISTRA (2):" + NUMERO_USCITE_SINISTRA + "|" + PERC_USCITE_SINISTRA + "%");
                    Console.WriteLine("NUMERO_USCITE_AVANTI (3):" + NUMERO_USCITE_AVANTI + "|" + PERC_USCITE_AVANTI + "%");
                }
            }
            catch (Exception e) { }
        }
    }
}
