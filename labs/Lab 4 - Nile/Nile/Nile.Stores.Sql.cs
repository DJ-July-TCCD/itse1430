using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public class Nile
    {
        public class Product
        {
        }
    }

    public class SqlProductDatabase : IProductDatabase
    {
        public SqlProductDatabase( string connectionStrings)
        {
            connectionStrings = connString;
        }

        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
