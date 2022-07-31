namespace EmployeeManagment.Api.Employees.Profiles
{
    public class EmployeeProfile : AutoMapper.Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Db.Employee, Models.Employee>();
            CreateMap<Models.Employee, Db.Employee>();

            //     CreateMap<Models.Employee, Db.Employee>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            // ignore both null & empty string properties
            //            if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            // ignore null role
            //            if (x.DestinationMember.Name == "Role" && src.Age == null) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
