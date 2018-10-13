namespace Work4
{
    internal class Product
    {
        private string name;
        public string Name
        {
            get; set;
        }
        private float price;
        public float Price
        {
            get; set;
        }
        private int stock { get; set; }
        public int Stock
        {
            get; set;
        }
        public Product(string name, float price, int stock)
        {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
        }

        public string ToString()
        {
            return Name + " " ;
        }
       
    }
}