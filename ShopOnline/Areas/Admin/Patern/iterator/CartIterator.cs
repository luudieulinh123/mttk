using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.iterator
{
    public class CartIterator : IIterator<Cart>
    {
        private List<Cart> _listCart;
        private int _index;

        public CartIterator(List<Cart> listCart)
        {
            _listCart = listCart;
            _index = 0;
        }

        public bool HasNext()
        {
            return _index < _listCart.Count;
        }

        public Cart Next()
        {
            if (HasNext())
            {
                Cart nextItem = _listCart[_index];
                _index++;
                return nextItem;
            }
            throw new InvalidOperationException("không");
        }
    }
}