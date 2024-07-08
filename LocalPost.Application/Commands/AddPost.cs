using LocalPost.Infraestructure;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPost.Application.Commands
{
    public class AddPostCommand
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class AddPostHandler
    {
        private readonly LocalPostDbService _localPostDbService;

        public AddPostHandler(LocalPostDbService localPostDbService)
        {
            _localPostDbService = localPostDbService;
        }

        public async Task<AddPostResponse> Handle(AddPostCommand cmd)
        {
            var postId = await _localPostDbService.AddPost(cmd.Nombre, cmd.Descripcion);
            return new AddPostResponse { Id = postId, Nombre = cmd.Nombre, Descripcion = cmd.Descripcion };
        }

        public class AddPostResponse
        {
            public Guid Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
