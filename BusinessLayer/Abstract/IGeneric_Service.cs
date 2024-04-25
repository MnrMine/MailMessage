using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGeneric_Service<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(int id);

        List<T> TGetListAll();
        T TGetById(int id);
    }
}
