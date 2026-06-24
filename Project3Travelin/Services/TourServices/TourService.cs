using AutoMapper;
using MongoDB.Driver;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Entities;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.TourServices
{
    public class TourService : ITourService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Tour> _tourCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public TourService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _tourCollection = database.GetCollection<Tour>(_databaseSettings.TourCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task CreateTourAsync(CreateTourDto createTourDto)
        {
            var values=_mapper.Map<Tour>(createTourDto);
            await _tourCollection.InsertOneAsync(values);
        }

        public async Task DeleteTourAsync(string id)
        {
            await _tourCollection.DeleteOneAsync(x => x.TourId == id);
        }

        public async Task<List<ResultTourDto>> GetAllTourAsync()
        {
            var tours = await _tourCollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            foreach (var tour in tours)
            {
                tour.CategoryName = categories
                    .FirstOrDefault(c => c.CategoryId == tour.CategoryId)
                    ?.CategoryName;
            }

            return _mapper.Map<List<ResultTourDto>>(tours);
        }

        public async Task<GetTourByIdDto> GetTourByIdAsync(string id)
        {
            var value = await _tourCollection.Find(x => x.TourId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTourByIdDto>(value);
        }

        public async Task UpdateTourAsync(UpdateTourDto updateTourDto)
        {
            var values = _mapper.Map<Tour>(updateTourDto);
            await _tourCollection.FindOneAndReplaceAsync(x=>x.TourId == updateTourDto.TourId, values);
        }
        public async Task<List<ResultTourDto>> GetPagedToursAsync(int page, int pageSize)
        {
            var values = await _tourCollection
                .Find(x => true)
                .Skip((page - 1) * pageSize)   
                .Limit(pageSize)               
                .ToListAsync();

            return _mapper.Map<List<ResultTourDto>>(values);
        }

        public async Task<long> GetTourCountAsync()
        {
            return await _tourCollection.CountDocumentsAsync(x => true);
        }
        public async Task<List<ResultTourDto>> GetFilteredToursAsync(string? city, string? categoryId, string? dayNight)
        {
            var filter = Builders<Tour>.Filter.Empty;

            if (!string.IsNullOrEmpty(city))
                filter &= Builders<Tour>.Filter.Eq(x => x.City, city);

            if (!string.IsNullOrEmpty(categoryId))
                filter &= Builders<Tour>.Filter.Eq(x => x.CategoryId, categoryId);

            if (!string.IsNullOrEmpty(dayNight))
                filter &= Builders<Tour>.Filter.Eq(x => x.DayNight, dayNight);

            var values = await _tourCollection.Find(filter).ToListAsync();
            return _mapper.Map<List<ResultTourDto>>(values);
        }
    }
    }