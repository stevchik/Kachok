using System;
using AutoMapper;
using Kachok.Model;
using Kachok.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Kachok.Infrastructure;
using Kachok.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Kachok.ViewModel
{
    public class AutoMapperBootstrap
    {
        internal static void Initialize(IServiceProvider serviceProvider)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ExerciseViewModel, Exercise>()
                .AfterMap((s, d) =>
                {
                    IAdminRepository adminRepository = serviceProvider.GetRequiredService<IAdminRepository>();
                    try
                    {
                        d.TargetMuscleGroup = adminRepository.GetAllMuscleGroups().First(m => m.Name.Equals(s.TargetMuscleGroupName));
                    }
                    catch (Exception)
                    {
                        throw new FieldMappingException("TargetMuslceGroup", $"{ s.TargetMuscleGroupName} is not a recognized option.");
                    }

                });
                config.CreateMap<Exercise, ExerciseViewModel>();
                config.CreateMap<ExerciseEquipmentViewModel, ExerciseEquipment>()
                .AfterMap((s, d) =>
                {
                    IAdminRepository adminRepository = serviceProvider.GetRequiredService<IAdminRepository>();
                    try
                    {
                        d.Equipment = adminRepository.GetAllEquipment().First(m => m.Name.Equals(s.EquipmentName));
                        d.EquipmentId = d.Equipment.Id;
                    }
                    catch(Exception)
                    {
                        throw new FieldMappingException("Equipment ", $"{ s.EquipmentName} is not a recognized option.");
                    }
                });
                config.CreateMap<ExerciseEquipment, ExerciseEquipmentViewModel>();
                config.CreateMap<ExerciseTagViewModel, ExerciseTag>()
               .AfterMap((s, d) =>
               {
                   IAdminRepository adminRepository = serviceProvider.GetRequiredService<IAdminRepository>();
                   try
                   {
                       d.Tag = adminRepository.GetAllTags().First(m => m.Name.Equals(s.TagName));
                       d.TagId = d.Tag.Id;
                   }
                   catch (Exception)
                   {
                       throw new FieldMappingException("Tag ", $"{ s.TagName} is not a recognized option.");
                   }
               });
                config.CreateMap<ExerciseTag, ExerciseTagViewModel>();
                config.CreateMap<ExerciseImageViewModel, ExerciseImage>().ReverseMap();
            });
        }
    }
}
