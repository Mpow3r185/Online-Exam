using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IDynamicHomeRepository
    {
        // Get All
        List<DynamicHome> GetAll();

        // Update Home
        bool UpdateHome(DynamicHome dynamicHome);
    }
}
