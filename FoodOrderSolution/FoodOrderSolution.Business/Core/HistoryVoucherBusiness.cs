using FoodOrderSolution.Data.Models;
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
    public interface IHistoryVoucherBusiness
    {
        IEnumerable<HistoryVoucher> GetAlls(string[] includes, Expression<Func<HistoryVoucher, bool>> filter);
        IEnumerable<HistoryVoucher> GetAlls();
        HistoryVoucher Add(HistoryVoucher entity);
        HistoryVoucher Update(HistoryVoucher entity, List<Expression<Func<HistoryVoucher, object>>> update = null, List<Expression<Func<HistoryVoucher, object>>> exclude = null);
        HistoryVoucher Delete(int id);
        HistoryVoucher Delete(HistoryVoucher entity);
        void Save();
    }
   public class HistoryVoucherBusiness : IHistoryVoucherBusiness
    {
        private IHistoryVoucherRepository _historyVoucher;
        private IUnitOfWork _unitOfWork;
        public HistoryVoucherBusiness(IHistoryVoucherRepository historyVoucher,IUnitOfWork unitOfWork)
        {
            _historyVoucher = historyVoucher;
            _unitOfWork = unitOfWork;
        }

        public HistoryVoucher Add(HistoryVoucher entity)
        {
            return _historyVoucher.Add(entity);
        }

        public HistoryVoucher Delete(int id)
        {
            return _historyVoucher.Delete(id);
        }

        public HistoryVoucher Delete(HistoryVoucher entity)
        {
            return _historyVoucher.Delete(entity);
        }

        public IEnumerable<HistoryVoucher> GetAlls()
        {
            return _historyVoucher.GetAll(null);
        }

        public IEnumerable<HistoryVoucher> GetAlls(string[] includes, Expression<Func<HistoryVoucher, bool>> filter)
        {
            return _historyVoucher.GetAll(includes, filter);
        }

        public HistoryVoucher Update(HistoryVoucher entity, List<Expression<Func<HistoryVoucher, object>>> update = null, List<Expression<Func<HistoryVoucher, object>>> exclude = null)
        {
            return _historyVoucher.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
