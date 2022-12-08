using DLWMS.Repository;
using DLWMS.Servicee;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DLWMSDbContext>(
        dbContextOpcije => dbContextOpcije
        .UseSqlServer(builder.Configuration.GetConnectionString("DLWMSdev"))
    );

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IPredmetService, PredmetService>();

//builder.Services.AddScoped<IMessageService, ViberService>();
//builder.Services.AddScoped<IMessageService, DummyViberService>();

//ADD TRANSIENT VS ADD SCOPED VS ADD SINGLELETON
//SINGLETON -> dizajn patern koji garantuje da cemo u app imati samo jedan objekat te klase np. windows forms login; const ce se pozvti samo jednom
        // ako kazemo da je nsto addsingleton ot znaci da ce se ovaj objekat kreirati prvi put i postojace dok god app radi
        // klase singleton ce u app imati samo 1 objekat
        // singleton bi mogao biti 
//SCOPED -> kada posaljem request na app taj obj ce zivjeti dok se ne avrsi request
        // najcesce su SCOPED nasi servisi
        // PROSLIJEDI SE ISI OBJEKAT
//TRANSIENT -> // PROSLIJEDI SE NOVI OBJEKAT

//UNIT OF WORK
    // ideja je da unutrar sebe objedini sve intefejse odnosno repositoryje i dbcontext
    // u servisnu klasu injectamo unit of work objekat
    // umjesto da injectamo 5 interfacea injectamo samo unit of work


builder.Host.ConfigureLogging(log =>
{
    log.ClearProviders();
    log.AddConsole();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
