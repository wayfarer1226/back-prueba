using LocalPost.Infraestructure;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPost.Application.Queries
{
    public class GetPostsFilterQuery
    {
        public string Name { get; set; }
    }

    public class GetPostsFilterHandler
    {
        private readonly LocalPostDbService _localPostService;

        public GetPostsFilterHandler(LocalPostDbService localPostService)
        {
            _localPostService = localPostService;
        }

       public async Task<List<GetPostsFilterResponse>> Handle(GetPostsFilterQuery qry)
        {
            var posts = await _localPostService.GetPostByFilter(qry.Name);
            return posts.Adapt<List<GetPostsFilterResponse>>();
        }
    }

    public class GetPostsFilterResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
