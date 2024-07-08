using LocalPost.Infraestructure;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPost.Application.Queries
{
    public class GetPostsHandler
    {
        private readonly LocalPostDbService _localPostService;

        public GetPostsHandler(LocalPostDbService localPostService)
        {
            _localPostService = localPostService;
        }

        public async Task<List<GetPostsResponse>> Handle()
        {
            var posts = await _localPostService.GetAllPost();
            return posts.Adapt<List<GetPostsResponse>>();
        }
    }

    public class GetPostsResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
