using ChiknTinder.Configuration;
using ChiknTinder.Persistence.NHibernate.Listeners;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using NHibernate.Event;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json");

var tokenSecret = builder.Configuration.GetSection("AppSettings:Secret").Value;

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenSecret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddSingleton(x => Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012
        .ShowSql()
        .FormatSql()
        .ConnectionString(p => p.Is(connectionString)
        )
        .AdoNetBatchSize(20)
        .DefaultSchema("dbo"))
    .ExposeConfiguration(c =>
    {
        c.SetListener(ListenerType.PreInsert, new AuditEventListener());
        c.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "300");
    }
    )
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuditEventListener>())
    .BuildSessionFactory());

builder.Services.AddScoped(x =>
{
    var sessionFactory = x.GetService<ISessionFactory>();
    if (sessionFactory == null)
    {
        throw new Exception("Could not initialize a session factory before warming up the ORM");
    }
    return sessionFactory.OpenSession();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

ServiceCollectionRegistry.RegisterScopedServices(builder.Services);
ServiceCollectionRegistry.RegisterScopedRepositories(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapFallbackToFile("index.html");

app.Run();