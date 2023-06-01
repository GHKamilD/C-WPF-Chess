using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    internal class Pionek : Figura
    {
        public bool czy_poprzednio_podwojny_ruch { get; set; }
        public override bool mozliwe_ruchy(Figura[,] szachownica, System.Windows.Controls.Button[,] podswietlenia)
        {
            bool czy_mozliwe_ruchy = false;
            
            if(this.kolor==true)
            {
                if (szachownica[this.pole_x, this.pole_y - 1] == null)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y - 1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    for(int i=0; i<8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if(szachownica[i,j]!=null&&szachownica[i,j].GetType()==typeof(Krol)&&szachownica[i,j].kolor==this.kolor)
                            {
                                if(!szachownica[i,j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    //podswietlenia[this.pole_x, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                }
                if (this.pole_x!=7&& szachownica[this.pole_x + 1, this.pole_y]!=null && szachownica[this.pole_x + 1, this.pole_y].GetType() == typeof(Pionek) && szachownica[this.pole_x + 1, this.pole_y].czy_poprzednio_podwojny_ruch == true && szachownica[this.pole_x + 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x+1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x+1, this.pole_y-1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    szachownica[this.pole_x + 1, this.pole_y] = null;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                            {
                                if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x+1, this.pole_y-1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x+1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    szachownica[this.pole_x + 1, this.pole_y - 1] = null;
                    //podswietlenia[this.pole_x + 1, this.pole_y-1].Visibility = System.Windows.Visibility.Visible;
                }
                if (this.pole_x != 0 && szachownica[this.pole_x - 1, this.pole_y] != null && szachownica[this.pole_x - 1, this.pole_y].GetType() == typeof(Pionek) && szachownica[this.pole_x - 1, this.pole_y].czy_poprzednio_podwojny_ruch == true && szachownica[this.pole_x - 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y - 1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    szachownica[this.pole_x - 1, this.pole_y] = null;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                            {
                                if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x - 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    szachownica[this.pole_x - 1, this.pole_y - 1] = null;
                    //podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                }
                if (this.pole_y == 6)
                {
                    if (szachownica[this.pole_x, this.pole_y - 2] == null&&szachownica[this.pole_x, this.pole_y-1]==null)
                    {
                        Figura pom = szachownica[this.pole_x, this.pole_y - 2], pom2 = this;
                        szachownica[this.pole_x, this.pole_y - 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x, this.pole_y - 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x, this.pole_y - 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x, this.pole_y - 2].Visibility= System.Windows.Visibility.Visible;
                    }
                }
                if (this.pole_x!=7)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y - 1] != null && szachownica[this.pole_x + 1, this.pole_y - 1].kolor!=this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x + 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                    }
                    
                }
                if(this.pole_x!=0)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y - 1] != null && szachownica[this.pole_x - 1, this.pole_y - 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y - 1], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y - 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y - 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                    }
                }

            }
            else
            {
                if (szachownica[this.pole_x, this.pole_y + 1] == null)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y + 1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                            {
                                if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    //podswietlenia[this.pole_x, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                }
                if (this.pole_x != 7 && szachownica[this.pole_x + 1, this.pole_y] != null && szachownica[this.pole_x + 1, this.pole_y].GetType() == typeof(Pionek) && szachownica[this.pole_x + 1, this.pole_y].czy_poprzednio_podwojny_ruch == true && szachownica[this.pole_x + 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y + 1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    szachownica[this.pole_x + 1, this.pole_y] = null;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                            {
                                if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x + 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    szachownica[this.pole_x + 1, this.pole_y + 1] = null;
                    //podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                    //if(szachownica[this.pole_x+1])
                }
                if (this.pole_x != 0 && szachownica[this.pole_x - 1, this.pole_y] != null && szachownica[this.pole_x - 1, this.pole_y].GetType() == typeof(Pionek) && szachownica[this.pole_x - 1, this.pole_y].czy_poprzednio_podwojny_ruch == true && szachownica[this.pole_x - 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y + 1] = this;
                    szachownica[this.pole_x, this.pole_y] = null;
                    szachownica[this.pole_x - 1, this.pole_y] = null;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                            {
                                if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                {
                                    podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                    czy_mozliwe_ruchy = true;
                                }
                                break;
                            }
                        }
                    }
                    szachownica[this.pole_x - 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                    szachownica[this.pole_x - 1, this.pole_y + 1] = null;
                    //podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                    //if(szachownica[this.pole_x+1])
                }
                if (this.pole_y == 1)
                {
                    if (szachownica[this.pole_x, this.pole_y + 2] == null && szachownica[this.pole_x, this.pole_y + 1]==null)
                    {
                        Figura pom = szachownica[this.pole_x, this.pole_y + 2], pom2 = this;
                        szachownica[this.pole_x, this.pole_y + 2] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x, this.pole_y + 2] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x, this.pole_y + 2].Visibility = System.Windows.Visibility.Visible;
                    }
                }
                if (this.pole_x != 7)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y + 1] != null && szachownica[this.pole_x + 1, this.pole_y + 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x + 1, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x + 1, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x + 1, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                    }

                }
                if (this.pole_x != 0)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y + 1] != null && szachownica[this.pole_x - 1, this.pole_y + 1].kolor != this.kolor)
                    {
                        Figura pom = szachownica[this.pole_x - 1, this.pole_y + 1], pom2 = this;
                        szachownica[this.pole_x - 1, this.pole_y + 1] = this;
                        szachownica[this.pole_x, this.pole_y] = null;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == this.kolor)
                                {
                                    if (!szachownica[i, j].czy_krol_szachowany(szachownica))
                                    {
                                        podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                                        czy_mozliwe_ruchy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        szachownica[this.pole_x - 1, this.pole_y + 1] = pom;
                        szachownica[this.pole_x, this.pole_y] = pom2;
                        //podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
            return czy_mozliwe_ruchy;
        }
        public Pionek(bool kolor, int pole_X, int pole_y)
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.czy_poprzednio_podwojny_ruch = false;
        }
        public Pionek(bool kolor, int pole_X, int pole_y, System.Windows.Controls.Button obiekt)
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.obiekt = obiekt;
        }
        public Pionek(bool kolor, int pole_X, int pole_y, System.Windows.Controls.Button obiekt, bool czy_zaznaczone)
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.czy_poprzednio_podwojny_ruch = false;
            this.obiekt = obiekt;
            this.czy_zaznaczone = czy_zaznaczone;
        }
    }
}
