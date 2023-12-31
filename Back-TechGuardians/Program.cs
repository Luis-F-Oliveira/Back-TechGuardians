using Back_TechGuardians.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Back_TechGuardians.Data;
using Back_TechGuardians.Repositorios.Interfaces;
using Back_TechGuardians.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Back_TechGuardians
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SystemDBContext>
                (options => options.UseMySql(
                    "server=blucaju.com.br;initial catalog=blucaj55_dbtechguardians2;uid=blucaj55_admin;pwd=eugostodemacarrao",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.23-23")));

            builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();
            builder.Services.AddScoped<IEquipamentRepositorio, EquipamentRepositorio>();
            builder.Services.AddScoped<IMonitoringRepositorio, MonitoringRepositorio>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region [cors]
            builder.Services.AddCors();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region [Cors]
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
