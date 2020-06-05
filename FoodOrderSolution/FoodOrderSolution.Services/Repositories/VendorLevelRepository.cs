using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IVendorLevelRepository : IRepository<VendorLevel>
    {
        IEnumerable<VendorLevelView> GetAll();
        VendorLevelView GetEdit(int id);
        bool Edit(VendorLevelView model);
        bool StatusDelete(int id);
    }
    public class VendorLevelRepository : RepositoryBase<VendorLevel>, IVendorLevelRepository
    {
        public VendorLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Edit(VendorLevelView model)
        {
            try
            {
                var _item = DbContext.VendorLevels.Find(model.ID);
                if(_item!=null && _item.ID != 0)
                {
                    _item.Level = model.Level;
                    _item.Name = model.Name;
                    _item.Percentage = model.Percentage;
                    _item.PostLimit = model.PostLimit;
                    _item.Status = model.Status;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<VendorLevelView> GetAll()
        {
            try
            {
                List<VendorLevelView> views = new List<VendorLevelView>();
                var _lst = DbContext.VendorLevels.Where(x => x.Status > 0);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        VendorLevelView view = new VendorLevelView();
                        view.ID = item.ID;
                        view.Level = item.Level;
                        view.Name = item.Name;
                        view.Percentage = item.Percentage;
                        view.PostLimit = item.PostLimit;
                        views.Add(view);
                    }
                    return views;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public VendorLevelView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.VendorLevels.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    VendorLevelView view = new VendorLevelView();
                    view.ID = _item.ID;
                    view.Level = _item.Level;
                    view.Name = _item.Name;
                    view.Percentage = _item.Percentage;
                    view.PostLimit = _item.PostLimit;
                    view.Status = _item.Status;
                    return view;
                }
                return new VendorLevelView();
            }
            catch (System.Exception)
            {

                return new VendorLevelView();
            }
        }

        public bool StatusDelete(int id)
        {
            try
            {
                var _item = DbContext.VendorLevels.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Status = -1;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
