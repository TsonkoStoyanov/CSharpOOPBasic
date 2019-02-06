namespace P02_BookShop
{
    public class GoldenEditionBook : Book
    {
        private decimal _price;

        public GoldenEditionBook(string author, string title, decimal price)
: base(author, title, price)
        {
        }
        
        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }

        }
    }
}