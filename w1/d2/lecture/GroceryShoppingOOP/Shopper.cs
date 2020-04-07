namespace GroceryShoppingOOP
{
    public class Shopper
    {
        public string Name { get; set; }
        private decimal _budget;


        public Shopper(string name, decimal budget)
        {
            // this.Name = name;
            Name = name;
            _budget = budget;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}