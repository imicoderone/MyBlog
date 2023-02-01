using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.UseCases.Post.Commands;
using MyBlog.Application.UseCases.Post.Queries;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetPostsQuery());

            return Ok(result);
        }
    }
}
