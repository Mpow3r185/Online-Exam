using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IDynamicHomeService
    {
        // Get All
        List<DynamicHome> GetAll();

        // Update Home
        bool UpdateHome(DynamicHome dynamicHome);
    }
}
