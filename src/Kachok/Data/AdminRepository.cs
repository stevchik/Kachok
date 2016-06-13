using Kachok.Data.Interfaces;
using Kachok.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kachok.Data
{
    public class AdminRepository : IAdminRepository
    {

        private const string EQUIPMENT_KEY = "EquipmentKey";
        private const string MUSCLE_KEY = "MuscleKey";
        private const string TAG_KEY = "TagKey";

        private KachokContext _context;
        private ILogger<AdminRepository> _logger;
        private IMemoryCache _memoryCache;

        public AdminRepository(KachokContext context, IMemoryCache memoryCache, ILogger<AdminRepository> logger)
        {
            this._context = context;
            this._memoryCache = memoryCache;
            this._logger = logger;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            IEnumerable<Equipment> list = null;

            try
            {
                _logger.LogInformation("Get All Equipment Requested");

                if (!_memoryCache.TryGetValue(EQUIPMENT_KEY, out list))
                {
                    // fetch the value from the source
                    list = _context.Equipments.OrderBy(t => t.Name).ToList();

                    // store in the cache
                    _memoryCache.Set(EQUIPMENT_KEY, list,
                        new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1))
                        .SetAbsoluteExpiration(TimeSpan.FromHours(24)));

                    _logger.LogInformation($"{EQUIPMENT_KEY} updated from source.");
                }
                else
                {
                    _logger.LogInformation($"{EQUIPMENT_KEY} retrieved from cache.");
                }

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get equipment from database", ex);
                return null;
            }
        }

        public IEnumerable<MuscleGroup> GetAllMuscleGroups()
        {
            IEnumerable<MuscleGroup> list = null;
            try
            {
                _logger.LogInformation("Get All Muscle Groups Requested");
                if (!_memoryCache.TryGetValue(MUSCLE_KEY, out list))
                {
                    // fetch the value from the source
                    list = _context.MuscleGroups.OrderBy(t => t.Name).ToList();

                    // store in the cache
                    _memoryCache.Set(MUSCLE_KEY, list,
                        new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1))
                        .SetAbsoluteExpiration(TimeSpan.FromHours(24)));

                    _logger.LogInformation($"{MUSCLE_KEY} updated from source.");
                }
                else
                {
                    _logger.LogInformation($"{MUSCLE_KEY} retrieved from cache.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get muscle groups from database", ex);
                return null;
            }

            return list;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            IEnumerable<Tag> list = null;
            try
            {
                _logger.LogInformation("Get All Tags Requested");
                if (!_memoryCache.TryGetValue(TAG_KEY, out list))
                {
                    // fetch the value from the source
                    list = _context.Tags.OrderBy(t => t.Name).ToList();

                    // store in the cache
                    _memoryCache.Set(TAG_KEY, list,
                        new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1))
                        .SetAbsoluteExpiration(TimeSpan.FromHours(24)));

                    _logger.LogInformation($"{TAG_KEY} updated from source.");
                }
                else
                {
                    _logger.LogInformation($"{TAG_KEY} retrieved from cache.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get tags from database", ex);
                return null;
            }

            return list;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
