using LocalPost.Infraestructure;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPost.Application.Queries
{
    public class GetPostQuery
    {
        public Guid Id { get; set; }
    }

    public class GetPostHandler
    {
        private readonly LocalPostDbService _dbService;

        public GetPostHandler(LocalPostDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<GetPostResponse> Handle(GetPostQuery qry)
        {
            var post = await _dbService.GetPost(qry.Id);
            return post.Adapt<GetPostResponse>();
        }
    }

    public class GetPostResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
