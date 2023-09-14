using FiapStoreMinimalApi.Entities;
using FiapStoreMinimalApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Usuarios/obter-todos-usuario", (IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ObterTodosUsuarios();
});
app.MapGet("/Usuarios/obter-por-usuario-id/{id}", (int id, IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ObterPorUsuarioId(id);
});
app.MapPost("/Usuarios", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.CadastrarUsuario(usuario);
});
app.MapPut("/Usuarios", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.AlterarUsuario(usuario);
});
app.MapDelete("/Usuarios/{id}", (int id, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.RemoverUsuario(id);
});

app.Run();

