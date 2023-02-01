using MediatR;
using MyBlog.Application.Abstractions;
using MyBlog.Application.Notifications;

namespace MyBlog.Application.UseCases.Post.Commands
{
    public class CreatePostCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreatePostCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Post()
            {
                Title = request.Title,
                Content = request.Content
            };

            var entry = await _context.Posts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PostCreatedNotification()
            {
                Id = entry.Entity.Id
            }, cancellationToken);
        }
    }
}
