using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Szachy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string Generuj_FEN(Figura[,] szachownica, bool czyi_ruch)
        {
            string kod = "";
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(szachownica[j,i]==null)
                    {
                        kod += "x";
                    }
                    else if(szachownica[j,i].GetType()==typeof(Pionek))
                    {
                        if(szachownica[j,i].kolor==true)
                        {
                            kod += "P";
                        }
                        else
                        {
                            kod += "p";
                        }
                        if(szachownica[j,i].czy_poprzednio_podwojny_ruch==true)
                        {
                            kod += "-";
                        }
                    }
                    else if (szachownica[j, i].GetType() == typeof(Skoczek))
                    {
                        if (szachownica[j, i].kolor == true)
                        {
                            kod += "S";
                        }
                        else
                        {
                            kod += "s";
                        }
                    }
                    else if (szachownica[j, i].GetType() == typeof(Goniec))
                    {
                        if (szachownica[j, i].kolor == true)
                        {
                            kod += "G";
                        }
                        else
                        {
                            kod += "g";
                        }
                    }
                    else if (szachownica[j, i].GetType() == typeof(Wieza))
                    {
                        if (szachownica[j, i].kolor == true)
                        {
                            kod += "W";
                        }
                        else
                        {
                            kod += "w";
                        }
                    }
                    else if (szachownica[j, i].GetType() == typeof(Hetman))
                    {
                        if (szachownica[j, i].kolor == true)
                        {
                            kod += "H";
                        }
                        else
                        {
                            kod += "h";
                        }
                    }
                    else if (szachownica[j, i].GetType() == typeof(Krol))
                    {
                        if (szachownica[j, i].kolor == true)
                        {
                            kod += "K";
                        }
                        else
                        {
                            kod += "k";
                        }
                    }
                }
                kod += "/";
            }
            if (czyi_ruch)
                kod += "b";
            else
                kod += "c";
            if(szachownica[4,7]!=null && szachownica[4,7].GetType()==typeof(Krol)&&szachownica[4,7].czy_nie_wykonal_ruchu)
            {
                if(szachownica[0,7]!=null&&szachownica[0,7].GetType()==typeof(Wieza)&&szachownica[0,7].kolor==true&&szachownica[0,7].czy_nie_wykonal_ruchu)
                {
                    kod += 'Q';
                }
                if (szachownica[7, 7] != null && szachownica[7, 7].GetType() == typeof(Wieza) && szachownica[7, 7].kolor == true && szachownica[7, 7].czy_nie_wykonal_ruchu)
                {
                    kod += 'R';
                }
            }
            if (szachownica[4, 0] != null && szachownica[4, 0].GetType() == typeof(Krol) && szachownica[4, 0].czy_nie_wykonal_ruchu)
            {
                if (szachownica[0, 0] != null && szachownica[0, 0].GetType() == typeof(Wieza) && szachownica[0, 0].kolor == false && szachownica[0, 0].czy_nie_wykonal_ruchu)
                {
                    kod += 'q';
                }
                if (szachownica[7, 0] != null && szachownica[7, 0].GetType() == typeof(Wieza) && szachownica[7, 0].kolor == false && szachownica[7, 0].czy_nie_wykonal_ruchu)
                {
                    kod += 'r';
                }
            }

            return kod;
        }
        Figura[,] generuj_szachownice(string kod)
        {
            Figura[,] szachownica = new Figura[8, 8];
            List<Button> biale_pionki = new List<Button> {Pionek0, Pionek1, Pionek2, Pionek3, Pionek4, Pionek5, Pionek6, Pionek7 };
            List<Button> czarne_pionki = new List<Button> { Pionek8, Pionek9, Pionek10, Pionek11, Pionek12, Pionek13, Pionek14, Pionek15 };
            List<Button> biale_skoczki = new List<Button> { Skoczek0, Skoczek1};
            List<Button> czarne_skoczki = new List<Button> { Skoczek2, Skoczek3};
            List<Button> biale_gonce = new List<Button> { Goniec0, Goniec1 };
            List<Button> czarne_gonce = new List<Button> { Goniec2, Goniec3 };
            List<Button> biale_wieze = new List<Button> { Wieza0, Wieza1 };
            List<Button> czarne_wieze = new List<Button> { Wieza2, Wieza3 };
            bool czy_uzyty_bialy_hetman = false, czy_uzyty_czarny_hetman = false;
            int i = 0;
            foreach (char litera in kod)
            {
                switch (litera)
                {
                    case '/':
                        continue;
                    case 'x':
                        i++;
                        continue;
                    case 'p':
                        szachownica[i % 8, i / 8] = new Pionek(false, i % 8, i / 8, czarne_pionki[0]);
                        Canvas.SetTop(czarne_pionki[0], 17 + ((i/8)*50));
                        Canvas.SetLeft(czarne_pionki[0], 218 + ((i % 8) * 50));
                        czarne_pionki.Remove(czarne_pionki[0]);
                        i++;
                        break;
                    case 'P':
                        szachownica[i % 8, i / 8] = new Pionek(true, i % 8, i / 8, biale_pionki[0]);
                        Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                        Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                        biale_pionki.Remove(biale_pionki[0]);
                        i++;
                        break;
                    case '-':
                        szachownica[(i - 1) % 8, (i - 1) / 8].czy_poprzednio_podwojny_ruch = true;
                        break;
                    case 's':
                        if(czarne_skoczki.Count>0)
                        {
                            szachownica[i % 8, i / 8] = new Skoczek(false, i % 8, i / 8, czarne_skoczki[0]);
                            Canvas.SetTop(czarne_skoczki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_skoczki[0], 218 + ((i % 8) * 50));
                            czarne_skoczki.Remove(czarne_skoczki[0]);
                            i++;
                        }
                        
                        else
                        {
                            szachownica[i % 8, i / 8] = new Skoczek(false, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            czarne_pionki[0].Content = FindResource("SkoczekC");
                            czarne_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'S':
                        if(biale_skoczki.Count>0)
                        {
                            szachownica[i % 8, i / 8] = new Skoczek(true, i % 8, i / 8, biale_skoczki[0]);
                            Canvas.SetTop(biale_skoczki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_skoczki[0], 218 + ((i % 8) * 50));
                            biale_skoczki.Remove(biale_skoczki[0]);
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Skoczek(true, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            biale_pionki[0].Content = FindResource("SkoczekB");
                            biale_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'g':
                        if (czarne_gonce.Count > 0)
                        {
                            szachownica[i % 8, i / 8] = new Goniec(false, i % 8, i / 8, czarne_gonce[0]);
                            Canvas.SetTop(czarne_gonce[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_gonce[0], 218 + ((i % 8) * 50));
                            czarne_gonce.Remove(czarne_gonce[0]);
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Goniec(false, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            czarne_pionki[0].Content = FindResource("GoniecC");
                            czarne_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'G':
                        if(biale_gonce.Count>0)
                        {
                            szachownica[i % 8, i / 8] = new Goniec(true, i % 8, i / 8, biale_gonce[0]);
                            Canvas.SetTop(biale_gonce[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_gonce[0], 218 + ((i % 8) * 50));
                            biale_gonce.Remove(biale_gonce[0]);
                            i++;
                        }
                        
                        else
                        {
                            szachownica[i % 8, i / 8] = new Goniec(true, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            biale_pionki[0].Content = FindResource("GoniecB");
                            biale_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'w':
                        if(czarne_wieze.Count > 0)
                        {
                            szachownica[i % 8, i / 8] = new Wieza(false, i % 8, i / 8, czarne_wieze[0]);
                            szachownica[i % 8, i / 8].czy_nie_wykonal_ruchu = false;
                            Canvas.SetTop(czarne_wieze[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_wieze[0], 218 + ((i % 8) * 50));
                            czarne_wieze.Remove(czarne_wieze[0]);
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Wieza(false, i % 8, i / 8, czarne_pionki[0]);
                            Canvas.SetTop(czarne_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_pionki[0], 218 + ((i % 8) * 50));
                            czarne_pionki[0].Content = FindResource("WiezaC");
                            czarne_pionki.Remove(czarne_pionki[0]);
                            i++;
                        }
                        break;

                    case 'W':
                        if(biale_wieze.Count>0)
                        {
                            szachownica[i % 8, i / 8] = new Wieza(true, i % 8, i / 8, biale_wieze[0]);
                            szachownica[i % 8, i / 8].czy_nie_wykonal_ruchu = false;
                            Canvas.SetTop(biale_wieze[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_wieze[0], 218 + ((i % 8) * 50));
                            biale_wieze.Remove(biale_wieze[0]);
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Wieza(true, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            biale_pionki[0].Content = FindResource("WiezaB");
                            biale_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'h':
                        if (!czy_uzyty_czarny_hetman)
                        {
                            szachownica[i % 8, i / 8] = new Hetman(false, i % 8, i / 8, Hetman1);
                            Canvas.SetTop(Hetman1, 17 + ((i / 8) * 50));
                            Canvas.SetLeft(Hetman1, 218 + ((i % 8) * 50));
                            czy_uzyty_czarny_hetman = true;
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Hetman(false, i % 8, i / 8, czarne_pionki[0]);
                            Canvas.SetTop(czarne_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_pionki[0], 218 + ((i % 8) * 50));
                            czarne_pionki[0].Content = FindResource("WiezaC");
                            czarne_pionki.Remove(czarne_pionki[0]);
                            i++;
                        }
                        break;
                    case 'H':
                        if (!czy_uzyty_bialy_hetman)
                        {
                            szachownica[i % 8, i / 8] = new Hetman(true, i % 8, i / 8, Hetman0);
                            Canvas.SetTop(Hetman0, 17 + ((i / 8) * 50));
                            Canvas.SetLeft(Hetman0, 218 + ((i % 8) * 50));
                            czy_uzyty_bialy_hetman = true;
                            i++;
                        }
                        else
                        {
                            szachownica[i % 8, i / 8] = new Hetman(true, i % 8, i / 8, biale_pionki[0]);
                            Canvas.SetTop(biale_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(biale_pionki[0], 218 + ((i % 8) * 50));
                            biale_pionki[0].Content = FindResource("HetmanB");
                            biale_pionki.Remove(biale_pionki[0]);
                            i++;
                        }
                        break;
                    case 'k':
                        {
                            szachownica[i % 8, i / 8] = new Krol(false, i % 8, i / 8, Krol1);
                            szachownica[i % 8, i / 8].czy_nie_wykonal_ruchu = false;
                            Canvas.SetTop(Krol1, 17 + ((i / 8) * 50));
                            Canvas.SetLeft(Krol1, 218 + ((i % 8) * 50));
                            i++;
                            break;
                        }
                    case 'K':
                        {
                            szachownica[i % 8, i / 8] = new Krol(true, i % 8, i / 8, Krol0);
                            szachownica[i % 8, i / 8].czy_nie_wykonal_ruchu = false;
                            Canvas.SetTop(Krol0, 17 + ((i / 8) * 50));
                            Canvas.SetLeft(Krol0, 218 + ((i % 8) * 50));
                            i++;
                            break;
                        }
                    case 'Q':
                        {
                            szachownica[0, 7].czy_nie_wykonal_ruchu = true;
                            szachownica[4, 7].czy_nie_wykonal_ruchu = true;
                            break;
                        }
                    case 'q':
                        {
                            szachownica[0, 0].czy_nie_wykonal_ruchu = true;
                            szachownica[4, 0].czy_nie_wykonal_ruchu = true;
                            break;
                        }
                    case 'R':
                        {
                            szachownica[7, 7].czy_nie_wykonal_ruchu = true;
                            szachownica[4, 7].czy_nie_wykonal_ruchu = true;
                            break;
                        }
                    case 'r':
                        {
                            szachownica[7, 0].czy_nie_wykonal_ruchu = true;
                            szachownica[4, 0].czy_nie_wykonal_ruchu = true;
                            break;
                        }
                    case 'b':
                        czy_ruch_bialych = true;
                        break;
                    case 'c':
                        czy_ruch_bialych = false;
                        break;
                }
            }
            return szachownica;
        }
        Figura test;
        Figura[,] szachownica = new Figura[8,8];
        Button[,] podswietlenia = new Button[8,8];
        bool czy_ruch_bialych=true;
        public MainWindow()
        {
            //System.Media.SoundPlayer sound = new System.Media.SoundPlayer("FREUDE.wav");
            //sound.PlayLooping();
            //StreamReader plik2 = new StreamReader("Wznowienie.txt");
            //MessageBox.Show(plik2.ReadLine());
            //plik2.Close();

            Button testy = new Button();

            Pionek test = new Pionek(true, 0, 6);
            InitializeComponent();
            podswietlenia[0, 7] = pole1;
            podswietlenia[1, 7] = pole2;
            podswietlenia[2, 7] = pole3;
            podswietlenia[3, 7] = pole4;
            podswietlenia[4, 7] = pole5;
            podswietlenia[5, 7] = pole6;
            podswietlenia[6, 7] = pole7;
            podswietlenia[7, 7] = pole8;
            podswietlenia[0, 6] = pole9;
            podswietlenia[1, 6] = pole10;
            podswietlenia[2, 6] = pole11;
            podswietlenia[3, 6] = pole12;
            podswietlenia[4, 6] = pole13;
            podswietlenia[5, 6] = pole14;
            podswietlenia[6, 6] = pole15;
            podswietlenia[7, 6] = pole16;
            podswietlenia[0, 5] = pole17;
            podswietlenia[1, 5] = pole18;
            podswietlenia[2, 5] = pole19;
            podswietlenia[3, 5] = pole20;
            podswietlenia[4, 5] = pole21;
            podswietlenia[5, 5] = pole22;
            podswietlenia[6, 5] = pole23;
            podswietlenia[7, 5] = pole24;
            podswietlenia[0, 4] = pole25;
            podswietlenia[1, 4] = pole26;
            podswietlenia[2, 4] = pole27;
            podswietlenia[3, 4] = pole28;
            podswietlenia[4, 4] = pole29;
            podswietlenia[5, 4] = pole30;
            podswietlenia[6, 4] = pole31;
            podswietlenia[7, 4] = pole32;
            podswietlenia[0, 3] = pole33;
            podswietlenia[1, 3] = pole34;
            podswietlenia[2, 3] = pole35;
            podswietlenia[3, 3] = pole36;
            podswietlenia[4, 3] = pole37;
            podswietlenia[5, 3] = pole38;
            podswietlenia[6, 3] = pole39;
            podswietlenia[7, 3] = pole40;
            podswietlenia[0, 2] = pole41;
            podswietlenia[1, 2] = pole42;
            podswietlenia[2, 2] = pole43;
            podswietlenia[3, 2] = pole44;
            podswietlenia[4, 2] = pole45;
            podswietlenia[5, 2] = pole46;
            podswietlenia[6, 2] = pole47;
            podswietlenia[7, 2] = pole48;
            podswietlenia[0, 1] = pole49;
            podswietlenia[1, 1] = pole50;
            podswietlenia[2, 1] = pole51;
            podswietlenia[3, 1] = pole52;
            podswietlenia[4, 1] = pole53;
            podswietlenia[5, 1] = pole54;
            podswietlenia[6, 1] = pole55;
            podswietlenia[7, 1] = pole56;
            podswietlenia[0, 0] = pole57;
            podswietlenia[1, 0] = pole58;
            podswietlenia[2, 0] = pole59;
            podswietlenia[3, 0] = pole60;
            podswietlenia[4, 0] = pole61;
            podswietlenia[5, 0] = pole62;
            podswietlenia[6, 0] = pole63;
            podswietlenia[7, 0] = pole64;
            szachownica[0, 6] = new Pionek(true, 0, 6, Pionek0);
            szachownica[1, 6] = new Pionek(true, 1, 6, Pionek1);
            szachownica[2, 6] = new Pionek(true, 2, 6, Pionek2);
            szachownica[3, 6] = new Pionek(true, 3, 6, Pionek3);
            szachownica[4, 6] = new Pionek(true, 4, 6, Pionek4);
            szachownica[5, 6] = new Pionek(true, 5, 6, Pionek5);
            szachownica[6, 6] = new Pionek(true, 6, 6, Pionek6);
            szachownica[7, 6] = new Pionek(true, 7, 6, Pionek7);
            szachownica[0, 1] = new Pionek(false, 0, 1, Pionek8);
            szachownica[1, 1] = new Pionek(false, 1, 1, Pionek9);
            szachownica[2, 1] = new Pionek(false, 2, 1, Pionek10);
            szachownica[3, 1] = new Pionek(false, 3, 1, Pionek11);
            szachownica[4, 1] = new Pionek(false, 4, 1, Pionek12);
            szachownica[5, 1] = new Pionek(false, 5, 1, Pionek13);
            szachownica[6, 1] = new Pionek(false, 6, 1, Pionek14);
            szachownica[7, 1] = new Pionek(false, 7, 1, Pionek15);
            szachownica[1, 7] = new Skoczek(true, 1, 7, Skoczek0);
            szachownica[6, 7] = new Skoczek(true, 6, 7, Skoczek1);
            szachownica[2, 7] = new Goniec(true, 2, 7, Goniec0);
            szachownica[5, 7] = new Goniec(true, 5, 7, Goniec1);
            szachownica[2, 0] = new Goniec(false, 2, 0, Goniec2);
            szachownica[5, 0] = new Goniec(false, 5, 0, Goniec3);
            szachownica[0, 7] = new Wieza(true, 0, 7, Wieza0);
            szachownica[7, 7] = new Wieza(true, 7, 7, Wieza1);
            szachownica[3, 0] = new Hetman(false, 3, 0, Hetman1);
            szachownica[4, 7] = new Krol(true, 4, 7, Krol0);
            szachownica[4, 0] = new Krol(false, 4, 0, Krol1);
            szachownica[0, 0] = new Wieza(false, 0, 0, Wieza3);
            szachownica[7, 0] = new Wieza(false, 7, 0, Wieza2);
            szachownica[1, 0] = new Skoczek(false, 1, 0, Skoczek2);
            szachownica[6, 0] = new Skoczek(false, 6, 0, Skoczek3);
            szachownica[3, 7] = new Hetman(true, 3, 7, Hetman0);

        }


        private void Pionek0_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
            for (int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if(szachownica[i,j]!=null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                    }
                }
            }

            for(int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].obiekt==sender as Button&&szachownica[i,j].kolor==czy_ruch_bialych)
                    {
                        szachownica[i, j].czy_zaznaczone = true;
                        szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia);
                        //StreamWriter plik2 = new StreamWriter("Wznowienie2.txt");
                        //string kod2 = Generuj_FEN(szachownica, czy_ruch_bialych);
                        //plik2.WriteLine(kod2);
                        //plik2.Close();
                        //MessageBox.Show(i.ToString() + "\n" + j.ToString());

                        /*if (szachownica[2, 7].GetType() == typeof(Goniec))
                        {
                            MessageBox.Show("Aw dang it");
                        }*/
                        //MessageBox.Show(i.ToString() + "\n" + j.ToString());
                        return;
                    }
                }
            }
            
            /*if(czy_ruch_bialych)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j] != null)
                        {
                            if (szachownica[i, j].obiekt == Pionek0)
                            {
                                test = szachownica[i, j];
                                break;
                            }
                        }

                    }
                }
                Canvas.SetTop(Pionek0, Canvas.GetTop(test.obiekt) - 50);
                czy_ruch_bialych = false;
            }
            */
            //MessageBox.Show(Pionek0.GetType().ToString());
        }

        private void pole2_Click(object sender, RoutedEventArgs e)
        {
            
            double top, left;
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].czy_zaznaczone==true)
                    {
                        //MessageBox.Show(szachownica[i, j].czy_poprzednio_podwojny_ruch.ToString());
                        szachownica[i, j].czy_nie_wykonal_ruchu = false;
                        top = Canvas.GetTop(szachownica[i, j].obiekt);
                        left = Canvas.GetLeft(szachownica[i, j].obiekt);
                        Canvas.SetTop(szachownica[i, j].obiekt, Canvas.GetTop(sender as Button));
                        Canvas.SetLeft(szachownica[i, j].obiekt, Canvas.GetLeft(sender as Button));
                        //MessageBox.Show(szachownica[i, j].ToString());
                        if (szachownica[i, j].GetType() == typeof(Krol))
                        {
                            if (left-Canvas.GetLeft(szachownica[i,j].obiekt)>50)
                            {
                                if(szachownica[i,j].kolor==true)
                                {
                                    szachownica[3, 7] = new Wieza(true,3,7,szachownica[0,7].obiekt);
                                    szachownica[0, 7] = null;
                                    Canvas.SetTop(szachownica[3, 7].obiekt, Canvas.GetTop(sender as Button));
                                    Canvas.SetLeft(szachownica[3, 7].obiekt, Canvas.GetLeft(sender as Button)+50);
                                }
                                else
                                {
                                    szachownica[3, 0] = new Wieza(false, 3, 0, szachownica[0, 0].obiekt);
                                    szachownica[0, 0] = null;
                                    Canvas.SetTop(szachownica[3, 0].obiekt, Canvas.GetTop(sender as Button));
                                    Canvas.SetLeft(szachownica[3, 0].obiekt, Canvas.GetLeft(sender as Button) + 50);
                                }
                            }
                            else if(Canvas.GetLeft(szachownica[i, j].obiekt)-left>50)
                            {
                                if (szachownica[i, j].kolor == true)
                                {
                                    szachownica[5, 7] = new Wieza(true, 5, 7, szachownica[7, 7].obiekt);
                                    szachownica[7, 7] = null;
                                    Canvas.SetTop(szachownica[5, 7].obiekt, Canvas.GetTop(sender as Button));
                                    Canvas.SetLeft(szachownica[5, 7].obiekt, Canvas.GetLeft(sender as Button) - 50);
                                }
                                else
                                {
                                    szachownica[5, 0] = new Wieza(false, 5, 0, szachownica[7, 0].obiekt);
                                    szachownica[7, 0] = null;
                                    Canvas.SetTop(szachownica[5, 0].obiekt, Canvas.GetTop(sender as Button));
                                    Canvas.SetLeft(szachownica[5, 0].obiekt, Canvas.GetLeft(sender as Button) - 50);
                                }
                            }
                        }
                        else if (szachownica[i, j].GetType()==typeof(Pionek))
                        {
                            if(szachownica[i, j].kolor == true)
                            {
                                
                                if(i!=7&&Canvas.GetLeft(szachownica[i,j].obiekt)>left)
                                {
                                    if (szachownica[i + 1, j]!=null && szachownica[i+1,j].czy_poprzednio_podwojny_ruch)
                                    {
                                        szachownica[i + 1, j] = null;
                                    }
                                }
                                if (i!=0&&Canvas.GetLeft(szachownica[i, j].obiekt) < left)
                                {
                                    if (szachownica[i - 1, j]!=null && szachownica[i - 1, j].czy_poprzednio_podwojny_ruch)
                                    {
                                        szachownica[i - 1, j] = null;
                                    }
                                }
                                for (int x = 0; x < 8; x++)
                                {
                                    for (int y = 0; y < 8; y++)
                                    {
                                        if (szachownica[x, y] != null)
                                        {
                                            szachownica[x, y].czy_poprzednio_podwojny_ruch = false;
                                        }
                                    }
                                }
                                if (Canvas.GetTop(szachownica[i, j].obiekt) < top - 50)
                                {
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 8; y++)
                                        {
                                            if (szachownica[x, y] != null)
                                            {
                                                szachownica[x, y].czy_poprzednio_podwojny_ruch = false;
                                            }
                                        }
                                    }
                                    szachownica[i, j].czy_poprzednio_podwojny_ruch = true;
                                }
                                else
                                {
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 8; y++)
                                        {
                                            if (szachownica[x, y] != null)
                                            {
                                                szachownica[x, y].czy_poprzednio_podwojny_ruch = false;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                
                                if (i != 7 && Canvas.GetLeft(szachownica[i, j].obiekt) > left)
                                {
                                    if (szachownica[i + 1, j] != null && szachownica[i + 1, j].czy_poprzednio_podwojny_ruch)
                                    {
                                        szachownica[i + 1, j] = null;
                                    }
                                }
                                if (i != 0 && Canvas.GetLeft(szachownica[i, j].obiekt) < left)
                                {
                                    if (szachownica[i - 1, j] != null && szachownica[i - 1, j].czy_poprzednio_podwojny_ruch)
                                    {
                                        szachownica[i - 1, j] = null;
                                    }
                                }
                                for (int x = 0; x < 8; x++)
                                {
                                    for (int y = 0; y < 8; y++)
                                    {
                                        if (szachownica[x, y] != null)
                                        {
                                            szachownica[x, y].czy_poprzednio_podwojny_ruch = false;
                                        }
                                    }
                                }
                                if (Canvas.GetTop(szachownica[i, j].obiekt) > top + 50)
                                {
                                    szachownica[i, j].czy_poprzednio_podwojny_ruch = true;
                                }
                            }
                            
                            
                        }
                        else
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                for (int y = 0; y < 8; y++)
                                {
                                    if (szachownica[x, y] != null)
                                    {
                                        szachownica[x, y].czy_poprzednio_podwojny_ruch = false;
                                    }
                                }
                            }
                        }
                        for (int a = 0; a < 8; a++)
                        {
                            for (int b = 0; b < 8; b++)
                            {
                                if (podswietlenia[a, b] == sender as Button)
                                {
                                    //MessageBox.Show(podswietlenia[a,b].Name.ToString());
                                    szachownica[a, b] = szachownica[i, j];
                                    szachownica[a, b].pole_x = a;
                                    szachownica[a, b].pole_y = b;
                                    szachownica[i, j] = null;
                                    if(szachownica[a,b].GetType()==typeof(Pionek))
                                    {
                                        if(b==0)
                                        {
                                            szachownica[a, b] = new Hetman(true, a, b, szachownica[a, b].obiekt);
                                            szachownica[a, b].czy_zaznaczone = true;
                                            szachownica[a, b].obiekt.Content = FindResource("HetmanB");
                                            promocja.Visibility = Visibility.Visible;
                                            return;
                                            //goto koniec;
                                        }
                                        if(b==7)
                                        {
                                            szachownica[a, b] = new Hetman(false, a, b, szachownica[a, b].obiekt);
                                            szachownica[a, b].czy_zaznaczone = true;
                                            szachownica[a, b].obiekt.Content = FindResource("HetmanC");
                                            promocja.Visibility = Visibility.Visible;
                                            return;
                                            //goto koniec;
                                        }
                                    }
                                    /*if(szachownica[a,b].GetType()==typeof(Krol))
                                    {
                                        if(szachownica[a,b].czy_krol_szachowany(szachownica))
                                        {
                                            MessageBox.Show("Król jest szachowany");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Król nie jest szachowany");
                                        }
                                    }*/
                                    goto no_petla;
                                }
                            }
                        }
                        break;
                        //MessageBox.Show(Canvas.GetTop(this).ToString()+this.GetType().ToString());


                    }
                }
            }
            no_petla:
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility=Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].obiekt!=null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i,j].obiekt.Visibility=Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych;
            string kod = Generuj_FEN(szachownica,czy_ruch_bialych);
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            plik.Close();
            
            bool czy_sa_ruchy = false;
            for(int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    if(szachownica[i,j]!=null && szachownica[i,j].mozliwe_ruchy(szachownica, podswietlenia)&&szachownica[i,j].kolor==czy_ruch_bialych)
                    {
                        czy_sa_ruchy = true;
                        break;
                    }
                }
            }
            if(!czy_sa_ruchy)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j]!=null && szachownica[i,j].GetType()==typeof(Krol)&&szachownica[i,j].kolor==czy_ruch_bialych)
                        {
                            if(szachownica[i,j].czy_krol_szachowany(szachownica))
                            {
                                testing.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            else
                            {
                                testing1.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
        koniec:
            { }
        }
       
        private void Wznowienie_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    szachownica[i, j] = null;
                }
            }
            StreamReader wczytywanie = new StreamReader("Wznowienie.txt");
            string poprzednia_gra = wczytywanie.ReadLine();
            szachownica = generuj_szachownice(poprzednia_gra);
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].obiekt != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i, j].obiekt.Visibility = Visibility.Visible;
                    }
                }
            }
            wczytywanie.Close();
            Ekran_Startowy.Visibility = Visibility.Hidden;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Ekran_Startowy.Visibility = Visibility.Hidden;
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guzik_Hetman_Click(object sender, RoutedEventArgs e)
        {
            for (int i=0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    if(szachownica[i, j] != null && szachownica[i,j].czy_zaznaczone)
                    {
                        if(szachownica[i,j].kolor)
                        {
                            szachownica[i, j] = new Hetman(true, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("HetmanB");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Hetman(false, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("HetmanC");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                    }
                }
            }
            koniec_petli:
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].obiekt != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i, j].obiekt.Visibility = Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych;
            string kod = Generuj_FEN(szachownica, czy_ruch_bialych);
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            plik.Close();

            bool czy_sa_ruchy = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia) && szachownica[i, j].kolor == czy_ruch_bialych)
                    {
                        czy_sa_ruchy = true;
                        break;
                    }
                }
            }
            if (!czy_sa_ruchy)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == czy_ruch_bialych)
                        {
                            if (szachownica[i, j].czy_krol_szachowany(szachownica))
                            {
                                testing.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            else
                            {
                                testing1.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
            promocja.Visibility = Visibility.Hidden;
        }

        private void Guzik_Skoczek_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].czy_zaznaczone)
                    {
                        if (szachownica[i, j].kolor)
                        {
                            szachownica[i, j] = new Skoczek(true, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("SkoczekB");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Skoczek(false, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("SkoczekC");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                    }
                }
            }
        koniec_petli:
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].obiekt != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i, j].obiekt.Visibility = Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych;
            string kod = Generuj_FEN(szachownica, czy_ruch_bialych);
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            plik.Close();

            bool czy_sa_ruchy = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia) && szachownica[i, j].kolor == czy_ruch_bialych)
                    {
                        czy_sa_ruchy = true;
                        break;
                    }
                }
            }
            if (!czy_sa_ruchy)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == czy_ruch_bialych)
                        {
                            if (szachownica[i, j].czy_krol_szachowany(szachownica))
                            {
                                testing.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            else
                            {
                                testing1.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
            promocja.Visibility = Visibility.Hidden;
        }

        private void Guzik_Wieza_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].czy_zaznaczone)
                    {
                        if (szachownica[i, j].kolor)
                        {
                            szachownica[i, j] = new Wieza(true, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("WiezaB");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Wieza(false, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("WiezaC");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                    }
                }
            }
        koniec_petli:
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].obiekt != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i, j].obiekt.Visibility = Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych;
            string kod = Generuj_FEN(szachownica, czy_ruch_bialych);
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            plik.Close();

            bool czy_sa_ruchy = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia) && szachownica[i, j].kolor == czy_ruch_bialych)
                    {
                        czy_sa_ruchy = true;
                        break;
                    }
                }
            }
            if (!czy_sa_ruchy)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == czy_ruch_bialych)
                        {
                            if (szachownica[i, j].czy_krol_szachowany(szachownica))
                            {
                                testing.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            else
                            {
                                testing1.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
            promocja.Visibility = Visibility.Hidden;
        }

        private void Guzik_Goniec_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].czy_zaznaczone)
                    {
                        if (szachownica[i, j].kolor)
                        {
                            szachownica[i, j] = new Goniec(true, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("GoniecB");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Goniec(false, i, j, szachownica[i, j].obiekt);
                            szachownica[i, j].obiekt.Content = FindResource("GoniecC");
                            MessageBox.Show(szachownica[i, j].GetType().ToString());
                            goto koniec_petli;
                        }
                    }
                }
            }
        koniec_petli:
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].obiekt != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i, j].obiekt.Visibility = Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych;
            string kod = Generuj_FEN(szachownica, czy_ruch_bialych);
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            plik.Close();

            bool czy_sa_ruchy = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null && szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia) && szachownica[i, j].kolor == czy_ruch_bialych)
                    {
                        czy_sa_ruchy = true;
                        break;
                    }
                }
            }
            if (!czy_sa_ruchy)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j] != null && szachownica[i, j].GetType() == typeof(Krol) && szachownica[i, j].kolor == czy_ruch_bialych)
                        {
                            if (szachownica[i, j].czy_krol_szachowany(szachownica))
                            {
                                testing.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            else
                            {
                                testing1.Visibility = Visibility.Visible;
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.Close();
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                }
            }
            promocja.Visibility = Visibility.Hidden;
        }
    }
}
