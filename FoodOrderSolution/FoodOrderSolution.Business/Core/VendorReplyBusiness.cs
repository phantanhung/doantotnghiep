using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using FoodOrderSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Business.Core
{
    public interface IVendorReplyBusiness
    {
        bool Add(ReplyView entity);
        IEnumerable<ReplyView> GetAll(long id);
        void Save();
    }
    public class VendorReplyBusiness: IVendorReplyBusiness
    {
        private IVendorReplyRepository _reply;
        private IUnitOfWork _unitOfWork;
        public VendorReplyBusiness(IVendorReplyRepository VendorReply, IUnitOfWork unitOfWork)
        {
            _reply = VendorReply;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ReplyView entity)
        {
            return _reply.Add(entity);
        }

        public IEnumerable<ReplyView> GetAll(long id)
        {
            return _reply.GetAll(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
