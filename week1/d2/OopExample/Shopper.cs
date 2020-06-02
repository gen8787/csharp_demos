namespace OopExample
{
    public class Shopper
    {
        // auto implemented property
        public string Name { get; set; }
        private GroceryStore currentStore = null;

        // default parameterless constructor, if you have no constructor, this will be used even if you don't write it
        // if you create your own constructor, the default parameterless constructor will no longer be available
        // unless you add it back in
        public Shopper() { }
        public Shopper(string name)
        {
            this.Name = name;
            Name = name;
        }

        public void EnterStore(GroceryStore selectedStore)
        {
            currentStore = selectedStore;
            selectedStore.ShopperEntering(this);
        }

        public void ExitStore()
        {
            if (currentStore != null)
            {
                currentStore.ShopperExiting(this);
                currentStore = null;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}