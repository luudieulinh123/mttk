using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using ShopOnline.Models;

namespace ShopOnline.Models
{
    public interface IIterator
    {
        Cart First();
        Cart Next();
        bool IsDone { get; }
        Cart CurrentItem { get; }
        void ForEachItem(Action<Cart> func);
    }
    public interface IProductIterator
    {
        Product First();
        Product Next();
        bool IsDone { get; }

        Product CurrentItem { get; }
        void ForEachItem(Action<Product> func);
    }
    public class ProductIterator : IProductIterator
    {
        readonly List<Product> _listProduct;
        int current = 0;
        readonly int step = 1;

        public ProductIterator(List<Product> listProduct)
        {
            _listProduct = listProduct;
        }

        public ProductIterator(ItemList listItems)
        {
            ListItems = listItems;
        }

        public bool IsDone
        {
            get { return current >= _listProduct.Count; }
        }

        public Product CurrentItem => _listProduct[current];

        public ItemList ListItems { get; }

        public Product First()
        {
            current = 0;
            if (_listProduct.Count > 0)
                return _listProduct[current];
            return null;
        }

        public Product Next()
        {
            current += step;
            if (!IsDone)
                return _listProduct[current];
            else
                return null;
        }


        public void ForEachItem(Action<Product> func)
        {
            int i = 0;
            while (i < _listProduct.Count)
            {
                func(_listProduct[index: i++]);
            }
        }
    }
}
