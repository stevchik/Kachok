using Kachok.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Data
{
    public class KachokContextSeedData
    {
        private KachokContext _context;
        private UserManager<KachokUser> _userManager;

        public KachokContextSeedData(KachokContext context, UserManager<KachokUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {

            if (await _userManager.FindByEmailAsync("stevchik@yahoo.com") == null)
            {
                // Add the user.
                var user = new KachokUser()
                {
                    UserName = "Stevchik",
                    Email = "stevchik@yahoo.com",
                    CreatedDate = DateTime.UtcNow
                };

                await _userManager.CreateAsync(user, "steve1");
            }

            if (!_context.Equipments.Any())
            {
                _context.Equipments.Add(new Equipment() { Name = "Barbell" });
                _context.Equipments.Add(new Equipment() { Name = "E-Z Curl Bar" });
                _context.Equipments.Add(new Equipment() { Name = "Dumbbell" });
                _context.Equipments.Add(new Equipment() { Name = "Cable" });
                _context.Equipments.Add(new Equipment() { Name = "Machine" });
                _context.Equipments.Add(new Equipment() { Name = "Bands" });
                _context.Equipments.Add(new Equipment() { Name = "Body Only" });
            }

            if (!_context.MuscleGroups.Any())
            {
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Abdominals" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Lats" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Lower Back" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Middle Back" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Biceps" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Neck" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Calves" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Quadriceps" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Chest" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Shoulders" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Forearms" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Traps" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Glutes" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Triceps" });
                _context.MuscleGroups.Add(new MuscleGroup() { Name = "Hamstrings" });

            }
            _context.SaveChanges();
        }
    }
}
