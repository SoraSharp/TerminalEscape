namespace Terminal_Escape.Game
{
    internal class Inventory
    {
        private readonly List<string> _items = new();
        public IReadOnlyList<string> Items => _items;
        public bool Has(string itemId) => _items.Contains(itemId);
        public void Add(string itemId)
        {
            if (!Has(itemId))
            {
                _items.Add(itemId);
            }
        }
        public void ClearItems() => _items.Clear();
    }
}
