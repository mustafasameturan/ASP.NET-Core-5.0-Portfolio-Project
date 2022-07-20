using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserMessageManager : IUserMessageService
    {
        private IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public void Add(UserMessage t)
        {
            _userMessageDal.Add(t);
        }

        public void Delete(UserMessage t)
        {
            _userMessageDal.Delete(t);
        } 

        public UserMessage GetById(int id)
        {
            var getById = _userMessageDal.GetById(id);
            return getById;
        }

        public List<UserMessage> GetList()
        {
            var getList = _userMessageDal.GetList();
            return getList;
        }

        public List<UserMessage> GetListReceiverMessage(string p)
        {
            var getByFilter = _userMessageDal.GetByFilter(x => x.Receiver == p);
            return getByFilter;
        }

        public List<UserMessage> GetListSenderMessage(string p)
        {
            var getByFilter = _userMessageDal.GetByFilter(x => x.Sender == p);
            return getByFilter;
        }

        public void Update(UserMessage t)
        {
            _userMessageDal.Update(t);
        }
    }
}
