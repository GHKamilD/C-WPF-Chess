using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    internal class Krol: Figura //Klasa reprezentująca na szachownicy króla dziedzicząca po klasie Figura
    {
        public override bool mozliwe_ruchy(Figura[,] szachownica, System.Windows.Controls.Button[,] podswietlenia)
        {
            bool czy_mozliwe_ruchy = false;
            //Sprawdzenie ruchów króla. Król może poruszać się o jedno pole w dowolnym kierunku (pod warunkiem że nie będzie szachowany)
            if(this.pole_x - 1>=0&& this.pole_y - 1>=0)
            {
                //Sprawdzamy czy pole jest puste. Jeśli tak to sprawdzamy, czy po wykonaninu tego ruchu król będzie szachowany. Jeśli nie to ruch jest legalny i ujawniamy odpowiedni przycisk z tablicy podswietlenia
                if (szachownica[this.pole_x - 1, this.pole_y - 1] == null)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y - 1] = new Krol(this.kolor, this.pole_x - 1, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if(!szachownica[this.pole_x - 1, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                //Jeśli pole jest zajmowane przez figurę o tym samym kolorze co nasz król to ruch jest nielegalny
                else if (szachownica[this.pole_x - 1, this.pole_y - 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y - 1] = new Krol(this.kolor, this.pole_x - 1, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x - 1, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if (this.pole_y - 1 >= 0)
            {
                if (szachownica[this.pole_x, this.pole_y - 1] == null)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y - 1] = new Krol(this.kolor, this.pole_x, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x, this.pole_y - 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y - 1] = new Krol(this.kolor, this.pole_x, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if(this.pole_x + 1<8&& this.pole_y - 1>=0)
            {
                if (szachownica[this.pole_x + 1, this.pole_y - 1] == null)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y - 1] = new Krol(this.kolor, this.pole_x + 1, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x + 1, this.pole_y - 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y - 1], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y - 1] = new Krol(this.kolor, this.pole_x + 1, this.pole_y - 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y - 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y - 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y - 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if (this.pole_x - 1 >= 0)
            {
                if (szachownica[this.pole_x - 1, this.pole_y] == null)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y] = new Krol(this.kolor, this.pole_x - 1, this.pole_y, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x - 1, this.pole_y].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x - 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y] = new Krol(this.kolor, this.pole_x - 1, this.pole_y, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x - 1, this.pole_y].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            
            if (this.pole_x + 1 < 8)
            {
                if (szachownica[this.pole_x + 1, this.pole_y] == null)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y] = new Krol(this.kolor, this.pole_x + 1, this.pole_y, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x + 1, this.pole_y].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y] = new Krol(this.kolor, this.pole_x + 1, this.pole_y, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if(this.pole_x - 1>=0&& this.pole_y + 1<8)
            {
                if (szachownica[this.pole_x - 1, this.pole_y + 1] == null)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y + 1] = new Krol(this.kolor, this.pole_x - 1, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x - 1, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x - 1, this.pole_y + 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x - 1, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x - 1, this.pole_y + 1] = new Krol(this.kolor, this.pole_x - 1, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x - 1, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x - 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x - 1, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if(this.pole_y + 1<8)
            {
                if (szachownica[this.pole_x, this.pole_y + 1] == null)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y + 1] = new Krol(this.kolor, this.pole_x, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x, this.pole_y + 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x, this.pole_y + 1] = new Krol(this.kolor, this.pole_x, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            if (this.pole_x+1<8 && this.pole_y + 1 < 8)
            {
                if (szachownica[this.pole_x + 1, this.pole_y + 1] == null)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y + 1] = new Krol(this.kolor, this.pole_x + 1, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
                else if (szachownica[this.pole_x + 1, this.pole_y + 1].kolor != this.kolor)
                {
                    Figura pom = szachownica[this.pole_x + 1, this.pole_y + 1], pom2 = this;
                    szachownica[this.pole_x + 1, this.pole_y + 1] = new Krol(this.kolor, this.pole_x + 1, this.pole_y + 1, this.obiekt);
                    szachownica[this.pole_x, this.pole_y] = null;
                    if (!szachownica[this.pole_x + 1, this.pole_y + 1].czy_krol_szachowany(szachownica))
                    {
                        podswietlenia[this.pole_x + 1, this.pole_y + 1].Visibility = System.Windows.Visibility.Visible;
                        czy_mozliwe_ruchy = true;
                    }
                    szachownica[this.pole_x + 1, this.pole_y + 1] = pom;
                    szachownica[this.pole_x, this.pole_y] = pom2;
                }
            }
            //Sprawdzanie mozliwosci roszady. Jeśli król i odpowiednia wieża nie ruszyły się podczas partii, oraz nie znajdują się żadne figury między nimi, oraz król nie będzie przechodził przez pole, na którym byłby szachowany, to roszada jest możliwa
            if(this.czy_nie_wykonal_ruchu==true &&!this.czy_krol_szachowany(szachownica))
            {
                Figura[,] pom = szachownica;
                Figura pom2,pom3,pom4=pom[4,7],pom_krol=this;
                if (this.kolor == true)
                {
                    if (szachownica[0, 7] != null && szachownica[0, 7].czy_nie_wykonal_ruchu == true&&szachownica[1,7]==null&&szachownica[2,7]==null&&szachownica[3,7]==null)
                    {
                        pom = szachownica;
                        pom2 = pom[2, 7];
                        
                        pom[2, 7] = new Krol(true,2,7);
                        pom[4, 7] = null;
                        if (pom[2, 7].czy_krol_szachowany(pom) == false)
                        {
                            pom[2, 7] = null;
                            pom = szachownica;
                            pom3 = pom[3, 7];
                            pom[3, 7] = new Krol(true, 3, 7);
                            pom[4, 7] = null;
                            if (pom[3, 7].czy_krol_szachowany(pom) == false)
                            {
                                podswietlenia[2, 7].Visibility = System.Windows.Visibility.Visible;
                                czy_mozliwe_ruchy = true;
                            }
                            pom[3, 7] = null;
                        }
                        pom[2, 7] = null;
                        
                    }
                    if(szachownica[7, 7] != null && szachownica[7, 7].czy_nie_wykonal_ruchu == true&&szachownica[5,7]==null&&szachownica[6,7]==null)
                    {
                        pom = szachownica;
                        pom2 = pom[5, 7];
                        pom[5, 7] = new Krol(true, 5, 7);
                        pom[4, 7] = null;
                        if (pom[5, 7].czy_krol_szachowany(pom) == false)
                        {
                            pom[5, 7] = null;
                            pom = szachownica;
                            pom3 = pom[6, 7];
                            pom[6, 7] = new Krol(true, 6, 7); ;
                            pom[4, 7] = null;
                            if (pom[6, 7].czy_krol_szachowany(pom) == false)
                            {
                                podswietlenia[6, 7].Visibility = System.Windows.Visibility.Visible;
                                czy_mozliwe_ruchy = true;
                            }
                            pom[6, 7] = null;
                        }
                        pom[5, 7] = pom2;
                    }
                    pom[4, 7] = pom_krol;
                }
                else
                {
                    szachownica[4, 0] = null;
                    if (szachownica[0, 0] != null && szachownica[0, 0].czy_nie_wykonal_ruchu == true && szachownica[1, 0] == null && szachownica[2, 0] == null && szachownica[3, 0] == null)
                    {
                        szachownica[2,0]= new Krol(false, 2, 0);
                        if(szachownica[2,0].czy_krol_szachowany(szachownica)==false)
                        {
                            szachownica[2, 0] = null;
                            szachownica[3, 0] = new Krol(false, 3, 0);
                            if(szachownica[3,0].czy_krol_szachowany(szachownica)==false)
                            {
                                podswietlenia[2,0].Visibility=System.Windows.Visibility.Visible;
                                czy_mozliwe_ruchy = true;
                            }
                        }
                        szachownica[2, 0] = null;
                        szachownica[3, 0] = null;
                    }
                    if(szachownica[7, 0] != null && szachownica[7, 0].czy_nie_wykonal_ruchu == true && szachownica[6, 0] == null && szachownica[5, 0] == null)
                    {
                        szachownica[6, 0] = new Krol(false, 6, 0);
                        if (szachownica[6, 0].czy_krol_szachowany(szachownica) == false)
                        {
                            szachownica[6, 0] = null;
                            szachownica[5, 0] = new Krol(false, 5, 0);
                            if (szachownica[5, 0].czy_krol_szachowany(szachownica) == false)
                            {
                                podswietlenia[6, 0].Visibility = System.Windows.Visibility.Visible;
                                czy_mozliwe_ruchy = true;
                            }
                        }
                        szachownica[6, 0] = null;
                        szachownica[5, 0] = null;
                    }
                    
                    pom[4, 0] = pom_krol;
                }
                
            }
            return czy_mozliwe_ruchy;
        }
        public override bool czy_krol_szachowany(Figura[,] szachownica)
        {
            int i = 1;
            //Sprawdzanie, czy król jest szachowany przez gońca lub hetmana
            while(this.pole_x+i<8 && this.pole_y+i<8)
            {
                if(szachownica[this.pole_x+i,this.pole_y+i]!=null)
                {
                    if(szachownica[this.pole_x + i, this.pole_y + i].kolor!=this.kolor&&(szachownica[this.pole_x + i, this.pole_y + i].GetType() == typeof(Goniec) || szachownica[this.pole_x + i, this.pole_y + i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_x - i >=0 && this.pole_y + i < 8)
            {
                if (szachownica[this.pole_x - i, this.pole_y + i] != null)
                {
                    if (szachownica[this.pole_x - i, this.pole_y + i].kolor != this.kolor && (szachownica[this.pole_x - i, this.pole_y + i].GetType() == typeof(Goniec) || szachownica[this.pole_x - i, this.pole_y + i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_x + i < 8 && this.pole_y - i >= 0)
            {
                if (szachownica[this.pole_x + i, this.pole_y - i] != null)
                {
                    if (szachownica[this.pole_x + i, this.pole_y - i].kolor != this.kolor && (szachownica[this.pole_x + i, this.pole_y - i].GetType() == typeof(Goniec) || szachownica[this.pole_x + i, this.pole_y - i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_x - i >= 0 && this.pole_y - i >= 0)
            {
                if (szachownica[this.pole_x - i, this.pole_y - i] != null)
                {
                    if (szachownica[this.pole_x - i, this.pole_y - i].kolor != this.kolor && (szachownica[this.pole_x - i, this.pole_y - i].GetType() == typeof(Goniec) || szachownica[this.pole_x - i, this.pole_y - i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            //Sprawdzanie, czy król jest szachowany przez wieżę lub hetmana.
            while (this.pole_x + i < 8)
            {
                if (szachownica[this.pole_x + i, this.pole_y] != null)
                {
                    if (szachownica[this.pole_x + i, this.pole_y].kolor != this.kolor && (szachownica[this.pole_x + i, this.pole_y].GetType() == typeof(Wieza) || szachownica[this.pole_x + i, this.pole_y].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_x - i >= 0)
            {
                if (szachownica[this.pole_x - i, this.pole_y] != null)
                {
                    if (szachownica[this.pole_x - i, this.pole_y].kolor != this.kolor && (szachownica[this.pole_x - i, this.pole_y].GetType() == typeof(Wieza) || szachownica[this.pole_x - i, this.pole_y].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_y + i < 8)
            {
                if (szachownica[this.pole_x, this.pole_y + i] != null)
                {
                    if (szachownica[this.pole_x, this.pole_y + i].kolor != this.kolor && (szachownica[this.pole_x, this.pole_y + i].GetType() == typeof(Wieza) || szachownica[this.pole_x, this.pole_y + i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            while (this.pole_y - i >= 0)
            {
                if (szachownica[this.pole_x, this.pole_y - i] != null)
                {
                    if (szachownica[this.pole_x, this.pole_y - i].kolor != this.kolor && (szachownica[this.pole_x, this.pole_y - i].GetType() == typeof(Wieza) || szachownica[this.pole_x, this.pole_y - i].GetType() == typeof(Hetman)))
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            i = 1;
            //Sprawdzanie, czy król jest szachowany przez skoczka.
            if(this.pole_x+2<8)
            {
                if(this.pole_y+1<8)
                {
                    if(szachownica[this.pole_x+2,this.pole_y+1]!=null&& szachownica[this.pole_x + 2, this.pole_y + 1].GetType()==typeof(Skoczek) && szachownica[this.pole_x + 2, this.pole_y + 1].kolor!=this.kolor)
                    {
                        return true;
                    }
                }
                if (this.pole_y - 1 >= 0)
                {
                    if (szachownica[this.pole_x + 2, this.pole_y - 1] != null && szachownica[this.pole_x + 2, this.pole_y - 1].GetType() == typeof(Skoczek) && szachownica[this.pole_x + 2, this.pole_y - 1].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            if (this.pole_x + 1 < 8)
            {
                if (this.pole_y + 2 < 8)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y + 2] != null && szachownica[this.pole_x + 1, this.pole_y + 2].GetType() == typeof(Skoczek) && szachownica[this.pole_x + 1, this.pole_y + 2].kolor != this.kolor)
                    {
                        return true;
                    }
                }
                if (this.pole_y - 2 >= 0)
                {
                    if (szachownica[this.pole_x + 1, this.pole_y - 2] != null && szachownica[this.pole_x + 1, this.pole_y - 2].GetType() == typeof(Skoczek) && szachownica[this.pole_x + 1, this.pole_y - 2].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            if (this.pole_x - 1 >= 0)
            {
                if (this.pole_y + 2 < 8)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y + 2] != null && szachownica[this.pole_x - 1, this.pole_y + 2].GetType() == typeof(Skoczek) && szachownica[this.pole_x - 1, this.pole_y + 2].kolor != this.kolor)
                    {
                        return true;
                    }
                }
                if (this.pole_y - 2 >= 0)
                {
                    if (szachownica[this.pole_x - 1, this.pole_y - 2] != null && szachownica[this.pole_x - 1, this.pole_y - 2].GetType() == typeof(Skoczek) && szachownica[this.pole_x - 1, this.pole_y - 2].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            if (this.pole_x - 2 >= 0)
            {
                if (this.pole_y + 1 < 8)
                {
                    if (szachownica[this.pole_x - 2, this.pole_y + 1] != null && szachownica[this.pole_x - 2, this.pole_y + 1].GetType() == typeof(Skoczek) && szachownica[this.pole_x - 2, this.pole_y + 1].kolor != this.kolor)
                    {
                        return true;
                    }
                }
                if (this.pole_y - 1 >= 0)
                {
                    if (szachownica[this.pole_x - 2, this.pole_y - 1] != null && szachownica[this.pole_x - 2, this.pole_y - 1].GetType() == typeof(Skoczek) && szachownica[this.pole_x - 2, this.pole_y - 1].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            //Sprawdzenie, czy król jest szachowany przez innego króla
            if(this.pole_x+1<8)
            {
                if(this.pole_y+1<8 && szachownica[this.pole_x + 1, this.pole_y+1] != null && szachownica[this.pole_x+1,this.pole_y+1].GetType()==typeof(Krol))
                {
                    return true;
                }
                if (this.pole_y - 1 >= 0 && szachownica[this.pole_x + 1, this.pole_y-1] != null && szachownica[this.pole_x + 1, this.pole_y - 1].GetType() == typeof(Krol))
                {
                    return true;
                }
                if (szachownica[this.pole_x + 1, this.pole_y]!=null && szachownica[this.pole_x + 1, this.pole_y].GetType() == typeof(Krol))
                {
                    return true;
                }
            }
            if (this.pole_y + 1 < 8 && szachownica[this.pole_x, this.pole_y+1] != null && szachownica[this.pole_x, this.pole_y + 1].GetType() == typeof(Krol))
            {
                return true;
            }
            if (this.pole_y - 1 >= 0 && szachownica[this.pole_x, this.pole_y-1] != null && szachownica[this.pole_x, this.pole_y - 1].GetType() == typeof(Krol))
            {
                return true;
            }
            if (this.pole_x - 1 >= 0)
            {
                if (this.pole_y + 1 < 8 && szachownica[this.pole_x - 1, this.pole_y+1] != null && szachownica[this.pole_x - 1, this.pole_y + 1].GetType() == typeof(Krol))
                {
                    return true;
                }
                if (this.pole_y - 1 >= 0 && szachownica[this.pole_x - 1, this.pole_y-1] != null && szachownica[this.pole_x - 1, this.pole_y - 1].GetType() == typeof(Krol))
                {
                    return true;
                }
                if (szachownica[this.pole_x - 1, this.pole_y] != null && szachownica[this.pole_x - 1, this.pole_y].GetType() == typeof(Krol))
                {
                    return true;
                }
            }
            //Sprawdzenie czy król jest szachowany przez pionka
            if(this.kolor==true)
            {
                if(this.pole_y-1>=0)
                {
                    if(this.pole_x+1<8&&szachownica[this.pole_x+1,this.pole_y-1]!=null&& szachownica[this.pole_x + 1, this.pole_y - 1].GetType()==typeof(Pionek)&& szachownica[this.pole_x + 1, this.pole_y - 1].kolor!=this.kolor)
                    {
                        return true;
                    }
                    if (this.pole_x - 1 >= 0 && szachownica[this.pole_x - 1, this.pole_y - 1] != null && szachownica[this.pole_x - 1, this.pole_y - 1].GetType() == typeof(Pionek) && szachownica[this.pole_x - 1, this.pole_y - 1].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (this.pole_y + 1 < 8)
                {
                    if (this.pole_x + 1 < 8 && szachownica[this.pole_x + 1, this.pole_y + 1] != null && szachownica[this.pole_x + 1, this.pole_y + 1].GetType() == typeof(Pionek) && szachownica[this.pole_x + 1, this.pole_y + 1].kolor != this.kolor)
                    {
                        return true;
                    }
                    if (this.pole_x - 1 >= 0 && szachownica[this.pole_x - 1, this.pole_y + 1] != null && szachownica[this.pole_x - 1, this.pole_y + 1].GetType() == typeof(Pionek) && szachownica[this.pole_x - 1, this.pole_y + 1].kolor != this.kolor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Krol(bool kolor, int pole_X, int pole_y, System.Windows.Controls.Button obiekt)
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.obiekt = obiekt;
            this.czy_nie_wykonal_ruchu = true;
        }
        public Krol(bool kolor, int pole_X, int pole_y)
        {
            this.kolor = kolor;
            this.pole_x = pole_X;
            this.pole_y = pole_y;
            this.czy_nie_wykonal_ruchu = true;
        }
    }
}
