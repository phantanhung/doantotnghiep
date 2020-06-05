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
    public interface IHistoryPointBusiness
    {
        IEnumerable<HistoryPoint> GetAlls(string[] includes, Expression<Func<HistoryPoint, bool>> filter);
        IEnumerable<HistoryPoint> GetAlls();
        HistoryPoint Add(HistoryPoint entity);
        HistoryPoint Update(HistoryPoint entity, List<Expression<Func<HistoryPoint, object>>> update = null, List<Expression<Func<HistoryPoint, object>>> exclude = null);
        HistoryPoint Delete(int id);
        HistoryPoint Delete(HistoryPoint entity);
        void Save();
    }
   public class HistoryPointBusiness : IHistoryPointBusiness
    {
        private IHistoryPointRepository _historyPoint;
        private IUnitOfWork _unitOfWork;
        public HistoryPointBusiness(IHistoryPointRepository historyPoint,IUnitOfWork unitOfWork)
        {
            _historyPoint = historyPoint;
            _unitOfWork = unitOfWork;
        }

        public HistoryPoint Add(HistoryPoint entity)
        {
            return _historyPoint.Add(entity);
        }

        public HistoryPoint Delete(int id)
        {
            return _historyPoint.Delete(id);
        }

        public HistoryPoint Delete(HistoryPoint entity)
        {
            return _historyPoint.Delete(entity);
        }

        public IEnumerable<HistoryPoint> GetAlls()
        {
            return _historyPoint.GetAll(null);
        }

        public IEnumerable<HistoryPoint> GetAlls(string[] includes, Expression<Func<HistoryPoint, bool>> filter)
        {
            return _historyPoint.GetAll(includes, filter);
        }

        public HistoryPoint Update(HistoryPoint entity, List<Expression<Func<HistoryPoint, object>>> update = null, List<Expression<Func<HistoryPoint, object>>> exclude = null)
        {
            return _historyPoint.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
