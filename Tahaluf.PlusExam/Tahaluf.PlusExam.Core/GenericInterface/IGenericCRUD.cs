using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.GenericInterface
{
    public interface IGenericCRUD<T> where T : class
    {
        dynamic GetAll();
        bool Create(T entity);
        bool Delete(int id);
        bool Update(T entity);
    }
}
