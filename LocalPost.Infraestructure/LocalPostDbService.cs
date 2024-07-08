using Dapper;
using LocalPost.Domain;
using System.Data;

namespace LocalPost.Infraestructure
{
    public class LocalPostDbService
    {
        private readonly LocalPostDbContext _dbContext;

        public LocalPostDbService(LocalPostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Posts>> GetAllPost()
        {
            //var query = "SELECT id as \"Id\", nombre as \"Nombre\", descripcion as \"Descripcion\" FROM \"Posts\";";
            var query = "SELECT id, nombre, descripcion FROM posts;";
            using var connection = _dbContext.Connect();
            return (await connection.QueryAsync<Posts>(query, "", commandType: CommandType.Text)).ToList();
        }

        public async Task<Guid> AddPost(string nombre, string desc)
        {
            var postId = Guid.NewGuid();
            var sql = "INSERT INTO public.posts(id, nombre, descripcion) " +
                      $"VALUES('{postId}', '{nombre}', '{desc}')";
            using var connection = _dbContext.Connect();
            await connection.ExecuteAsync(sql, "", commandType: CommandType.Text);
            return postId;
        }

        public async Task DeletePost(Guid Id)
        {            
            var sql = $"DELETE FROM posts WHERE id = '{Id}'";
            using var connection = _dbContext.Connect();
            await connection.ExecuteAsync(sql, "", commandType: CommandType.Text);
        }

        public async Task<Posts> GetPost(Guid Id)
        {
            //var query = "SELECT id as \"Id\", nombre as \"Nombre\", descripcion as \"Descripcion\" FROM \"Posts\";";
            var query = $"SELECT id, nombre, descripcion FROM posts WHERE id = '{Id}';";
            using var connection = _dbContext.Connect();
            return (await connection.QueryAsync<Posts>(query, "", commandType: CommandType.Text)).FirstOrDefault();
        }

        public async Task<List<Posts>> GetPostByFilter(string name)
        {
            //var query = "SELECT id as \"Id\", nombre as \"Nombre\", descripcion as \"Descripcion\" FROM \"Posts\";";
            var query = $"SELECT id, nombre, descripcion FROM posts WHERE nombre LIKE '%{name}%';";
            using var connection = _dbContext.Connect();
            return (await connection.QueryAsync<Posts>(query, "", commandType: CommandType.Text)).ToList();
        }
    }
}
