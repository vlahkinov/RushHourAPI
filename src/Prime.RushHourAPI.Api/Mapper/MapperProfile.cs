using AutoMapper;
using Prime.RushHourAPI.Data.Entities;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using Prime.RushHourAPI.Domain.Dtos.Activity;
using Prime.RushHourAPI.Domain.Dtos.Appointment;
using Prime.RushHourAPI.Domain.Dtos.Client;
using Prime.RushHourAPI.Domain.Dtos.Employee;
using Prime.RushHourAPI.Domain.Dtos.Provider;

namespace Prime.RushHourAPI.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap(); 
            CreateMap<AccountDtoWithId, Account>().ReverseMap(); 
            CreateMap<AccountLoginDto, Account>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<ProviderDto, Provider>().ReverseMap();
            CreateMap<ProviderDtoWithId, Provider>().ReverseMap();
            CreateMap<ProviderDtoWithOthers, Provider>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<Employee, EmployeeDtoWithId>().ReverseMap();
            CreateMap<Employee, EmployeeDtoWithOthers>().ReverseMap();

            CreateMap<ClientDtoWithId, Client>().ReverseMap();

            CreateMap<Activity, ActivityDtoWithId>().ReverseMap();
            CreateMap<Activity, ActivityDtoWithEmployees>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDtoWithId>().ReverseMap();
            CreateMap<Appointment, AppointmentDtoWithOthers>().ReverseMap();
        }
    }
}
