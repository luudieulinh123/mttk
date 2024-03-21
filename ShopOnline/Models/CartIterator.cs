using System;
using System.Collections.Generic;

namespace ShopOnline.Models
{
    internal class CartIterator : IIterator
    {
        private List<Cart> listCart;

        public CartIterator(List<Cart> listCart)
        {
            this.listCart = listCart;
        }

        public bool IsDone => throw new NotImplementedException();

        public Cart CurrentItem => throw new NotImplementedException();

        public Cart First()
        {
            throw new NotImplementedException();
        }

        public void ForEachItem(Action<Cart> func)
        {
            throw new NotImplementedException();
        }

        public Cart Next()
        {
            throw new NotImplementedException();
        }
    }
}