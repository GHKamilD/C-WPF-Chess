using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    internal class Goniec : Figura //Klasa reprezentująca na szachownicy gońca dziedzicząca po klasie Figura
    {
        public override bool mozliwe_ruchy(Figura[,] szachownica, System.Windows.Controls.Button[,] podswietlenia)
        {
            bool czy_mozliwe_ruchy = false, czy_szach=false;
            int i = 1;
            //Sprawdzanie ruchów po przekątnej w prawo i w dół
            while(this.pole_x+i>=0&&this.pole_x+i<8&&this.pole_y+i>=0&&this.pole_y+i<8)
            {
                Figura pom = szachownica[this.pole_x + i, this.pole_y + i], pom2 = this;
                szachownica[this.pole_x + i, this.pole_y + i] = this;
                szachownica[this.pole_x, this.pole_y] = null;
                //Pętla sprawdzająca, czy dany ruch nie sprawi, że król o tym samym kolorze co figura nie będzie szachowany
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (szachownica[a, b] != null && szachownica[a, b].GetType() == typeof(Krol) && szachownica[a, b].kolor == this.kolor)
                        {
                            if (!szachownica[a, b].czy_krol_szachowany(szachownica))
                            {
                                czy_szach = false;
                            }
                            else
                            {
                                czy_szach = true;
                            }
                            break;
                        }
                    }
                }
                szachownica[this.pole_x + i, this.pole_y + i] = pom;
                szachownica[this.pole_x, this.pole_y] = pom2;
                if (szachownica[this.pole_x+i,this.pole_y+i]!=null)
                {
                    if (szachownica[this.pole_x + i, this.pole_y + i].kolor!=this.kolor && !czy_szach)
                    {
                        podswietlenia[this.pole_x + i, this.pole_y + i].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    break;
                }
                if(!czy_szach)
                {
                    podswietlenia[this.pole_x + i, this.pole_y + i].Visibility = System.Windows.Visibility.Visible;
                    czy_mozliwe_ruchy = true;
                }
                
                i++;
            }
            i = 1;
            //Sprawdzanie ruchów po przekątnej w prawo i w górę
            while (this.pole_x + i >= 0 && this.pole_x + i < 8 && this.pole_y - i >= 0 && this.pole_y - i < 8)
            {
                Figura pom = szachownica[this.pole_x + i, this.pole_y - i], pom2 = this;
                szachownica[this.pole_x + i, this.pole_y - i] = this;
                szachownica[this.pole_x, this.pole_y] = null;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (szachownica[a, b] != null && szachownica[a, b].GetType() == typeof(Krol) && szachownica[a, b].kolor == this.kolor)
                        {
                            if (!szachownica[a, b].czy_krol_szachowany(szachownica))
                            {
                                czy_szach = false;
                            }
                            else
                            {
                                czy_szach = true;
                            }
                            break;
                        }
                    }
                }
                szachownica[this.pole_x + i, this.pole_y - i] = pom;
                szachownica[this.pole_x, this.pole_y] = pom2;
                if (szachownica[this.pole_x + i, this.pole_y - i] != null)
                {
                    if (szachownica[this.pole_x + i, this.pole_y - i].kolor != this.kolor&&!czy_szach)
                    {
                        podswietlenia[this.pole_x + i, this.pole_y - i].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    break;
                }
                if(!czy_szach)
                {
                    podswietlenia[this.pole_x + i, this.pole_y - i].Visibility = System.Windows.Visibility.Visible;
                    czy_mozliwe_ruchy = true;
                }
                i++;
            }
            i = 1;
            //Sprawdzanie ruchów po przekątnej w lewo i w górę
            while (this.pole_x - i >= 0 && this.pole_x - i < 8 && this.pole_y - i >= 0 && this.pole_y - i < 8)
            {
                Figura pom = szachownica[this.pole_x - i, this.pole_y - i], pom2 = this;
                szachownica[this.pole_x - i, this.pole_y - i] = this;
                szachownica[this.pole_x, this.pole_y] = null;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (szachownica[a, b] != null && szachownica[a, b].GetType() == typeof(Krol) && szachownica[a, b].kolor == this.kolor)
                        {
                            if (!szachownica[a, b].czy_krol_szachowany(szachownica))
                            {
                                czy_szach = false;
                            }
                            else
                            {
                                czy_szach = true;
                            }
                            break;
                        }
                    }
                }
                szachownica[this.pole_x - i, this.pole_y - i] = pom;
                szachownica[this.pole_x, this.pole_y] = pom2;
                if (szachownica[this.pole_x - i, this.pole_y - i] != null)
                {
                    if (szachownica[this.pole_x - i, this.pole_y - i].kolor != this.kolor&&!czy_szach)
                    {
                        podswietlenia[this.pole_x - i, this.pole_y - i].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    break;
                }
                if(!czy_szach)
                {
                    podswietlenia[this.pole_x - i, this.pole_y - i].Visibility = System.Windows.Visibility.Visible;
                    czy_mozliwe_ruchy = true;
                }
                i++;
            }
            i = 1;
            //Sprawdzanie ruchów po przekątnej w lewo i w dół
            while (this.pole_x - i >= 0 && this.pole_x - i < 8 && this.pole_y + i >= 0 && this.pole_y + i < 8)
            {
                Figura pom = szachownica[this.pole_x - i, this.pole_y + i], pom2 = this;
                szachownica[this.pole_x - i, this.pole_y + i] = this;
                szachownica[this.pole_x, this.pole_y] = null;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (szachownica[a, b] != null && szachownica[a, b].GetType() == typeof(Krol) && szachownica[a, b].kolor == this.kolor)
                        {
                            if (!szachownica[a, b].czy_krol_szachowany(szachownica))
                            {
                                czy_szach = false;
                            }
                            else
                            {
                                czy_szach = true;
                            }
                            break;
                        }
                    }
                }
                szachownica[this.pole_x - i, this.pole_y + i] = pom;
                szachownica[this.pole_x, this.pole_y] = pom2;
                if (szachownica[this.pole_x - i, this.pole_y + i] != null)
                {
                    if (szachownica[this.pole_x - i, this.pole_y + i].kolor != this.kolor&&!czy_szach)
                    {
                        podswietlenia[this.pole_x - i, this.pole_y + i].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    break;
                }
                if(!czy_szach)
                {
                    podswietlenia[this.pole_x - i, this.pole_y + i].Visibility = System.Windows.Visibility.Visible;
                    czy_mozliwe_ruchy = true;
                }
                i++;
            }
            return czy_mozliwe_ruchy;
        }
        public Goniec (bool kolor, int pole_X, int pole_y, System.Windows.Controls.Button obiekt) //Konstruktor Gońca
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.obiekt = obiekt;
        }
    }
}
