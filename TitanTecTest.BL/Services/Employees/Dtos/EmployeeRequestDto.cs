using TitanTecTest.BL.Helpers;

namespace TitanTecTest.BL.Services.Employees.Dtos
{
    public class EmployeeRequestDto: BasePageResultDto
    {
        public bool? Status { get; set; }
    }
}
