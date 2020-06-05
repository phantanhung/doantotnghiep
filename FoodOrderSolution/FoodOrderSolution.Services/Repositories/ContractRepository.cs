using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        IEnumerable<ContractView> GetAll();
        bool Edit(ContractView model);
        ContractView GetEdit(int id);
        bool StatusDelete(int id);
    }
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(IDbFactory dbFactory) : base(dbFactory)
        {

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
        public bool Edit(ContractView model)
        {
            try
            {
                var _item = DbContext.Contracts.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Code = model.Code;
                    _item.FileScan = model.FileScan;
                    _item.Note = model.Note;
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

        public IEnumerable<ContractView> GetAll()
        {
            try
            {
                List<ContractView> contracts = new List<ContractView>();
                var _lst = DbContext.Contracts.Where(x => x.Status > 0);
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ContractView contract = new ContractView();
                        contract.Code = item.Code;
                        contract.Date = item.Date;
                        contract.FileScan = item.FileScan;
                        contract.ID = item.ID;
                        contract.Note = item.Note;
                        contract.Status = item.Status;
                        contracts.Add(contract);
                    }
                    return contracts;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public ContractView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Contracts.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    ContractView contract = new ContractView();
                    contract.Code = _item.Code;
                    contract.Date = _item.Date;
                    contract.FileScan = _item.FileScan;
                    contract.ID = _item.ID;
                    contract.Note = _item.Note;
                    contract.Status = _item.Status;
                    return contract;
                }
                return new ContractView();
            }
            catch (System.Exception)
            {

                return new ContractView();
            }
        }
    }
}
