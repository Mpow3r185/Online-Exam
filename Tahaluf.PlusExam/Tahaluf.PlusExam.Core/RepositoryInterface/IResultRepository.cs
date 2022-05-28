using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IResultRepository
    {
        //Get All Question
        List<Result> GetAllResult();
        //Create
        bool CreateResult(Result result);
        //Update
        bool UpdateResult(Result result);
        //Delete
        bool DeleteResult(int id);
    }
}
