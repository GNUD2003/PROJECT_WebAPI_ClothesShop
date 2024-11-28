using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_Bussiness.Handle.HandleEmail;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.Mappers;
using Project_Bussiness.Services;
using Project_Data.Data;
using Project_Data.Repository;
using Project_Model.Entities;
using Project_Model.IRepository;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpContextAccessor();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Auth Api", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Vui long nhap Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    /*    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference= new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });*/
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
{
    {
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Reference = new Microsoft.OpenApi.Models.OpenApiReference
            {
                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});
});

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<UserConverter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBaseRepositoty<User>, BaseRepository<User>>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IBaseRepositoty<ConfirmEmail>, BaseRepository<ConfirmEmail>>();
builder.Services.AddScoped<IDBContext, AppDBContext>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IBaseRepositoty<Permission>, BaseRepository<Permission>>();
builder.Services.AddScoped<IBaseRepositoty<Role>, BaseRepository<Role>>();
builder.Services.AddScoped<IBaseRepositoty<RefreshToken>, BaseRepository<RefreshToken>>();

//User
builder.Services.AddScoped<IBaseRepositoty<User>, BaseRepository<User>>();
builder.Services.AddScoped<IUserServices, UserServices>();

//Category
builder.Services.AddScoped<IBaseRepositoty<Category>, BaseRepository<Category>>();
builder.Services.AddScoped<ICategorieServices, CategoryServices>();

//Material

builder.Services.AddScoped<IBaseRepositoty<Materials>, BaseRepository<Materials>>();
builder.Services.AddScoped<IMaterialServices, MaterialServices>();

//Product
builder.Services.AddScoped<IBaseRepositoty<Product>, BaseRepository<Product>>();
builder.Services.AddScoped<IProductServices, ProductServices>();
// Order
builder.Services.AddScoped<IBaseRepositoty<Order>, BaseRepository<Order>>();
builder.Services.AddScoped<IOrderServices, OrderServices>();

//OrderDetail

builder.Services.AddScoped<IBaseRepositoty<OrderDetail>, BaseRepository<OrderDetail>>();
builder.Services.AddScoped<IOrderDetailServices, OrderDetailServices>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);

var emailConfig = builder.Configuration.GetSection("EmaiConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

#region Config. CORS

app.UseCors(options =>
options.WithOrigins("http://http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader()
);
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
