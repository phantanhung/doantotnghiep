using FoodOrderSolution.Data.Models;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Services.Repositories
{
    public interface IVendorReplyRepository : IRepository<VendorReply>
    {
        bool Add(ReplyView model);
        IEnumerable<ReplyView> GetAll(long id);
        
    }
    public class VendorReplyRepository : RepositoryBase<VendorReply>, IVendorReplyRepository
    {
        public VendorReplyRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(ReplyView model)
        {
            try
            {
                VendorReply reply = new VendorReply();
                reply.Comment = model.Comment;
                reply.Date = DateTime.Now;
                reply.Feedback = model.Feedback;

                DbContext.VendorReplies.Add(reply);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<ReplyView> GetAll(long id)
        {
            try
            {
                List<ReplyView> replies = new List<ReplyView>();
                var _lst = from r in DbContext.VendorReplies
                           where r.Feedback == id
                           select new
                           {
                               Feedback = r.Feedback,
                               Comment = r.Comment,
                               Date = r.Date
                           };
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        ReplyView reply = new ReplyView();
                        reply.Comment = item.Comment;
                        reply.Date = item.Date;
                        reply.Feedback = item.Feedback;
                        replies.Add(reply);
                    }
                    return replies;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        
    }
}
