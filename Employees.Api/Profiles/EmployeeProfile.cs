namespace ECommerce.Api.Employees.Profiles
{
    public class EmployeeProfile :AutoMapper.Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Db.Employee, Models.Employee>();
        }
    }
}
