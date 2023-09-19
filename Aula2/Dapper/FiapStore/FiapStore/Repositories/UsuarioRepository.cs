using Dapper;
using FiapStore.Entities;
using FiapStore.Interfaces;
using System.Data.SqlClient;

namespace FiapStore.Repositories
{
    public class UsuarioRepository : DapperRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Alterar(Usuario entidade)
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "UPDATE Usuario SET Nome = @Nome WHERE Id = @Id";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Usuario entidade)
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "INSERT INTO Usuario (Nome) VALUES (@Nome)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "DELETE FROM Usuario WHERE Id = @Id";
            dbConnection.Query(query, new { Id = id });
        }

        public override Usuario? ObterPorId(int id)
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "SELECT * FROM Usuario WHERE Id = @Id";
            return dbConnection.QueryFirstOrDefault<Usuario>(query, new { Id = id });
        }

        public override IList<Usuario> ObterTodos()
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "SELECT * FROM Usuario";
            return dbConnection.Query<Usuario>(query).AsList();
        }
        public Usuario? ObterComPedidos(int id)
        {
            using SqlConnection dbConnection = new SqlConnection(ConnectionString);
            const string query = "SELECT * FROM Usuario WHERE Id = @Id; SELECT * FROM Pedido WHERE UsuarioId = @Id";
            using var multi = dbConnection.QueryMultiple(query, new { Id = id });
            var usuario = multi.ReadFirstOrDefault<Usuario>();
            if (usuario != null)
            {
                usuario.Pedidos = multi.Read<Pedido>().AsList();
            }
            return usuario;
        }
    }
}
