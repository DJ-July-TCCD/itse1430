/*
 * Delendrick July
 * 11/12/2020
 * Lab 4 - Nile
 * ITSE 1430
 */
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        Product product;

        protected override void OnLoad( EventArgs e )
        {
            
            base.OnLoad(e);
            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd(object sender, EventArgs e)
        {
            var form = new ProductDetailForm();
            do
            {
                var child = new ProductDetailForm("Product Details");
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    AddProduct(form.Product);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Failed", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

               


                //Save product
                _database.Add(child.Product);
                UpdateList();
            } while (true);
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void AddProduct ( Product product)
        {
            _database.Add(product);

            UpdateList();
        }

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                DeleteProduct(product.Id);
            }catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Delete product
            _database.Remove(product.Id);
            UpdateList();
        }

        private void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                EditProduct(product.Id, form.Product);
            }catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch (Exception)
            {
                MessageBox.Show(this, "Failed", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Save product
            _database.Update(child.Product);
            UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            try
            {
                UpdateList(id, product);
            }catch (Exception e)
            {
                throw new InvalidOperationException("List Update Failed.", e);
            }
            _bsProducts.DataSource = _database.GetAll();
        }

        private readonly IProductDatabase _database = new Nile.Stores.MemoryProductDatabase();
        #endregion

        private void OnHelpAbout(object sender, EventArgs e)
        {
            _miHelp.Click += OnHelpAbout;

            var about = new AboutBox();

            about.ShowDialog(this);
        }
    }
}
