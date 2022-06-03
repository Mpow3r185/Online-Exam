﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IReportRepository
    {
        // Get Number of Users
        List<AllUsersDTO> NumberOfUsers();

        // Get Total exam's cost for all Courses
        List<TotalCostDTO> TotalCost();

        // Get Total exam's cost by CourseName
        TotalCostDTO TotalCostByCourseName(string name);

        // Get Number of users by CourseName
        AllUsersDTO NumberOfUsersByCourseName(string name);

        // Get Number of users by ExamName
        AllUsersDTO NumberOfUsersByExmaName(string name);

        // Get Number Of Certificates
        AllUsersDTO NumberOfCertificates();

    }
}
