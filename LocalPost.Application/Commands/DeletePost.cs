using LocalPost.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPost.Application.Commands
{
    public class DeletePostCommand
    {
        public Guid Id { get; set; }
    }
    public class DeletePostHandler
    {
        private readonly LocalPostDbService _dbService;

        public DeletePostHandler(LocalPostDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<DeletePostRespose> Handle(DeletePostCommand cmd)
        {
            var post = await _dbService.GetPost(cmd.Id);

            if (post != null)
            {
                await _dbService.DeletePost(cmd.Id);
                return new DeletePostRespose(cmd.Id, post.Nombre, post.Descripcion);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
    public class DeletePostRespose
    {
        public DeletePostRespose(Guid id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
