using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Abstractions;
using MyBlog.Application.UseCases.Post.Models;

namespace MyBlog.Application.UseCases.Post.Queries
{
    public class GetPostsQuery : IRequest<List<PostDto>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPostsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _context.Posts.Select(x => new PostDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToListAsync(cancellationToken);

            return posts;
        }
    }
}
