using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace P02_BookShop
{
    public class Book
    {
        private string title;

        private string author;

        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get => title;

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public string Author
        {
            get => author;


            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author not valid!");

                }

                string[] authorInfo = value.Split();

                if (authorInfo.Length > 1)
                {
                    char first = authorInfo[1].First();

                    if (char.IsDigit(first))
                    {
                        throw new ArgumentException("Author not valid!");
                    }

                }

              
                author = value;
            }
        }

        public virtual decimal Price
        {
            get => price;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

    }
}