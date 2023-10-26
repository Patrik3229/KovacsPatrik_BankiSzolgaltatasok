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
                    HitelSzamla hitelSzamla = szamlaLista[i] as HitelSzamla;
                    if (hitelSzamla != null)
                    {
                        osszeg += hitelSzamla.HitelKeret;
                    }
                }
                return osszeg;
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            Szamla newSzamla;

            if (hitelKeret > 0)
            {
                newSzamla = new HitelSzamla(tulajdonos, hitelKeret);
            }
            else if (hitelKeret == 0)
            {
                newSzamla = new MegtakaritasiSzamla(tulajdonos);
            }
            else
            {
                throw new ArgumentException("Nem lehet negatív a hitelkeret.");
            }

            szamlaLista.Add(newSzamla);
            return newSzamla;
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
            Szamla legnagyobbSzamla = null;
            foreach (var szamla in szamlaLista)
            {
                if (szamla.Tulajdonos.Equals(tulajdonos) && szamla.AktualisEgyenleg > legnagyobb)
                {
                    legnagyobb = szamla.AktualisEgyenleg;
                    legnagyobbSzamla = szamla;
                }
            }
            if (legnagyobbSzamla == null)
            {
                throw new Exception("Nincs számla ilyen nevű tulajdonossal.");
            }
            return legnagyobbSzamla;
        }
    }
}
