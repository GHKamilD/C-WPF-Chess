﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szachy
{
    internal class Skoczek: Figura //Klasa reprezentująca na szachownicy skoczka dziedzicząca po klasie Figura
    {
        
        public override bool mozliwe_ruchy(Figura[,] szachownica, System.Windows.Controls.Button[,] podswietlenia) //Skoczek może wykonywać ruchy w kształcie litery L. Funkcja ta sprawdza każdy możliwy jej układ
        {
            bool czy_mozliwe_ruchy = false;
            if (this.pole_x+2<8)
            {
                if(this.pole_y+1<8)
                {
                    if(szachownica[this.pole_x + 2, this.pole_y + 1]==null)
                    {
                        Figura pom = szachownica[this.pole_x + 2, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x + 2, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        //Pętla sprawdzająca, czy dany ruch nie sprawi, że król o tym samym kolorze co figura nie będzie szachowany
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 2, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 2, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if(szachownica[this.pole_x + 2, this.pole_y + 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 2, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x + 2, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 2, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 2, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
                if (this.pole_y - 1 >= 0)
                {
                    if (szachownica[this.pole_x + 2, this.pole_y - 1] == null)
                    {
                        Figura pom = szachownica[this.pole_x + 2, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x + 2, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 2, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 2, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x + 2, this.pole_y - 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 2, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x + 2, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 2, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 2, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
            }
            if (this.pole_x + 1 < 8)
            {
                if (this.pole_y + 2 < 8)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y + 2] == null)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y + 2], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y + 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y + 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x + 1, this.pole_y + 2].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y + 2], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y + 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y + 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
                if (this.pole_y - 2 >= 0)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y - 2] == null)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y - 2], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y - 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y - 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y - 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x + 1, this.pole_y - 2].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y - 2], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y - 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y - 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y - 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
            }
            if (this.pole_x - 1 >= 0)
            {
                if (this.pole_y + 2 < 8)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y + 2] == null)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y + 2], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y + 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y + 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x - 1, this.pole_y + 2].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y + 2], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y + 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y + 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
                if (this.pole_y - 2 >= 0)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y - 2] == null)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y - 2], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y - 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y - 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y - 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x - 1, this.pole_y - 2].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y - 2], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y - 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y - 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y - 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
            }
            if(this.pole_x-2>=0)
            {
                if (this.pole_y + 1 < 8)
                {
                    if (szachownica[this.pole_x - 2, this.pole_y + 1] == null)
                    {
                        Figura pom = szachownica[this.pole_x - 2, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x - 2, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 2, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 2, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x - 2, this.pole_y + 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 2, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x - 2, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 2, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 2, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
                if (this.pole_y - 1 >= 0)
                {
                    if (szachownica[this.pole_x - 2, this.pole_y - 1] == null)
                    {
                        Figura pom = szachownica[this.pole_x - 2, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x - 2, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 2, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 2, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                    else if (szachownica[this.pole_x - 2, this.pole_y - 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 2, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x - 2, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 2, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 2, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                    }
                }
            }
            return czy_mozliwe_ruchy;
        }
        public Skoczek (bool kolor, int pole_X, int pole_y, System.Windows.Controls.Button obiekt) //Konstruktor skoczka
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.obiekt = obiekt;
        }
    }
}
