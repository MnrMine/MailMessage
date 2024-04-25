using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Mesage_Manager:IMesage_Service
    {
        IMesage_Dal _mesageDal;

        public Mesage_Manager(IMesage_Dal mesageDal)
        {
            _mesageDal = mesageDal;
        }

        public List<Message> GetListDeleteMessage()
        {
            return _mesageDal.GetByFilter(x => x.Status == false);
        }

        public List<Message> GetListReceiverMessage(string p)
        {
            return _mesageDal.GetByFilter(x => x.ReceiverMail == p);

        }

        public List<Message> GetListSenderMessage(string p)
        {
            return _mesageDal.GetByFilter(x => x.SenderMail == p);
        }

        public void TDelete(int id)
        {
            _mesageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _mesageDal.GetByID(id);
        }

        public List<Message> TGetListAll()
        {
            return _mesageDal.GetList();
        }

        public void TInsert(Message t)
        {
            _mesageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _mesageDal.Update(t);
        }
    }
}
