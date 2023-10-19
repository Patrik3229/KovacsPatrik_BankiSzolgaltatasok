using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        private List<Szamla> szamlaLista;

        public Bank()
        {
            szamlaLista = new List<Szamla>();
        }

        public long OsszHitelkeret
        {
            get
            {
                long osszeg = 0;
                for (int i = 0; i < szamlaLista.Count; i++)
                {
                    #pragma warning disable CS8602 // Dereference of a possibly null reference.
                    osszeg += (szamlaLista[i] as HitelSzamla).HitelKeret;
                    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                return osszeg;
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            if (hitelKeret > 0)
            {
                szamlaLista.Add(new HitelSzamla(tulajdonos, hitelKeret));
                return new HitelSzamla(tulajdonos, hitelKeret);
            }
            else if (hitelKeret == 0)
            {
                szamlaLista.Add(new MegtakaritasiSzamla(tulajdonos));
                return new MegtakaritasiSzamla(tulajdonos);
            }
            throw new Exception("Nem lehet negatív a hitelkeret.");
        }

        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            long osszeg = 0;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                if (szamlaLista[i].Tulajdonos.Equals(tulajdonos))
                {
                    osszeg += szamlaLista[i].AktualisEgyenleg;
                }
            }
            return osszeg;
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
        {
            int legnagyobb = int.MinValue;
            int index = 0;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                if (szamlaLista[i].AktualisEgyenleg > legnagyobb)
                {
                    legnagyobb = szamlaLista[i].AktualisEgyenleg;
                    index = i;
                }
            }
            return szamlaLista[index];
        }
    }
}
