using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    internal class HitelSzamla : Szamla
    {
        private int hitelKeret;

        public HitelSzamla(Tulajdonos tulajdonos, int hitelKeret) : base(tulajdonos)
        {
            this.hitelKeret = hitelKeret;
        }

        public int HitelKeret { get => hitelKeret; }

        public new bool Kivesz(int osszeg)
        {
            if (osszeg >= this.hitelKeret + base.aktualisEgyenleg)
            {
                return false;
            }
            osszeg -= base.aktualisEgyenleg;
            base.aktualisEgyenleg = 0;
            base.aktualisEgyenleg -= osszeg;
            return true;
        }
    }
}
