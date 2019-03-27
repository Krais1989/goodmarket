using System;
using System.Collections.Generic;

namespace GoodMarket.Domain
{
    public class Cart : IEntity
    {
        public class Record
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public DateTime Date { get; set; }
        }

        public int Id { get; set; }
        public IDictionary<int, int> Records { get; set; } = new Dictionary<int, int>();

        public Cart() { }
        public Cart(IDictionary<int,int> dict) { Records = new Dictionary<int, int>(dict); }

        #region Operations on records
        public int Count { get { return Records.Count; } }
        public bool IsEmpty { get { return Count == 0; } }
        public bool Contains(int prodId)
        {
            return Records.ContainsKey(prodId);
        }

        public int this[int prodId]
        {
            get
            {
                return Records.ContainsKey(prodId) ? Records[prodId] : 0;
            }
            set
            {
                if (Contains(prodId))
                    Records[prodId] = value;
                else
                    Records.Add(prodId, value);
            }
        }

        public void Add(int id, int count = 1)
        {
            if (!Records.ContainsKey(id))
                Records.Add(id, count);
            else
                Records[id] += count;
            if (Records[id] < 0) Records[id] = 0;
        }

        public void Add(IDictionary<int, int> records)
        {
            foreach (var pr in records)
            {
                Add(pr.Key, pr.Value);
            }
        }

        public void Add(Cart otherCart)
        {
            Add(otherCart.Records);
        }
        
        public void Remove(int id)
        {
            if (Records.ContainsKey(id))
                Records.Remove(id);
        }
        
        public void Clear()
        {
            Records.Clear();
        }
        #endregion
    }
}
