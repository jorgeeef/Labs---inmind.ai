using AutoMapper;
using CodeFirst_Approach.Models;
using CodeFirst_Approach.ViewModels;

namespace CodeFirst_Approach.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // Mapping between the Student model and StudentViewModel
        CreateMap<Student, StudentViewModel>();

        // Mapping between the Course model and CourseViewModel
        CreateMap<Course, CourseViewModel>();
    }
}