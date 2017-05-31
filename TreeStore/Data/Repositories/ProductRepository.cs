using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStore.Data.Interface;
using TreeStore.Models;

namespace TreeStore.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
           
        }

        public IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            string localSearch = search.Trim();
            var searchWords = localSearch.Split(' ');
            var query = this.DbContext.Products.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    DateTime dDate;
                    bool dateParsed = false;
                    if (DateTime.TryParse(sSearch, out dDate))
                    {
                        dDate = DateTime.Parse(sSearch);
                        dateParsed = true;
                    }
                    query = query.Where(p => p.Name.Contains(sSearch)/*Ürünün ismine göre arama*/ || 
                    p.Category.Name.Contains(sSearch) /*Kategorinin ismine göre arama*/ || 
                    p.Category.Campaign.Name.Contains(sSearch)/*Kampanyanın ismine göre arama*/);
                }
            }
            var allProduct = query;

            IEnumerable<Product> filteredProducts = allProduct;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredProducts = allProduct.OrderBy(c => c.Name);
                        break;
                    case 1:
                        //filteredProducts = allProduct.OrderBy(c => c.ProductCampaign.
                        break;
                    case 2:
                        filteredProducts = allProduct.OrderBy(c => c.Category.Name);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredProducts = allProduct.OrderByDescending(c => c.Name);
                        break;
                    case 1:
                        //filteredProducts = allProduct.OrderByDescending(c => c.ProductCampaign.Where(pc => pc.ProductId == c.Id).Ca
                        break;
                    case 2:
                        filteredProducts = allProduct.OrderByDescending(c => c.Category.Name);
                        break;
                    default:
                        break;
                }
            }
            var displayedProducts = filteredProducts.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedProducts = displayedProducts.Take(displayLength);
            }
            totalRecords = allProduct.Count();
            totalDisplayRecords = filteredProducts.Count();
            return displayedProducts.ToList();
        }
    }
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
