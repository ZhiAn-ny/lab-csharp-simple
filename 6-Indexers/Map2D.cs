namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private IEnumerable<Tuple<TKey1, TKey2, TValue>> _elems;

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => _elems.Count();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => _elems.Where(e => e.Item1.Equals(key1) && e.Item2.Equals(key2))
                         .Select(e => e.Item3).First();
            set
            {
                var elems = _elems.ToList();
                if (elems.Select(e => new Tuple<TKey1, TKey2>(e.Item1, e.Item2)).Contains(new Tuple<TKey1, TKey2>(key1, key2)))
                {
                    var x = elems.Find(e
                        => e.Item1.Equals(key1) && e.Item2.Equals(key2));
                    elems.Remove(x);
                }
                elems.Add(new Tuple<TKey1, TKey2, TValue>(key1, key2, value));
                _elems = elems;
            }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return _elems.Where(e => e.Item1.Equals(key1))
                .Select(e => new Tuple<TKey2,TValue>(e.Item2, e.Item3))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return _elems.Where(e => e.Item2.Equals(key2))
                .Select(e => new Tuple<TKey1,TValue>(e.Item1, e.Item3))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return _elems.ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            var enumerator1 = keys1.GetEnumerator();
            var key2List = keys2.ToList();
            var elems = new List<Tuple<TKey1, TKey2, TValue>>();
            while (enumerator1.MoveNext())
            {
                var enumerator2 = key2List.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    elems.Add(new Tuple<TKey1, TKey2, TValue>(enumerator1.Current, enumerator2.Current, generator(enumerator1.Current, enumerator2.Current)));
                }
                enumerator2.Dispose();
            }
            _elems = elems;
            enumerator1.Dispose();
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other != null)
            {
                return GetHashCode().Equals(other.GetHashCode());
            }
            return false;
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj is IMap2D<TKey1, TKey2, TValue>)
            {
                return Equals(obj);
            }
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return GetElements().Select(e => e.GetHashCode()).Aggregate((e1, e2) => e1 + e2);
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            return _elems.Select(e => "[" + e.Item1 + "," + e.Item2 + "][" + e.Item3 + "]")
                .Aggregate((s1, s2) => s1 + " " + s2);
        }
    }
}
