using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Yoga.Net
{
    public class YogaNodes : IList<YogaNode>
    {
        public YogaNode Owner { get; set; }
        List<YogaNode> _nodes;

        public YogaNodes()
        {
            _nodes = new List<YogaNode>();
        }
        public YogaNodes(int capacity)
        {
            _nodes = new List<YogaNode>(capacity);
        }
        public YogaNodes(IEnumerable<YogaNode> collection)
        {
            _nodes = new List<YogaNode>(collection);
        }

        /// <inheritdoc />
        public IEnumerator<YogaNode> GetEnumerator() => _nodes.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(YogaNode item)
        {
            if (item == null)
                return;

            _nodes.Add(item);
            if (item.Owner == null)
                item.Owner = Owner;
        }

        public void AddRange(IEnumerable<YogaNode> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        
        /// <inheritdoc />
        public void Clear() => _nodes.Clear();

        /// <inheritdoc />
        public bool Contains(YogaNode item) => _nodes.Contains(item);

        /// <inheritdoc />
        public void CopyTo(YogaNode[] array, int arrayIndex) => _nodes.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(YogaNode item) => _nodes.Remove(item);

        /// <inheritdoc />
        public int Count => _nodes.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public int IndexOf(YogaNode item) => _nodes.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, YogaNode item) => _nodes.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index) => _nodes.RemoveAt(index);

        /// <inheritdoc />
        public YogaNode this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }
    }
}
