
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductModel
{
    public class GRNRepository : IGRN<GRN>
    {
        private readonly ProductDBContext _context;

        public GRNRepository(ProductDBContext context)
        {
            _context = context;
        }

        public GRN Get(int id)
        {
            return _context.GRNs
                .Include(g => g.GRNLines)
                .ThenInclude(gl => gl.associatedProduct)
                .FirstOrDefault(g => g.GrnID == id);
        }

        public IEnumerable<GRN> GetAll()
        {
            return _context.GRNs
                .Include(g => g.GRNLines)
                .ThenInclude(gl => gl.associatedProduct)
                .ToList();
        }


        // extra required methods
        public IEnumerable<GRN> Find(Expression<Func<GRN, bool>> predicate)
            => throw new NotImplementedException();

        public GRN Add(GRN entity)
            => throw new NotImplementedException();

        public GRN Update(GRN entity)
            => throw new NotImplementedException();

        public void AddRange(IEnumerable<GRN> entities)
            => throw new NotImplementedException();

        public void Remove(GRN entity)
            => throw new NotImplementedException();

        public void RemoveRange(IEnumerable<GRN> entities)
            => throw new NotImplementedException();
    }
}