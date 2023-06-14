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
        Figura[,] szachownica = new Figura[8, 8]; //tablica przechowująca obiekty podklas klasy Figura
        Button[,] podswietlenia = new Button[8, 8]; //Tablica przycisków symbolizujących możliwe ruchy figury
        bool czy_ruch_bialych = true; //zmienna ustalająca czyi ruch jest w danej pozycji
        List<String> poprzednie_pozycje = new List<String>(); //Lista pozycji które wcześniej wystąpiły podczas partii

        string Generuj_FEN(Figura[,] szachownica, bool czyi_ruch) //Funkcja generująca kod reprezentujący daną pozycję na szachownicy
        {
            string kod = "";
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)//Sprawdzanie każdego pola na szachownicy i przypisanie odpowiadającej wartości do kodu
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
            if (czyi_ruch) //przypisanie wartości odpowiadającej za to czyi gracz może się ruszyć
                kod += "b";
            else
                kod += "c";
            if(szachownica[4,7]!=null && szachownica[4,7].GetType()==typeof(Krol)&&szachownica[4,7].czy_nie_wykonal_ruchu) //Sprawdzanie możliwości roszady dla królów
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
        Figura[,] generuj_szachownice(string kod) //Funkcja tworząca tablicę figur na podstawie kodu generowanego powyżej
        {
            
            Figura[,] szachownica = new Figura[8, 8];
            //Stworzenie list wszystkich przycisków na podstawie ich nazwy oraz ich rodzajów figury
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
            foreach (Button pion in biale_pionki) //Przypisywanie przyciskom odpowiadającym za pionki odpowiednich obrazków
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Zdjecia\\Pionek_B.png", UriKind.Relative));
                pion.Content = img;
            }
            foreach (Button pion in czarne_pionki)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Zdjecia\\Pionek_C.png", UriKind.Relative));
                pion.Content = img;
            }
            foreach (char litera in kod) //Przypisanie wartości kodu do szachownicy oraz przesunięcie przycisków na odpowiednie pola
            {
                switch (litera) //Wyjaśnienie symboli w dokumentacji
                {
                    case '/':
                        continue;
                    case 'x':
                        szachownica[i % 8, i / 8] = null;
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
                        //Jeśli na szachownicy znajduje się więcej figur danego typu niż w pozycji początkowej to przypisujemy jej przycisk z listy pionków (oznacza to, że w partii nastąpiła promocja pionka na tą figurę)
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
                            szachownica[i % 8, i / 8] = new Skoczek(false, i % 8, i / 8, czarne_pionki[0]);
                            Canvas.SetTop(czarne_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_pionki[0], 218 + ((i % 8) * 50));
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Skoczek_C.png", UriKind.Relative));
                            czarne_pionki[0].Content = img;
                            czarne_pionki.Remove(czarne_pionki[0]);
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Skoczek_B.png", UriKind.Relative));
                            biale_pionki[0].Content = img;
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
                            szachownica[i % 8, i / 8] = new Goniec(false, i % 8, i / 8, czarne_pionki[0]);
                            Canvas.SetTop(czarne_pionki[0], 17 + ((i / 8) * 50));
                            Canvas.SetLeft(czarne_pionki[0], 218 + ((i % 8) * 50));
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Goniec_C.png", UriKind.Relative));
                            czarne_pionki[0].Content = img;
                            czarne_pionki.Remove(czarne_pionki[0]);
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Goniec_B.png", UriKind.Relative));
                            biale_pionki[0].Content = img;
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Wieza_C.png", UriKind.Relative));
                            czarne_pionki[0].Content = img;
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Wieza_B.png", UriKind.Relative));
                            biale_pionki[0].Content = img;
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Hetman_C.png", UriKind.Relative));
                            czarne_pionki[0].Content = img;
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Hetman_B.png", UriKind.Relative));
                            biale_pionki[0].Content = img;
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
        
        public MainWindow()
        {
            
            InitializeComponent();
            if (!File.Exists("Wznowienie.txt"))//dodanie pliku tekstowego do programu w przypadku jego nieistnienia. Plik tekstowy zawiera w pierwszej linijce ostatnią pozycję w partii a w drugiej linijce wszystkie poprzednie pozycje w partii
            {
                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr"; //Pozycja początkowa
                StreamWriter plik = new StreamWriter("Wznowienie.txt");
                plik.WriteLine(poczatek);
                plik.WriteLine(poczatek);
                plik.Close();
            }
            //Dodanie przycisków odpowiadających za możliwe ruchy do tablicy podswietlenia
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
            

        }


        private void Pionek0_Click_1(object sender, RoutedEventArgs e) //Zdarzenie wyświetlające wszystkie legalne ruchy wciśniętej figury
        {
            for (int i = 0; i < 8; i++) //Wyłączenie poprzednich podświetleń
            {
                for (int j = 0; j < 8; j++)
                {
                    podswietlenia[i, j].Visibility = Visibility.Hidden;
                    if (szachownica[i, j] != null)
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                    }
                }
            }

            for(int i=0; i<8; i++) //Szukanie zaznaczonego przycisku wśród figur w tablicy szachownica
            {
                for (int j=0; j<8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].obiekt==sender as Button&&szachownica[i,j].kolor==czy_ruch_bialych)
                    {
                        szachownica[i, j].czy_zaznaczone = true;
                        szachownica[i, j].mozliwe_ruchy(szachownica, podswietlenia);
                        return;
                    }
                }
            }
            
        }

        private void pole2_Click(object sender, RoutedEventArgs e) //Zdarzenie przesuwające ostatnią wciśniętą figurę na wciśnięte pole
        {
            int ilosc_figur = 0;
            double top, left;
            for(int i=0; i<8; i++)//Sprawdzenie ilości figur przed wykonaniem ruchu
            {
                for(int j=0; j<8; j++)
                {
                    if (szachownica[i, j] != null)
                        ilosc_figur++;
                }
            }
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].czy_zaznaczone==true) //szukanie ostatniej zaznaczonej figury
                    {
                        //przesunięcie figury
                        szachownica[i, j].czy_nie_wykonal_ruchu = false;
                        top = Canvas.GetTop(szachownica[i, j].obiekt);
                        left = Canvas.GetLeft(szachownica[i, j].obiekt);
                        Canvas.SetTop(szachownica[i, j].obiekt, Canvas.GetTop(sender as Button));
                        Canvas.SetLeft(szachownica[i, j].obiekt, Canvas.GetLeft(sender as Button));
                        if (szachownica[i, j].GetType() == typeof(Krol))
                        {
                            //W przypadku ruchu króla sprawdzamy, czy nie nastąpiła roszada. Jeśli nastąpiła to przesuwamy również odpowiednią wieżę
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
                            //Jeśli przesuniętą figurą jest pionek to sprawdzamy czy nastąpiło bicie w przelocie. Jeśli tak to usuwamy odpowiedniego pionka przeciwnika
                            //Reset listy poprzednich pozycji
                            poprzednie_pozycje = new List<string>();
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
                                if (Canvas.GetTop(szachownica[i, j].obiekt) < top - 50) //ustawienie właściwości czy_poprzednio_podwójny_ruch dla białego pionka, który wykonuje podwójny ruch
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
                                    //ustawienie właściwości czy_poprzednio_podwójny_ruch dla czarnego pionka, który wykonuje podwójny ruch
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
                                    //Przypisanie przesuwanej figury na odpowiednie pole w tablicy szachownica
                                    szachownica[a, b] = szachownica[i, j];
                                    szachownica[a, b].pole_x = a;
                                    szachownica[a, b].pole_y = b;
                                    szachownica[i, j] = null;
                                    if(szachownica[a,b].GetType()==typeof(Pionek))
                                    {
                                        //Sprawdzanie przypadku, gdy pionek dojdzie na koniec planszy. Wtedy ukazuje się ekran pozwalający na zamianę pionka w inną figurę
                                        if(b==0)
                                        {
                                            promocja.Visibility = Visibility.Visible;
                                            return;
                                        }
                                        if(b==7)
                                        {
                                            promocja.Visibility = Visibility.Visible;
                                            return;
                                        }
                                    }
                                    goto no_petla; //wyjście z powyższych pętli
                                }
                            }
                        }
                        break;


                    }
                }
            }
            no_petla:
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null)
                        ilosc_figur--;
                }
            }
            if(ilosc_figur > 0)//Sprawdzenie, czy figura została zbita. Jeśli tak, to lista poprzednich pozycji zostaje wyczyszczona
            {
                poprzednie_pozycje = new List<string>();
            }
            foreach (var przycisk in Plansza.Children.OfType<Button>())
            {
                przycisk.Visibility=Visibility.Hidden;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(szachownica[i,j]!=null&&szachownica[i,j].obiekt!=null) //Pokazanie przycisków figur, które nie zostały zbite
                    {
                        szachownica[i, j].czy_zaznaczone = false;
                        szachownica[i,j].obiekt.Visibility=Visibility.Visible;
                    }
                }
            }
            czy_ruch_bialych = !czy_ruch_bialych; //Zmiana strony wykonującej ruch
            string kod = Generuj_FEN(szachownica,czy_ruch_bialych),wszystkie_pozycje="";
            poprzednie_pozycje.Add(kod); //dodanie nowej pozycji do pliku tekstowego i listy poprzednich pozycji
            StreamWriter plik = new StreamWriter("Wznowienie.txt");
            plik.WriteLine(kod);
            foreach (string pozycje in poprzednie_pozycje)
            {
                //MessageBox.Show(pozycje);
                wszystkie_pozycje += pozycje + " ";
            }
            plik.WriteLine(wszystkie_pozycje);
            plik.Close();
            if(poprzednie_pozycje.Count==100) //Sprawdzenie, czy dany gracz nie wykonał 50 posunięć. Jeśli warunek jest prawdziwy, to ogłaszany jest remis (zgodnie z zasadą 50 posunięć)
            {
                Remis.Visibility = Visibility.Visible;
                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";//Zamiana pliku tak, by odzwierciedlała początkową pozycję
                plik = new StreamWriter("Wznowienie.txt");
                plik.WriteLine(poczatek);
                plik.WriteLine(poczatek);
                plik.Close();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        podswietlenia[i, j].Visibility = Visibility.Hidden; //Ukrycie wszystkich podświetleń
                    }
                }
                return;
            }
            for (int i = 0; i < poprzednie_pozycje.Count; i++)
            {
                int ilosc_powtorzen = 1;
                for (int j = i+1; j < poprzednie_pozycje.Count; j++)
                {
                    if(poprzednie_pozycje[i]==poprzednie_pozycje[j]) //Sprawdzenie, czy którakolwiek pozycja się powtórzyła 3-krotnie. Jeśli tak to partia kończy się remisem
                    {
                        ilosc_powtorzen++;
                        if(ilosc_powtorzen==3)
                        {
                            Remis.Visibility = Visibility.Visible;
                            string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                            plik = new StreamWriter("Wznowienie.txt");
                            plik.WriteLine(poczatek);
                            plik.WriteLine(poczatek);
                            plik.Close();
                            for (int a = 0; a < 8; a++)
                            {
                                for (int b = 0; b < 8; b++)
                                {
                                    podswietlenia[a, b].Visibility = Visibility.Hidden;
                                }
                            }
                            return;
                        }
                    }
                }
            }
            ilosc_figur = 0;
            for (int i = 0; i < 8; i++)//Sprawdzenie ilości figur po wykonaniu ruchu
            {
                for (int j = 0; j < 8; j++)
                {
                    if (szachownica[i, j] != null)
                        ilosc_figur++;
                }
            }
            if(ilosc_figur == 2) //Jeśli ilość figur wynosi 2 oznacza to że na szachownicy zostały same króle i jest to remis
            {
                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                plik = new StreamWriter("Wznowienie.txt");
                plik.WriteLine(poczatek);
                plik.WriteLine(poczatek);
                plik.Close();
                Remis.Visibility = Visibility.Visible;
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        podswietlenia[a, b].Visibility = Visibility.Hidden;
                    }
                }
                return;
            }
            else if(ilosc_figur==3) //Jeśli ilość figur wynosi 3 oznacza to że na szachownicy zostały 2 króle i 1 inna figura. Jeśli tą figurą jest goniec lub skoczek to partia kończy się remisem
            {
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if(szachownica[a,b]!=null&&(szachownica[a,b].GetType()==typeof(Goniec) || szachownica[a, b].GetType() == typeof(Skoczek)))
                        {
                            string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                            plik = new StreamWriter("Wznowienie.txt");
                            plik.WriteLine(poczatek);
                            plik.WriteLine(poczatek);
                            plik.Close();
                            Remis.Visibility = Visibility.Visible;
                            for (int x = 0; x < 8; x++)
                            {
                                for (int y = 0; y < 8; y++)
                                {
                                    podswietlenia[x, y].Visibility = Visibility.Hidden;
                                }
                            }
                            return;
                        }
                    }
                }
                return;
            }
            bool czy_sa_ruchy = false;
            for(int i=0; i<8; i++) //Sprawdzanie, czy strona która ma wykonać ruch może wykonać jakikolwiek ruch
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
            if(!czy_sa_ruchy) //Jeśli strona wykonująca ruch nie może wykonać ruchu to sprawdzamy czy jest szachowana. Jeśli tak to partia kończy się zwycięstwem przeciwnika, jeśli nie to jest to pat i kończy się remisem.
            {
                poprzednie_pozycje = new List<string>();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (szachownica[i, j]!=null && szachownica[i,j].GetType()==typeof(Krol)&&szachownica[i,j].kolor==czy_ruch_bialych)
                        {
                            if(szachownica[i,j].czy_krol_szachowany(szachownica))
                            {
                                //Nadpisanie pliku na pozycję początkową i wyświetlenie ekranu wygranej
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                if(!czy_ruch_bialych)
                                {
                                    Wygrana_bialych.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    Wygrana_czarnych.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            { 
                                //Wyświetlenie ekranu remisu
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                Remis.Visibility = Visibility.Visible;
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
            { }
        }
       
        private void Wznowienie_Click(object sender, RoutedEventArgs e) //Wznowienie wcześniej rozpoczętej partii
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    szachownica[i, j] = null;
                }
            }
            StreamReader wczytywanie = new StreamReader("Wznowienie.txt"); //Wczytanie ostatniej pozycji z pliku
            string poprzednia_gra = wczytywanie.ReadLine();
            szachownica = generuj_szachownice(poprzednia_gra);
            //ukrycie niepotrzebnych przycisków na szachownicy
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
            poprzednia_gra = wczytywanie.ReadLine();
            poprzednie_pozycje = new List<string>();
            string[] lista_pozycji = poprzednia_gra.Split(' ');
            foreach(string pozycja in lista_pozycji) //zapisanie poprzednich pozycji z partii, zapisanych w pliku, do listy poprzednie_pozycje
            {
                poprzednie_pozycje.Add(pozycja);
            }
            poprzednie_pozycje.Remove(" ");
            wczytywanie.Close();
            Ekran_Startowy.Visibility = Visibility.Hidden;
            powrot.Visibility = Visibility.Visible;
        }

        private void Start_Click(object sender, RoutedEventArgs e)//Rozpoczęcie nowej partii
        {
            szachownica = generuj_szachownice("wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr"); //Pozycja startowa
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
            //Ukrycie wszystkich wyświetlonych ekranów poza szachownicą
            Wygrana_bialych.Visibility = Visibility.Hidden;
            Wygrana_czarnych.Visibility = Visibility.Hidden;
            poprzednie_pozycje = new List<string> { "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr" };
            Ekran_Startowy.Visibility = Visibility.Hidden;
            powrot.Visibility = Visibility.Visible;
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e) //Wyjście z programu
        {
            this.Close();
        }

        private void Guzik_Hetman_Click(object sender, RoutedEventArgs e) //Zmiana pionka na hetmana
        {
            for (int i=0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    if(szachownica[i, j] != null && szachownica[i,j].czy_zaznaczone)
                    {
                        if(szachownica[i,j].kolor) //Sprawdzenie koloru hetmana
                        {
                            szachownica[i, j] = new Hetman(true, i, j, szachownica[i, j].obiekt);
                            //Przypisanie nowego obrazka przyciskowi odpowiadającego za zamienianego pionka
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Hetman_B.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Hetman(false, i, j, szachownica[i, j].obiekt);
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Hetman_C.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
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
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                if (!czy_ruch_bialych)
                                {
                                    Wygrana_bialych.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    Wygrana_czarnych.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                Remis.Visibility = Visibility.Visible;
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

        private void Guzik_Skoczek_Click(object sender, RoutedEventArgs e) //Zmiana pionka na Skoczka
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Skoczek_B.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Skoczek(false, i, j, szachownica[i, j].obiekt);
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Skoczek_C.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
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
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                if (!czy_ruch_bialych)
                                {
                                    Wygrana_bialych.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    Wygrana_czarnych.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                Remis.Visibility = Visibility.Visible;
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

        private void Guzik_Wieza_Click(object sender, RoutedEventArgs e)//Zmiana pionka na wieżę
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Wieza_B.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Wieza(false, i, j, szachownica[i, j].obiekt);
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Wieza_C.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
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
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                if (!czy_ruch_bialych)
                                {
                                    Wygrana_bialych.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    Wygrana_czarnych.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                Remis.Visibility = Visibility.Visible;
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

        private void Guzik_Goniec_Click(object sender, RoutedEventArgs e)//Zmiana pionka na gońca
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
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Goniec_B.png",UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
                            //szachownica[i, j].obiekt.Content = FindResource("GoniecB");
                            goto koniec_petli;
                        }
                        else
                        {
                            szachownica[i, j] = new Goniec(false, i, j, szachownica[i, j].obiekt);
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("Zdjecia\\Goniec_C.png", UriKind.Relative));
                            szachownica[i, j].obiekt.Content = img;
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
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                if (!czy_ruch_bialych)
                                {
                                    Wygrana_bialych.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    Wygrana_czarnych.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                string poczatek = "wsghkgsw/pppppppp/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/PPPPPPPP/WSGHKGSW/bQRqr";
                                plik = new StreamWriter("Wznowienie.txt");
                                plik.WriteLine(poczatek);
                                plik.WriteLine(poczatek);
                                plik.Close();
                                Remis.Visibility = Visibility.Visible;
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

        private void Powrot_Click(object sender, RoutedEventArgs e)//Powrót do ekranu startowego
        {
            promocja.Visibility = Visibility.Hidden;
            Ekran_Startowy.Visibility = Visibility.Visible;
            Wygrana_bialych.Visibility = Visibility.Hidden;
            Wygrana_czarnych.Visibility = Visibility.Hidden;
            Remis.Visibility = Visibility.Hidden;
            powrot.Visibility = Visibility.Hidden;
        }
    }

}
