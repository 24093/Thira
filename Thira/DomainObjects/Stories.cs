using System.Collections.Generic;

namespace Alkl.Thira.DomainObjects
{
    internal class Stories
    {
        private readonly Dictionary<uint, uint> _items = new Dictionary<uint, uint>();

        public uint this[uint level]
        {
            get
            {
                EnsureKeyExsits(level);
                return _items[level];
            }
        }

        public void AddStories(uint level, uint count)
        {
            EnsureKeyExsits(level);
            _items[level] += count;
        }

        private void EnsureKeyExsits(uint key)
        {
            if (!_items.ContainsKey(key)) _items.Add(key, 0);
        }
    }
}