using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    internal abstract class Szamla : BankiSzolgaltatas
    {
        protected int aktualisEgyenleg;

        public Szamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
            
        }

        public int AktualisEgyenleg { get => aktualisEgyenleg; }

        public void Befizet(int osszeg)
        {
            this.aktualisEgyenleg += osszeg;
        }

        public bool Kivesz(int osszeg)
        {
            if (this.aktualisEgyenleg >= osszeg)
            {
                this.aktualisEgyenleg -= osszeg;
                return true;
            }
            return false;
        }
    }
}