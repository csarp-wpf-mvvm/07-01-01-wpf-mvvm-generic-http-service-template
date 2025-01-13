﻿using Kreta.Backend.Repos.Base;
using Kreta.Shared.Enums;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo : IBaseRepo<Student>
    {
        public Task<Student> GetByNameAsync(string firstName, string lastName);
        public Task<List<Student>> GetStudentByClass(int schoolYear, SchoolClassType schoolClassType);
    }
}
