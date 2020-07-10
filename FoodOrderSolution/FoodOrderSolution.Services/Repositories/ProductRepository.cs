using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Helper.Core;
using FoodOrderSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductViewList> GetAlls(int id);
        IEnumerable<ProductViewList> GetAlls();
        IEnumerable<ProductViewList> GetSearch(string key);
        IEnumerable<ProductViewList> GetByCat(int id);
        ProductViewList GetDetail(long id);
        bool Add(ProductAddView model);
        ProductEditView GetEdit(long id);
        bool Edit(ProductEditView model);
        bool Delete(long id);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(ProductAddView model)
        {
            try
            {
                Product product = new Product();
                product.Avatar = "http://localhost:44379/" + model.Avatar;
                product.Category = model.Category;
                product.Content = model.Content;
                product.CreateBy = model.Vendor.ToString();
                product.CreateDate = DateTime.Now;
                product.Desc = model.Desc;
                product.IntendTime = model.IntendTime;
                product.ModifyBy = model.Vendor.ToString();
                product.ModifyDate = DateTime.Now;
                product.Price = model.Price;
                product.Status = model.Status;
                product.Title = model.Title;
                product.Vendor = model.Vendor;

                DbContext.Products.Add(product);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Product product = DbContext.Products.Find(id);
                if (product != null)
                {
                    product.Status = false;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(ProductEditView model)
        {
            try
            {
                Product product = DbContext.Products.Find(model.ID);
                if (product != null)
                {
                    if (!model.Avatar.Contains("http"))
                        product.Avatar = "http://localhost:44379/" + model.Avatar;
                    else
                        product.Avatar = model.Avatar;
                    product.Category = model.Category;
                    product.Content = model.Content;
                    product.Desc = model.Desc;
                    product.IntendTime = model.IntendTime;
                    product.Price = model.Price;
                    product.Status = model.Status;
                    product.Title = model.Title;
                    product.Vendor = model.Vendor;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<ProductViewList> GetAlls(int id)
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Vendors
                           where p.Vendor == v.ID
                           && p.Category == c.ID
                           && p.Vendor == id
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Vendor = v.Name
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Vendor = item.Vendor;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<ProductViewList> GetAlls()
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Vendors
                           where p.Vendor == v.ID
                           && p.Category == c.ID
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Vendor = v.Name,
                               IntendTime=p.IntendTime,
                               Rate=p.Rate
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Vendor = item.Vendor;
                        viewList.IntendTime = item.IntendTime;
                        viewList.Rate = item.Rate;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<ProductViewList> GetByCat(int id)
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Vendors
                           where p.Vendor == v.ID
                           && p.Category == c.ID
                           && p.Category == id
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Vendor = v.Name
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Vendor = item.Vendor;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public ProductViewList GetDetail(long id)
        {
            try
            {
                var _item = (from p in DbContext.Products
                             from c in DbContext.ProductCategorys
                             from v in DbContext.Vendors
                             where p.Vendor == v.ID
                             && p.Category == c.ID
                             && p.ID == id
                             && p.Status == true
                             select new
                             {
                                 ID = p.ID,
                                 Title = p.Title,
                                 Desc = p.Desc,
                                 Avatar = p.Avatar,
                                 Category = c.Title,
                                 Price = p.Price,
                                 Vendor = v.Name,
                                 VendorID=v.ID
                             }).FirstOrDefault();
                if (_item!=null && _item.ID != 0)
                {
                    ProductViewList viewList = new ProductViewList();
                    viewList.Avatar = _item.Avatar;
                    viewList.Category = _item.Category;
                    viewList.Desc = _item.Desc;
                    viewList.ID = _item.ID;
                    viewList.Price = _item.Price;
                    viewList.Title = _item.Title;
                    viewList.Vendor = _item.Vendor;
                    viewList.VendorID = _item.VendorID;
                    return viewList;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ProductEditView GetEdit(long id)
        {
            try
            {
                var product = DbContext.Products.Find(id);
                if (product != null)
                    return new ProductEditView { ID = product.ID, Avatar = product.Avatar, Category = product.Category, Content = product.Content, Desc = product.Desc, IntendTime = product.IntendTime, Price = product.Price, Status = product.Status, Title = product.Title, Vendor = product.Vendor };
                else
                    return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<ProductViewList> GetSearch(string key)
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Vendors
                           where p.Vendor == v.ID
                           && p.Category == c.ID
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Vendor = v.Name
                           };

                var _temp = _lst.ToList();
                key = key.ToNoSings(true).ToLowerCase();

                if (_lst != null && _lst.Count() > 0 && _temp.Where(x => x.Title.ToNoSings(true).ToLowerCase().Contains(key) || x.Category.ToNoSings(true).ToLowerCase().Contains(key)|| x.Vendor.ToNoSings(true).ToLowerCase().Contains(key)).Count() > 0)
                {
                    foreach (var item in _temp.Where(x => x.Title.ToNoSings(true).ToLowerCase().Contains(key) || x.Category.ToNoSings(true).ToLowerCase().Contains(key) || x.Vendor.ToNoSings(true).ToLowerCase().Contains(key)))
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Vendor = item.Vendor;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}
