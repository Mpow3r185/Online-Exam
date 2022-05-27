using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tahaluf.PlusExam.Core.Common
{
    public interface IDbContext
    {
        public DbConnection Coonection { get; }
    }
}
