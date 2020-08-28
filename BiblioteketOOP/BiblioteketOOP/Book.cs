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

        public Book(string bookName, string bookGenre, string bookColor, double bookPrice)
        {
            Name = bookName;
            Genre = bookGenre;
            Color = bookColor;
            Price = bookPrice;
        }
        #endregion

        #region Methods
        public bool AddBookToBasket(List<Book> availableBooks, Stack<Book> UserBasket, int BookToBasket, bool addToBasket) // ADD TO BASKET SHOULD NOT BE HERE (SHOULD BE IN A PERSON CLASS)
        {
            switch (BookToBasket)
            {
                case 1:
                    UserBasket.Push(availableBooks[0]);
                    availableBooks.RemoveAt(0);
                    break;
                case 2:
                    UserBasket.Push(availableBooks[1]);
                    availableBooks.RemoveAt(1);
                    break;
                case 3:
                    UserBasket.Push(availableBooks[2]);
                    availableBooks.RemoveAt(2);
                    break;
                case 4:
                    UserBasket.Push(availableBooks[3]);
                    availableBooks.RemoveAt(3);
                    break;
                case 5:
                    addToBasket = false;
                    break;
                default:
                    addToBasket = false;
                    break;
            }
            return addToBasket;
        }

        public void CheckOutBasket(Stack<Book> UserBasket)
        {
            UserBasket.Peek();
            UserBasket.Pop();
        }
        #endregion
    }
}
