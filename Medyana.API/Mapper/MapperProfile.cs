using AutoMapper;
using Medyana.API.Model;
using Medyana.Core.Entity;

namespace Medyana.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Patient, PatientModel>().ReverseMap();
            CreateMap<Clinic, ClinicModel>().ReverseMap();
            CreateMap<Doctor, DoctorModel>().ReverseMap();
        }
    }
}