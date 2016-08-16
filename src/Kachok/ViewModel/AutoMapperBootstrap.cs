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
                        d.TargetMuscleGroup = adminRepository.GetAllMuscleGroups().First(m => m.Id.Equals(s.Muscle));
                    }
                    catch (Exception)
                    {
                        throw new FieldMappingException("TargetMuslceGroup", $"{ s.Muscle} is not a recognized option.");
                    }
                    d.ExerciseTarget = s.Target;
                    d.DefaultExerciseUom = s.Uom;

                });
                config.CreateMap<Exercise, ExerciseViewModel>()
                .AfterMap((s, d) =>
                {
                    d.Muscle = s.TargetMuscleGroup.Id;
                    d.Target = s.ExerciseTarget;
                    d.Uom = s.DefaultExerciseUom;


                  //  { "id":0,"name":"Test","description":"Test De","status":1,"defaultExerciseUom":0,"muscle":0,"experience":1,"target":0,"exerciseEquipments":[{ "id":6,"equipmentName":"Bands"}],"exerciseImages":[],"createdBy":null,"createdDate":"0001-01-01T00:00:00","updatedBy":null,"updatedDate":"0001-01-01T00:00:00"}

});
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
