using System.Text;
using ArtStore.Application;
using ArtStore.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		policy =>
		{
			policy.AllowAnyOrigin()
				  .AllowAnyMethod()
				  .AllowAnyHeader();
		});
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
	};
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	// Documentation title and version
	option.SwaggerDoc("v1", new OpenApiInfo { Title = "ArtStore API", Version = "v1" });

	// Definition of the security scheme 
	option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Enter your JWT token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "bearer"
	});

	// Requirement of the security scheme
	option.AddSecurityRequirement((document) => new OpenApiSecurityRequirement()
	{
		[new OpenApiSecuritySchemeReference("Bearer", document)] = []
	});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var logger = services.GetRequiredService<ILogger<Program>>();
	try
	{
		logger.LogInformation("--- SEEDING THE DATABASE IS STARTED ---"); 

		var context = services.GetRequiredService<ArtStoreDbContext>();

		context.Database.EnsureCreated();

		await ArtStoreDbContextSeed.SeedAsync(context);

		logger.LogInformation("--- SEEDING COMPLETED ---");
	}
	catch (Exception ex)
	{
		logger.LogError(ex, "--- ERROR ---");
	}
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();