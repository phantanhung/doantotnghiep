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
    public interface IContractBusiness
    {
        IEnumerable<Contract> GetAlls(string[] includes, Expression<Func<Contract, bool>> filter);
        IEnumerable<Contract> GetAlls();
        Contract Add(ContractView entity);
        IEnumerable<ContractView> GetAll();
        Contract Update(Contract entity, List<Expression<Func<Contract, object>>> update = null, List<Expression<Func<Contract, object>>> exclude = null);
        bool Edit(ContractView entity);
        Contract Delete(int id);
        ContractView GetEdit(int id);
        bool StatusDelete(int id);
        Contract Delete(Contract entity);
        void Save();
    }
    public class ContractBusiness : IContractBusiness
    {
        private IContractRepository _contract;
        private IUnitOfWork _unitOfWork;
        public ContractBusiness(IContractRepository contract, IUnitOfWork unitOfWork)
        {
            _contract = contract;
            _unitOfWork = unitOfWork;
        }

        public Contract Add(ContractView entity)
        {

            try
            {
                Contract contract = new Contract();
                contract.Code = entity.Code;
                contract.Date = DateTime.Now;
                contract.FileScan = entity.FileScan;
                contract.ID = entity.ID;
                contract.Note = entity.Note;
                contract.Status = entity.Status;

                return _contract.Add(contract);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Contract Delete(int id)
        {
            return _contract.Delete(id);
        }

        public Contract Delete(Contract entity)
        {
            return _contract.Delete(entity);
        }

        public IEnumerable<Contract> GetAlls()
        {
            return _contract.GetAll(null);
        }

        public IEnumerable<Contract> GetAlls(string[] includes, Expression<Func<Contract, bool>> filter)
        {
            return _contract.GetAll(includes, filter);
        }

        public Contract Update(Contract entity, List<Expression<Func<Contract, object>>> update = null, List<Expression<Func<Contract, object>>> exclude = null)
        {
            return _contract.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ContractView> GetAll()
        {
            return _contract.GetAll();
        }

        public bool Edit(ContractView entity)
        {
            return _contract.Edit(entity);
        }

        public ContractView GetEdit(int id)
        {
            return _contract.GetEdit(id);
        }

        public bool StatusDelete(int id)
        {
            return _contract.StatusDelete(id);
        }
    }
}
