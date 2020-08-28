using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BiblioteketOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Constructor
            Book book = new Book();
            #endregion

            #region Books
            //Opretter vores bøger som forskellige objekter.
            Book ACRevalations = new Book("Assasins Creed: Revalations", "Thriller", "White", 149.95);
            Book ACBlackflag = new Book("Assasins Creed: Black Flag", "Historical Fiction", "Black", 129.95);
            Book ACOdyssey = new Book("Assasins Creed: Odyssey", "Fiction", "Golden", 100);
            Book ACValhalla = new Book("Assasins Creed: Valhalla", "Adventure", "Red", 249.95);
            #endregion

            #region List with available books
            //Opretter listen "available books" som har type "Book" eftersom det er en bog vi vil have den skal indeholde.
            List<Book> availableBooks = new List<Book>(); //Har fået tilføjet alle de bøger tilgængelige via .add()
            availableBooks.Add(ACRevalations); //Tilføjer bog objektet til listen.
            availableBooks.Add(ACBlackflag);
            availableBooks.Add(ACOdyssey);
            availableBooks.Add(ACValhalla);
            #endregion

            #region basket (stack)
            Stack<Book> userBasket = new Stack<Book>();
            #endregion

            #region LogoIntro
            string lineLogo = string.Empty;
            int i = 0;
            Console.SetWindowSize(120, 42); //sets window size to 120 columns, and 42 rows
            Console.ForegroundColor = ConsoleColor.Green; //Sets text color to green
            // Read the file and display it line by line using System.IO.
            StreamReader fileLogo = new StreamReader(@"C:\Users\mads8340\source\repos\BiblioteketOOP\BiblioteketOOP\GUI Menus\LOGO.txt"); //tells streamreader to read from file location.
            while ((lineLogo = fileLogo.ReadLine()) != null) // Reads textfile to end
            {
                Console.SetCursorPosition(1, 0 + i); // Set the Cursor, used in center text
                Console.WriteLine(lineLogo); //Writes the string "line" chich prints the line we are on.
                i++; //adds a new line for each run through
            }
            fileLogo.Close(); // Close the file and streamreader.
            Thread.Sleep(2000); //laver voes function en tråd, så vi kan sætte den til at sove i 2 sekunder, så vi har vores billede oppe i 2 sekuner.
            Console.Clear(); //Clears the console.
            #endregion

            #region GUI
            do
            {
                #region GUI MENU
                string lineGUI = string.Empty;
                int j = 0;
                Console.SetWindowSize(109, 37); //sets window size to 120 columns, and 42 rows
                Console.ForegroundColor = ConsoleColor.Green; //Sets text color to green
                                                              // Read the file and display it line by line using System.IO.
                StreamReader fileGUI = new StreamReader(@"C:\Users\mads8340\source\repos\BiblioteketOOP\BiblioteketOOP\GUI Menus\GUI Menu.txt"); //tells streamreader to read from file location.
                while ((lineGUI = fileGUI.ReadLine()) != null) // Reads textfile to end
                {
                    Console.SetCursorPosition(0, 0 + j); // Set the Cursor, used in center text
                    Console.WriteLine(lineGUI); //Writes the string "line" chich prints the line we are on.
                    j++; //adds a new line for each run through
                }
                fileLogo.Close(); // Close the file and streamreader.
                Console.SetCursorPosition(20, 33);
                #endregion

                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();

                        bool addToBasket = true;
                        while (addToBasket == true)
                        {
                            Console.WriteLine("Bøger i din kurv:");
                            int l = 1;
                            foreach (Book bookInBasket in userBasket)
                            {
                                Console.WriteLine($"Item {l}: {bookInBasket.Name}");
                                l++;
                            }

                            Console.WriteLine("------------------------");

                            Console.WriteLine("Bøger tilgængelige:");

                            int k = 1;
                            foreach (Book bookinList in availableBooks)
                            {
                                Console.WriteLine($"{k}. {bookinList.Name}");
                                k++;
                            }
                            Console.WriteLine("5. Tilbage til menu.");

                            Console.WriteLine();

                            int userRentBookChoice = int.Parse(Console.ReadLine());

                            addToBasket = book.AddBookToBasket(availableBooks, userBasket, userRentBookChoice, addToBasket);

                            Console.WriteLine();
                        }

                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();

                        int m = 1;
                        Console.WriteLine("Bøger til checkouts:");
                        foreach (Book bookInBasket in userBasket)
                        {
                            Console.WriteLine($"Item {m}: {bookInBasket.Name}");
                            m++;
                        }

                        Console.WriteLine();

                        Console.WriteLine("Tryk 'ENTER'  for at fortsætte til tjekud:");
                        Console.ReadKey();


                        book.CheckOutBasket(userBasket);

                        Console.WriteLine("Dine bøger er nu chekket ud!");

                        Console.WriteLine("Tryk 'ENTER' for at afslutte program:");
                        Console.ReadLine();

                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            } while (true);
            #endregion
        }
    }
}
