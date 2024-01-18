using PerguntasOpcoes.Repositories;
using PerguntasOpcoes.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Registro dos repositórios e serviços
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddScoped<CategoriaService>();
        builder.Services.AddScoped<IPerguntaRepository, PerguntaRepository>();
        builder.Services.AddScoped<PerguntaService>();
        builder.Services.AddScoped<IOpcaoRepository, OpcaoRepository>();
        builder.Services.AddScoped<OpcaoService>();
        builder.Services.AddScoped<IPerguntaOpcaoRepository, PerguntaOpcaoRepository>();
        builder.Services.AddScoped<PerguntaOpcaoService>();
        builder.Services.AddScoped<IRelacaoPerguntaRepository, RelacaoPerguntaRepository>();
        builder.Services.AddScoped<RelacaoPerguntaService>();
        builder.Services.AddScoped<IRelacaoOpcaoPerguntaRepository, RelacaoOpcaoPerguntaRepository>();
        builder.Services.AddScoped<RelacaoOpcaoPerguntaService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
