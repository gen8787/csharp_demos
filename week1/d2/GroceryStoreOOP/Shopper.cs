using System.Collections.Generic;

namespace GroceryStoreOOP
{
    public class Shopper
    {
        public string Name { get; }
        private decimal wallet;
        private List<Product> shoppingList = new List<Product>();
        public List<Product> ShoppingCart { get; } = new List<Product>();

        // bring back the default 0 argument constructor to let us instantiate an empty shopper
        public Shopper() { }
        public Shopper(string name, List<Product> shoppingList)
        {
            // this.Name = name;
            Name = name;
            this.shoppingList = shoppingList;
        }

        public void EnterStore(GroceryStore store)
        {
            // pass "this" shopper into the specified grocery store
            store.ShopperEntering(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }

}