using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(
		JwtBearerDefaults.AuthenticationScheme,
		options => {
			options.Authority = "https://localhost:7127";
			options.Audience = "resource_api1";

		}
	);

builder.Services
	.AddAuthorization(
		options => {
			options.AddPolicy(
				"readProduct",
				policy =>{
					policy.RequireClaim("scope", "api1.read");
				}
			);

			options.AddPolicy(
				"createOrUpdateProduct",
				policy =>
				{
					policy.RequireClaim("scope", "api1.create", "api1.update");
				}
			);
		}
	);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
