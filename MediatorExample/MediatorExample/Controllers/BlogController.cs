using MediatorExample.Commands;
using MediatorExample.Domain;
using MediatorExample.Dto;
using MediatorExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorExample.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IMediator mediator;
        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult> AddPost([FromBody] AddBlogPostDto dto)
        {
            AddBlogPostCommand cmd = new(dto);
            var result = await mediator.Send(cmd);
            if (result is null)
            {
                return BadRequest("Could not add Blog Post");
            }
            return CreatedAtAction(actionName: nameof(ById), routeValues: new { id = result.Id }, value: new BlogPostDto(result));
        }

        [HttpGet("")]
        public async Task<IEnumerable<BlogPostDto>> All()
        {
            return (await mediator.Send(new GetAllBlogPostsQuery()))
                .Select(x => new BlogPostDto(x));
        }

        [HttpGet("posts/{id}")]
        public async Task<ActionResult<BlogPostDto>> ById(int id)
        {
            var post = await mediator.Send(new GetBlogPostByIdQuery(id));
            if (post is null)
            {
                return NotFound();
            }
            return Ok(new BlogPostDto(post));
        }
    }
}
