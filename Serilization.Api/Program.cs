
using Microsoft.EntityFrameworkCore;
using Serilization.Api.Data;
using System.Text.Json.Serialization;

namespace Serilization.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Register Services

            #region Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    );
            });
            #endregion

            #region Handel Serialize loop references (but this in ASP.Net.Web.Api/Invalid in Asp.NetCore.OpenApi)
            //HttpConfiguration httpConfiguration = new();

            /*Use ReferenceLoopHandling Instead of using [JsonIgnore]*/

            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //ReferenceHandler referenceHandler = new ReferenceHandler();
            #endregion

            #region Handel Serialize loop references (but this in ASP.NetCore.OpenApi)
            builder.Services
               .AddControllers()
               .AddJsonOptions(options =>
               {
                   /*Use JsonSerializerOptions Instead of using [JsonIgnore]*/
                   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               });
            #endregion

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


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
}