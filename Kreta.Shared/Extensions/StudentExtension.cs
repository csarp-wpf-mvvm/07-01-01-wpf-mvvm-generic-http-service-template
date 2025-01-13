using Kreta.Shared.Dtos;
using Kreta.Shared.Models;

namespace Kreta.Shared.Extensions
{
    public static class StudentExtension
    {
        public static Dtos.StudentDto ToStudentDto(this Models.Student student)
        {
            return new Dtos.StudentDto
            {
                Id= student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthsDay = student.BirthsDay,
                SchoolYear = student.SchoolYear,
                SchoolClass = student.SchoolClass,
                EducationLevel = student.EducationLevel
            };
        }

        public static Models.Student ToStudent(this Dtos.StudentDto studentdto) 
        {
            return new Models.Student
            {
                Id = studentdto.Id,
                FirstName = studentdto.FirstName,
                LastName = studentdto.LastName,
                BirthsDay = studentdto.BirthsDay,
                SchoolYear = studentdto.SchoolYear,
                SchoolClass = studentdto.SchoolClass,
                EducationLevel = studentdto.EducationLevel
            };
        }
    }

}
