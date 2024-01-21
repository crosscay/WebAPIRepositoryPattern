using AutoMapper;
using WebAPIRepositoryPattern.DTOs;
using WebAPIRepositoryPattern.Models;

namespace WebAPIRepositoryPattern.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EmployeeAddDTO, Employee>();
        }
    }
}
