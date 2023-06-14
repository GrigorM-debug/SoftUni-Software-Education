using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index = -1;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current => books[index];

            object IEnumerator.Current => books[index];

            public bool MoveNext()
            {
                index++;

                if (index < books.Count())
                {
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {

            }//We dont need this right know
        }
    }

}
