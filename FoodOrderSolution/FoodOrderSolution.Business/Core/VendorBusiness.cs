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
    public interface IVendorBusiness
    {
        IEnumerable<Vendor> GetAlls(string[] includes, Expression<Func<Vendor, bool>> filter);
        IEnumerable<Vendor> GetAlls();
        IEnumerable<VendorView> GetAll();
        bool StatusDelete(int id);
        Vendor Add(VendorView entity);
        VendorView GetById(int id);
        Vendor Update(Vendor entity, List<Expression<Func<Vendor, object>>> update = null, List<Expression<Func<Vendor, object>>> exclude = null);
        Vendor Delete(int id);
        Vendor Delete(Vendor entity);
        bool ChangePass(ChangePassView model);
        ResponseVendorLogin Login(LoginModel model);
        void Save();
    }
   public class VendorBusiness : IVendorBusiness
    {
        private IVendorRepository _vendor;
        private IUnitOfWork _unitOfWork;
        public VendorBusiness(IVendorRepository vendor,IUnitOfWork unitOfWork)
        {
            _vendor = vendor;
            _unitOfWork = unitOfWork;
        }

        public Vendor Add(VendorView entity)
        {
            try
            {
                Vendor vendor = new Vendor();
                vendor.Account = entity.Account;
                vendor.Address = entity.Address;
                vendor.ContractCode = entity.ContractCode;
                vendor.Desc = entity.Desc;
                vendor.ID = entity.ID;
                vendor.Level = entity.Level;
                vendor.Mail = entity.Mail;
                vendor.Name = entity.Name;
                vendor.Password = "123456";
                vendor.Phone = entity.Phone;
                vendor.Status = entity.Status;
                vendor.TaxCode = entity.TaxCode;
                return _vendor.Add(vendor);
            }
            catch (Exception)
            {

               return null;
            }
        }

        public Vendor Delete(int id)
        {
            return _vendor.Delete(id);
        }

        public Vendor Delete(Vendor entity)
        {
            return _vendor.Delete(entity);
        }

        public IEnumerable<Vendor> GetAlls()
        {
            return _vendor.GetAll(null);
        }

        public IEnumerable<Vendor> GetAlls(string[] includes, Expression<Func<Vendor, bool>> filter)
        {
            return _vendor.GetAll(includes, filter);
        }

        public Vendor Update(Vendor entity, List<Expression<Func<Vendor, object>>> update = null, List<Expression<Func<Vendor, object>>> exclude = null)
        {
            return _vendor.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public ResponseVendorLogin Login(LoginModel model)
        {
            return _vendor.Login(model);
        }

        public VendorView GetById(int id)
        {
            return _vendor.GetById(id);
        }

        public bool ChangePass(ChangePassView model)
        {
            return _vendor.ChangePass(model);
        }

        public IEnumerable<VendorView> GetAll()
        {
            return _vendor.GetAll();
        }

        public bool StatusDelete(int id)
        {
            return _vendor.StatusDelete(id);
        }
    }
}
