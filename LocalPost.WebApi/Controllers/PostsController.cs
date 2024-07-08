using LocalPost.Application.Commands;
using LocalPost.Application.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LocalPost.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AddPostHandler _addPostHandler;
        private readonly GetPostsHandler _getPostsHandler;
        private readonly GetPostHandler _getPostHandler;
        private readonly DeletePostHandler _deletePostHandler;
        private readonly GetPostsFilterHandler _getPostsFilterHandler;

        public PostsController(AddPostHandler addPostHandler, GetPostsHandler getPostsHandler, DeletePostHandler deletePostHandler, GetPostHandler getPostHandler, GetPostsFilterHandler getPostsFilterHandler)
        {
            _addPostHandler = addPostHandler;
            _getPostsHandler = getPostsHandler;
            _deletePostHandler = deletePostHandler;
            _getPostHandler = getPostHandler;
            _getPostsFilterHandler = getPostsFilterHandler;
        }

        [HttpPost()]
        public async Task<IActionResult> AddPost([FromBody] Models.Requests.AddPost req)
        {
            var post = await _addPostHandler.Handle(req.Adapt<AddPostCommand>());
            return Ok(post.Adapt<Models.Responses.Posts>());
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _getPostsHandler.Handle();
            return Ok(posts.Adapt<List<Models.Responses.Posts>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] Guid id)
        {
            var posts = await _getPostHandler.Handle(new GetPostQuery { Id = id });
            return Ok(posts.Adapt<Models.Responses.Posts>());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetPostFilter([FromQuery] string name)
        {
            var posts = await _getPostsFilterHandler.Handle(new GetPostsFilterQuery { Name = name });
            var resp = posts.Adapt<List<Models.Responses.Posts>>();
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {
            var postsDeleted = await _deletePostHandler.Handle(new DeletePostCommand { Id = id });
            return Ok(postsDeleted.Adapt<Models.Responses.Posts>());
        }
    }
}
