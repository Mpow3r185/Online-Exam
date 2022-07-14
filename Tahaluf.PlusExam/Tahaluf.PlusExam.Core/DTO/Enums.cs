using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public enum ExamLevels
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert
    }

    public enum StatusOptions
    {
        ENABLE,
        DISABLE
    }

    public enum AccountStatusOptions
    {
        OK,
        BLOCK
    }

    public enum QuestionTypes
    {
        Single,
        Multiple,
        Fill
    }
}
