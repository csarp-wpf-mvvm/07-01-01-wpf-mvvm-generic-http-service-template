using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;

namespace Kreta.Shared.Assemblers
{
    public class StudentAssembler : Assambler<Models.Student, Dtos.StudentDto>
    {
        public override Dtos.StudentDto ToDto(Models.Student domainEntity)
        {
            return domainEntity.ToStudentDto();
        }

        public override Models.Student ToModel(Dtos.StudentDto dto)
        {
            return dto.ToStudent();
        }
    }
}
