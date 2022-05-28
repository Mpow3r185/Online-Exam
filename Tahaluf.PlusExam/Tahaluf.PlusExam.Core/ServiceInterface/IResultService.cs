using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IResultService
    {
        //Get All Result
        List<Result> GetAllResult();
        //Create
        bool CreateResult(Result result);
        //Update
        bool UpdateResult(Result result);
        //Delete
        bool DeleteResult(int id);
    }
}
