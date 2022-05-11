
namespace Wisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            string litera;
            string slowo;
            string slowostring;

            string[,] szubienica = new string[7, 1];                                    //tworzenie tablicy string
            szubienica[0, 0] = ("       ╔===╗  ");                                      //rysowanie szubienicy
            szubienica[1, 0] = ("       ║   │  ");                                      //"
            szubienica[2, 0] = ("       ║   O  ");                                      //"
            szubienica[3, 0] = ("       ║  /║) ");                                      //"
            szubienica[4, 0] = ("       ║  //  ");                                      //"
            szubienica[5, 0] = ("       ║      ");                                      //"
            szubienica[6, 0] = ("     ==╩==    ");                                      //"

            string znaki = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";                       //określanie znaków dozwolonych 

            Console.SetCursorPosition(1, 1);                                            //przemieszczenie kursora na pozycję (1,1)
            Console.BackgroundColor = ConsoleColor.White;                               //zmiana koloru tła na biały
            Console.ForegroundColor = ConsoleColor.Black;                               //zmiana koloru czcionki na czarny
            Console.WriteLine("=======================");                               //podkreślenie          "      
            Console.SetCursorPosition(1, 2);                                            //przemieszczenie kursora na pozycję (1,1)
            Console.WriteLine("WITAJ W GRZE SZUBIENICA");                               //zaproszenie do gry
            Console.SetCursorPosition(1, 3);                                            //przemieszczenie kursora na pozycję (1,3)
            Console.WriteLine("=======================");                               //podkreślenie          "              
            Console.BackgroundColor = ConsoleColor.Black;                               //zmiana koloru tła na czarny
            Console.ForegroundColor = ConsoleColor.White;                               //zmiana koloru czcionki na biały
            //---------------------------------------------------------
            Console.SetCursorPosition(1, 5);                                            //przemieszczenie kursora na pozycję (1,5)
            Console.Write("Dozwolone znaki: aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż ");     //wypisanie informacji o dozwolonych znakach 
            Console.SetCursorPosition(1, 8);                                            //przemieszczenie kursora na pozycję (1,8)
            Console.Write("Podaj SŁOWO - ZAGADKĘ : ");                                  //zaproszenie do wprowadzenia zagadki
            slowo = Console.ReadLine();                                                 //wprowadzenie zagadki
            int length = slowo.Length;                                                  //badanie długości zagadki

            for (int z = 0; z < slowo.Length; z++)                                           //pętla sprawdzająca, czy użytkownik podał w zagadce niedozwolone znaki
            {
                if (znaki.Contains(slowo[z]))                                            //warunek sprawdzający czy znak z zagadki zawiera się z ciągu znaków niedozwolonych
                { }                                                                     //jeśli podana litera zawiera się w ciągu dozwolonym to przechodzin dalej...
                else                                                                    //jeśli podana ltera nie zawiera się w znakach podzwolonych to wykonuje poniższe...
                {
                    Console.SetCursorPosition(1, 11);                                           //przemieszczenie kursora na pozycję (1,11)
                    Console.WriteLine("SŁOWO - ZAGADKA zawiera niedozwolony znak ");            //program wypisuje powiadomienie o niedozwolonym znaku
                    Console.SetCursorPosition(1, 13);                                           //przemieszczenie kursora na pozycję (1,13)
                    Console.BackgroundColor = ConsoleColor.White;                               //zmiana koloru tła na biały
                    Console.ForegroundColor = ConsoleColor.Black;                               //zmiana koloru czcionki na czarny
                    Console.Write("PRZYCIŚNIJ ENTER");                                          //komunikat o konieczności przyciśnięcia ENTER
                    Console.BackgroundColor = ConsoleColor.Black;                               //zmiana koloru tła na czarny
                    Console.ForegroundColor = ConsoleColor.White;                               //zmiana koloru czcionki na biały
                    Console.Read();                                                             //ENTER
                    return;                                                                     //wyjście z pętli
                }
            }

            //-----------------------------------------------------------                                                                           
            slowostring = "";                                                                   //zerowanoie ciągu przechowującego zagadkę    

            string[] slowocale = new string[30];                                                //utworzenie tablicy do przechowywania odgadniętych liter 
                                                                                                //w ich naturalnej pozycji
            for (int i = 0; i < slowo.Length; i++)                                              //pętla - wypełnienie tablicy znakami "-" długość zagadki
            {                                                                                   //"
                slowocale[i] = "-";                                                             //" przypisanie znaki "-" na pozycji tablicy [i]
            }                                                                                   //"
            //-------------------------------------------------------------------------------------------------------                                                                           
            Console.Clear();                                                             //czyszczenie consoli
            int tak = 0;                                                                 //ustawienie znacznika informującego o tym czy literaz została odgadnięta 0=nieodgadnięta
            Console.SetCursorPosition(1, 3);                                             //przemieszczenie kursora na pozycję (1,3)
            Console.Write("Szukane słowo : ");
            for (int li = 0; li < slowo.Length; li++)                                    //Pętla wyświetla znaki z tablicy stanu odgadniętych liter
            {                                                                            //         "
                Console.Write(slowocale[li]);                                            //         "
                slowostring = slowostring + slowocale[li];                               //         "
            }

            for (int k = 7; k > -1; k--)                                                 //Pętka sprawdzająca odgadywania
            {
                if (k == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(1, 2);                                                                //Wyświetlenie komunikatu PORAŻKI
                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;       //"
                    Console.WriteLine("NIE ODGADŁEŚ - szukane słowo to : " + slowo);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    return;
                }
                if (tak == 1)                                                            //zachowuje poprzednią ilość dostępnych prób (nie odejmuje)
                { k = k + 1; }                                                           //      "
                tak = 0;                                                               //zeruje test odgadnięcie na "0=nieodgadnięty"
                Console.SetCursorPosition(1, 6);
                Console.WriteLine("Pozostało Prób:  " + k);                              //Wyświetlenie informacji o ilości pozostałych prób 

                for (int s = 0; s < k + 1; s++)                                          //tworzy wolne-puste miejsce na rysunek szubienicy
                { Console.WriteLine(""); }                                               //"

                for (int s = k; s < 7; s++)                                              //rysowanie szubienicy zgodnie z wartościami z tablicy "szubienica"
                { Console.WriteLine(szubienica[s, 0]); }                                 //"    

                Console.SetCursorPosition(1, 16);
                Console.Write("Podaj litere: "); litera = Console.ReadLine();            //Wprowadzanie litery do analizy
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("           ");
                if (litera.Length > 1)                                                   //Warunek - jeśli gracz podał więcej niż jeden znak
                                                                                         //oznacza, że gracz próbuje odgadnąć całe słowo-zagadkę

                    if (litera == slowo)                                                                                //Warunek - jeśli gracz odgadł zagadkę podając całe słowo
                    {                                                                                                   //"
                        Console.Clear();                                                                                //"
                        Console.SetCursorPosition(1, 2);                                                                //wyświetlenie GRATULACJI
                        Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;     //"
                        Console.WriteLine("BRAWO ODGADŁEŚ SŁOWO : " + slowo);                                           //"
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;     //"
                        break;                                                                                          //"
                    }
                    else                                                                                                //Jeśli gracz nie odgadł całego słowa-zagadki
                    {
                        Console.Clear();
                        Console.SetCursorPosition(1, 2);                                                                //Wyświetlenie komunikatu PORAŻKI
                        Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black;       //"
                        Console.WriteLine("NIE ODGADŁEŚ - szukane słowo to : " + slowo);                                //"
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;     //"

                        Console.SetCursorPosition(0, 6);                             				         //Wyświetlenie szubienicy
                        for (int s = 0; s < 7; s++)                                                          //"
                        {                                                                                    //"
                            Console.WriteLine(szubienica[s, 0]);                                             //"
                        }                                                                                    //"

                        break;
                    }
                else                                                                     //Jeśli gracz podał jedną literę, odgaduje dalej...
                {
                    for (int i = 0; i < slowo.Length; i++)                               //Pętla sprawdzająca czy zagadka zawiera podaną literę
                    {
                        if (litera == slowo[i].ToString())                               //Warunek - jeśli zagadka zawiera podaną wcześniej literę
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(1, 1);
                            Console.WriteLine("Zgadłeś :) ");                            //Wyświetlenie komunikatu potwierdzającego odgadnięcie litery
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            slowocale[i] = litera;                                       //wprowadzenie odgadniętej litery na odp. miejscu w tablicy     

                            tak = 1;                                                     //przypisanie pozytywnego wynik odgadnięcia litery "1=odgadnięcie"

                            Console.SetCursorPosition(1, 3);
                            Console.Write("Szukane słowo : ");                           //Wyświetlenie komunikatu  
                            slowostring = "";
                            for (int li = 0; li < slowo.Length; li++)                    //Pętla wyświetla znaki z tablicy stanu odgadniętych liter
                            {                                                            //
                                Console.Write(slowocale[li]);                            //          "
                                slowostring = slowostring + slowocale[li];               //          "
                            }                                                            //          "
                            Console.WriteLine("");
                            if (slowo == slowostring)                                                                         //Warunek - jeśli całe słowo zagadka zgadza się z tablicą stanu odgadniętych liter
                            {                                                                                                 //"
                                Console.Clear();                                                                              //"
                                Console.SetCursorPosition(1, 2);                                                              //"
                                Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;   //"
                                Console.WriteLine("BRAWO ODGADŁEŚ SŁOWO : " + slowo);                                         //wyświetlenie komunikat GRATULACJI
                                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;   //"
                                k = 0;
                            }
                            Console.WriteLine("");                                       //linia przerwy
                            Console.WriteLine("");                                       //linia przerwy
                        }


                    }
                }

            }
            Console.Read();                                                              //oczekiwanie na przyciśnięcie ENTER 
        }
    }
}



