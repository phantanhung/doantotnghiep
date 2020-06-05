using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using FoodOrderSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Business.Core
{
    public interface IVendorLevelBusiness
    {
        IEnumerable<VendorLevel> GetAlls(string[] includes, Expression<Func<VendorLevel, bool>> filter);
        IEnumerable<VendorLevel> GetAlls();
        IEnumerable<VendorLevelView> GetAll();
        VendorLevel Add(VendorLevelView entity);
        VendorLevel Update(VendorLevel entity, List<Expression<Func<VendorLevel, object>>> update = null, List<Expression<Func<VendorLevel, object>>> exclude = null);
        VendorLevel Delete(int id);
        VendorLevelView GetEdit(int id);
        bool Edit(VendorLevelView model);
        VendorLevel Delete(VendorLevel entity);
        bool StatusDelete(int id);
        void Save();
    }
    public class VendorLevelBusiness : IVendorLevelBusiness
    {
        private IVendorLevelRepository _vendorLevel;
        private IUnitOfWork _unitOfWork;
        public VendorLevelBusiness(IVendorLevelRepository vendorLevel, IUnitOfWork unitOfWork)
        {
            _vendorLevel = vendorLevel;
            _unitOfWork = unitOfWork;
        }

        public VendorLevel Add(VendorLevelView entity)
        {
            try
            {
                VendorLevel level = new VendorLevel();
                level.ID = entity.ID;
                level.Level = entity.Level;
                level.Name = entity.Name;
                level.Percentage = entity.Percentage;
                level.PostLimit = entity.PostLimit;
                level.Status = entity.Status;

                return _vendorLevel.Add(level);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public VendorLevel Delete(int id)
        {
            return _vendorLevel.Delete(id);
        }

        public VendorLevel Delete(VendorLevel entity)
        {
            return _vendorLevel.Delete(entity);
        }

        public IEnumerable<VendorLevel> GetAlls()
        {
            return _vendorLevel.GetAll(null);
        }

        public IEnumerable<VendorLevel> GetAlls(string[] includes, Expression<Func<VendorLevel, bool>> filter)
        {
            return _vendorLevel.GetAll(includes, filter);
        }

        public VendorLevel Update(VendorLevel entity, List<Expression<Func<VendorLevel, object>>> update = null, List<Expression<Func<VendorLevel, object>>> exclude = null)
        {
            return _vendorLevel.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<VendorLevelView> GetAll()
        {
            return _vendorLevel.GetAll();
        }

        public VendorLevelView GetEdit(int id)
        {
            return _vendorLevel.GetEdit(id);
        }

        public bool Edit(VendorLevelView model)
        {
            return _vendorLevel.Edit(model);
        }

        public bool StatusDelete(int id)
        {
            return _vendorLevel.StatusDelete(id);
        }
    }
}
