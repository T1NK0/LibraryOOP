using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BiblioteketOOP
{
    class Book
    {
        #region Book Variables
        private string name; //private name variable
        private string genre; //private genre variable
        private string color; //private color variable
        private double price; //private price variable
        #endregion

        #region Get Set
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        #region Constructors
        public Book()
        {

        }

        public Book(string bookName, string bookGenre, string bookColor, double bookPrice) //Our book constructor.
        {
            Name = bookName;
            Genre = bookGenre;
            Color = bookColor;
            Price = bookPrice;
        }
        #endregion

        #region Methods
        //Gets tje list of books, our stack (basket) our user input on book to put in basket, and our bool to check if we should continue running the while, or we exit the add to basket.
        public bool AddBookToBasket(List<Book> availableBooks, Stack<Book> userBasket, int BookToBasket, bool addToBasket) // ADD TO BASKET SHOULD NOT BE HERE (SHOULD BE IN A PERSON CLASS)
        {
            switch (BookToBasket)//Cheks on the user input
            {
                case 1:
                    userBasket.Push(availableBooks[0]); //gests the basket (stack) and pushes the book, on index 0 of the book list into the stack
                    availableBooks.RemoveAt(0); //Removes the book from the avaialable books list so they wont be available for the user to access.
                    break;
                case 2:
                    userBasket.Push(availableBooks[1]);
                    availableBooks.RemoveAt(1);
                    break;
                case 3:
                    userBasket.Push(availableBooks[2]);
                    availableBooks.RemoveAt(2);
                    break;
                case 4:
                    userBasket.Push(availableBooks[3]);
                    availableBooks.RemoveAt(3);
                    break;
                case 5:
                    addToBasket = false; //If user inputs 5, return false so we break our loop, and the user gets returned to the menu.
                    break;
                default:
                    addToBasket = false; //If user inputs a wrong input, we get returned to our menu, due to breaking the loop.
                    break;
            }
            return addToBasket;//If there is no more books, return false, so we break the loop and get returned to the menu.
        }

        public void CheckOutBasket(Stack<Book> UserBasket) //calls the stack, so we can access our items in our basket.
        {
            UserBasket.Peek(); //Looks at the top item in the stack.
            UserBasket.Pop(); //removes the top item, by "popping it off the top" / removing it.
        }
        #endregion
    }
}
