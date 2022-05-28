using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public bool CreateResult(Result result)
        {
            return _resultRepository.CreateResult(result);
        }

        public bool DeleteResult(int id)
        {
            return _resultRepository.DeleteResult(id);
        }

        public List<Result> GetAllResult()
        {
            return _resultRepository.GetAllResult();
        }

        public bool UpdateResult(Result result)
        {
            return _resultRepository.UpdateResult(result);
        }
    }
}
