/*
 * Delendrick July
 * 11/12/2020
 * Lab 4 - Nile
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            var exisiting = Get(product.Name);
            if (exisiting != null)
                throw new InvalidOperationException("The product must be unique!");

            if (product == null)
                throw new ArgumentNullException(nameof(product));
            IValidatableObject.(product);

            try
            {

            }catch (Exception e)
            {
                throw new InvalidOperationException("Product Add Failed.", e);
            }

            //Emulate database by storing copy
           return AddCore(product);
        }

        protected abstract object Get(string name);

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            try
            {

            }catch (Exception e)
            {
                throw new InvalidOperationException("Get Failed.", e);
            }

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            try
            {
                RemoveCore(id);
            }catch (Exception e)
            {
                throw new InvalidOperationException("Add Failed", e);
            }

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( int id, Product product )
        {  
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID msut be greater than zero.");
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Product must be unique!");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
