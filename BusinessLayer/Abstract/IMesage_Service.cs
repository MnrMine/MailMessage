using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMesage_Service:IGeneric_Service<Message>
    {
        List<Message> GetListSenderMessage(string p);
        List<Message> GetListReceiverMessage(string p);

        List<Message> GetListDeleteMessage();
    }
}
