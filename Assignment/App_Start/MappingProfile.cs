using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Assignment.DTO;
using Assignment.DB;

namespace Assignment.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentDTO>();
            Mapper.CreateMap<StudentDTO, Student>();
            Mapper.CreateMap<ClassDTO, Class>();
            Mapper.CreateMap<Class, ClassDTO>();
        }
    }
}