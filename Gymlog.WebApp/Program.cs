using Gymlog.Dados.EntityFramework;
using Gymlog.Dados.Repository;
using Gymlog.Dominio.Interface;
using Gymlog.Dominio.IService;
using Gymlog.Servico.Servico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>();

builder.Services.AddScoped<IPessoaCadastroRepository, PessoaCadastroRepository>();
builder.Services.AddScoped<IPessoaCadastroService, PessoaCadastroService>();

builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IExercicioService, ExercicioService>();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
