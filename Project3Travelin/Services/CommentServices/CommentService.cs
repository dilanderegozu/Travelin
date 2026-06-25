using AutoMapper;
using MongoDB.Driver;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Entities;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Comment> _commentCollection;

        public CommentService(IMapper mapper, IMongoCollection<Comment> commentCollection)
        {
            _mapper = mapper;
            _commentCollection = commentCollection;
        }
        public CommentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _commentCollection = database.GetCollection<Comment>(_databaseSettings.CommentCollectionName);
            _mapper = mapper;

        }

        public async Task CreateCommentAsync(CreateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            comment.IsStatus = false;
            comment.CommentDate = DateTime.Now;
            await _commentCollection.InsertOneAsync(comment);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _commentCollection.DeleteOneAsync(x => x.CommentId == id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
           var values = await _commentCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCommentDto>>(values);
        }

        public async Task<GetCommentByIdDto> GetCommentByIdAsync(string id)
        {
            var value = await _commentCollection.Find(x=>x.CommentId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCommentByIdDto>(value);
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var values = _mapper.Map<Comment>(updateCommentDto);
            await _commentCollection.FindOneAndReplaceAsync(x=>x.CommentId == updateCommentDto.CommentId, values);
        
    }
        public async Task<int> GetCommentCountByTourAsync(string id)
        {
            return (int)await _commentCollection
                .CountDocumentsAsync(x => x.TourId == id && x.IsStatus);
        }

        public async Task<double> GetAverageScoreByTourAsync(string id)
        {
            var comments = await _commentCollection
                .Find(x => x.TourId == id && x.IsStatus)
                .ToListAsync();

            if (!comments.Any())
                return 0;

            return comments.Average(x => x.Score);
        }
        public async Task<List<ResultCommentDto>> GetCommentsByTourAsync(string tourId)
        {
            var values = await _commentCollection
                .Find(x => x.TourId == tourId && x.IsStatus)
                .SortByDescending(x => x.CommentDate)
                .ToListAsync();

            return _mapper.Map<List<ResultCommentDto>>(values);
        }
        public async Task ApproveCommentAsync(string id)
        {
            var update = Builders<Comment>.Update.Set(x => x.IsStatus, true);
            await _commentCollection.UpdateOneAsync(x => x.CommentId == id, update);
        }
    }
}
