var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/usuarios", () =>
{
    List<string> nomes = new List<string>
    {
        "João",
        "Maria",
        "Luizinho",
    };

    return nomes;
});

app.MapPost("/usuarios", (string nome) =>
{
    return Results.Ok($"Usuário {nome} criado com sucesso!");
});

app.MapPut("/usuarios/{id}", (int id, string novoNome) =>
{
    return Results.Ok($"Usuário {id} atualizado para {novoNome}");
});

app.MapPatch("/usuarios/{id}", (int id, string campo, string valor) =>
{
    return Results.Ok($"Usuário {id} teve o campo {campo} atualizado para {valor}");
});

app.MapDelete("/usuarios/{id}", (int id) =>
{
    return Results.Ok($"Usuário {id} removido com sucesso!");
});

app.Run();