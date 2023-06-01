using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    internal abstract class Figura
    {
        //public string nazwa;
        public System.Windows.Controls.Button obiekt;
        public bool czy_zaznaczone;
        public bool czy_poprzednio_podwojny_ruch;
        public bool czy_nie_wykonal_ruchu;
        public bool kolor;
        public int pole_x;
        public int pole_y;
        virtual public bool mozliwe_ruchy(Figura[,] tablica, System.Windows.Controls.Button[,] podswietlenia)
        {
            
            return false;
            //podswietlenia[0,0].Visibility=System.Windows.Visibility.Visible;
        }
        virtual public bool czy_krol_szachowany(Figura[,] tablica)
        {
            return false;
        }

    }
}
