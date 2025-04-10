﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public class ProductRepository : IProduct<Product>, IDisposable
    {
        ProductDBContext context = new ProductDBContext();

        public ProductRepository(ProductDBContext context)
        {
            this.context = context;
        }

        public Product Add(Product entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            context.AddRange(entities);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return context.Products.Find(predicate) as IEnumerable<Product>;
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public void Remove(Product entity)
        {
            context.Products.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            context.Products.RemoveRange(entities);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Product UpdateReorderLevel(int id, int reorderLevel)
        {
            var p = context.Products.Find(id);
            if (p != null)
            {
                p.ReorderLevel = reorderLevel;
                return p;
            }
            return null;
        }

        public Product Update(Product entity)
        {
            context.Products.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
