using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class MegtakaritasiSzamla : Szamla
    {
        public static double alapKamat = 1.1;
        private double kamat;

        public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
            this.kamat = 1.1;
        }

        public double Kamat { get => kamat; set => kamat = value; }

        public override bool Kivesz(int osszeg)
        {
            if (base.aktualisEgyenleg >= osszeg)
            {
                base.aktualisEgyenleg -= osszeg;
                return true;
            }
            return false;
        }

        public void KamatJovairas()
        {
            base.aktualisEgyenleg += (int)(this.kamat * base.aktualisEgyenleg - base.aktualisEgyenleg);
        }
    }
}
