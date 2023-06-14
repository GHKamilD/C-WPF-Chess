using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    internal abstract class Figura //Klasa abstrakcyjna, po gtórej będą dziedziczyć inne klasy programu
    {
        //public string nazwa;
        public System.Windows.Controls.Button obiekt; //Przycisk w pliku .xaml odpowiadający danej figurze
        public bool czy_zaznaczone; //zmienna ustalająca, czy przycisk był ostatnio wciśnięty
        public bool czy_poprzednio_podwojny_ruch; //Zmienna pokazująca czy figura (pionek) ruszyła się o dwa miejsca w poprzednim ruchu
        public bool czy_nie_wykonal_ruchu; //Zmienna sprawdzająca czy figura (Król oraz wieża) nie wykonały jeszcze żadnego ruchu
        public bool kolor; //Kolor figury: true=biały, false=czarny
        public int pole_x; //Współrzędne x figury na szachownicy
        public int pole_y; //Współrzędne y figury na szachownicy
        virtual public bool mozliwe_ruchy(Figura[,] tablica, System.Windows.Controls.Button[,] podswietlenia) //Metoda pokazująca wszystkie możliwe ruchy figury sprawiając, że odpowiednie przyciski z tablicy szachownica będą widoczne. Zwraca ona wartość true, gdy jest możliwy przynajmniej jeden ruch i false w przeciwnym wypadku
        {
            return false;
            //podswietlenia[0,0].Visibility=System.Windows.Visibility.Visible;
        }
        virtual public bool czy_krol_szachowany(Figura[,] tablica) //Metoda sprawdzająca, czy król jest szachowany na szachownicy
        {
            return false;
        }

    }
}
