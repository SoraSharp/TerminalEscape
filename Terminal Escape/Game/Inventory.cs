namespace Terminal_Escape.Game
{
    internal class Inventory
    {
        private readonly List<string> _items = new();
        public IReadOnlyList<string> Items => _items;
        public void Add(string itemId)
        {
            if (!_items.Contains(itemId))
            {
                _items.Add(itemId);
            }
        }
        public void ClearItems() => _items.Clear();
    }
}
