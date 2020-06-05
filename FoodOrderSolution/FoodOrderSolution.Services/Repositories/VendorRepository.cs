using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        ResponseVendorLogin Login(LoginModel model);
        VendorView GetById(int id);
        bool ChangePass(ChangePassView model);
        IEnumerable<VendorView> GetAll();
        bool StatusDelete(int id);
    }
    public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool ChangePass(ChangePassView model)
        {
            try
            {
                var _item = DbContext.Vendors.FirstOrDefault(x => x.Account == model.Account && x.Password == model.OldPass);
                if (_item != null && _item.Account != "")
                {
                    _item.Password = model.NewPass;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<VendorView> GetAll()
        {
            try
            {
                List<VendorView> vendors = new List<VendorView>();
                var _lst = DbContext.Vendors.Where(x => x.Status > 0);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        VendorView vendor = new VendorView();
                        vendor.Account = item.Account;
                        vendor.Address = item.Address;
                        vendor.ContractCode = item.ContractCode;
                        vendor.ID = item.ID;
                        vendor.Level = item.Level;
                        vendor.Mail = item.Mail;
                        vendor.Name = item.Name;
                        vendor.Phone = item.Phone;
                        vendor.TaxCode = item.TaxCode;
                        vendors.Add(vendor);
                    }
                    return vendors;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public VendorView GetById(int id)
        {
            try
            {
                var _item = (from v in DbContext.Vendors
                             where v.ID == id
                             select new
                             {
                                 ID = v.ID,
                                 Name = v.Name,
                                 Address = v.Address,
                                 Phone = v.Phone,
                                 Mail = v.Mail,
                                 TaxCode = v.TaxCode,
                                 ContractCode = v.ContractCode,
                                 Level = v.Level,
                                 Account = v.Account
                             }).FirstOrDefault();
                if (_item != null && _item.ID != 0)
                {
                    VendorView vendor = new VendorView();
                    vendor.Account = _item.Account;
                    vendor.Address = _item.Address;
                    vendor.ContractCode = _item.ContractCode;
                    vendor.ID = _item.ID;
                    vendor.Level = _item.Level;
                    vendor.Mail = _item.Mail;
                    vendor.Name = _item.Name;
                    vendor.Phone = _item.Phone;
                    vendor.TaxCode = _item.TaxCode;
                    return vendor;
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public ResponseVendorLogin Login(LoginModel model)
        {
            try
            {
                ResponseVendorLogin response = new ResponseVendorLogin();
                var vendor = DbContext.Vendors.FirstOrDefault(x => x.Account == model.Username && x.Password == model.Password);
                if (vendor != null)
                {
                    response.ID = vendor.ID;
                    response.Mail = vendor.Mail;
                    response.Name = vendor.Name;
                    response.Phone = vendor.Phone;
                    response.TaxCode = vendor.TaxCode;
                    return response;
                }
                else
                    return null;

            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public bool StatusDelete(int id)
        {
            try
            {
                var _item = DbContext.Vendors.Find(id);
                if(_item!=null && _item.ID != 0)
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
