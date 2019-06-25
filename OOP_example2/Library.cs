using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_example2 {
    class Library {
        //LibraryBook[] books;
        List<LibraryBook> books = new List<LibraryBook>();

        public Library() {
            //books = new LibraryBook[0];
            books.Capacity = 0;
        }

        public Library(int n) {
            //books = new LibraryBook[n];
            books.Capacity = n;
        }

        public void Add(LibraryBook book) {
            //Array.Resize(ref books, books.Length + 1);
            //books[books.Length - 1] = book;
            books.Add(book);
        }

        public override string ToString() {
            string result = "\n\nLibrary (" + this.GetLength() + " books):\n";

            //foreach (LibraryBook book in books)
            foreach (var book1 in books)
                result += (book1 == null || book1.IsDeleted == true ? "" : book1.ToString()) + "\n";

            return result;
        }

        public bool Remove(int n) {
            //if (n >= 0 && n < books.Length && !books[n].IsDeleted)
            if (n >= 0 && n < books.Count && !books[n].IsDeleted)
                return (books[n].IsDeleted = true);

            return false;
        }

        public int GetLength() {
            int n = 0;

            //foreach (LibraryBook book in books)
            foreach (var book1 in books)
                if (book1 != null && !book1.IsDeleted)
                    n++;

            return n;
        }

        public LibraryBook BookAt(int n) {
            //if (n < 0 || n >= books.Length)
            if (n < 0 || n >= books.Count)
                return null;

            return books[n];
        }

        public Library FindByTitle(string title) {
            Library result = new Library();

            //foreach (LibraryBook book in books)
            foreach (var book1 in books)
                if (book1 != null && book1.FindByTitle(title) == true)
                    //result.Add(new LibraryBook(book));
                    result.Add(book1);

            return result;
        }

    }
}
