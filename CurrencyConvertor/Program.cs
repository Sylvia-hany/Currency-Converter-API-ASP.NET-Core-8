
using CurrencyConvertor.Mapping;
using CurrencyConvertor.Models;
using CurrencyConvertor.Repository;
using CurrencyConvertor.Services;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvertor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ICurrencyService, CurrencyService>();
            builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();   
            builder.Services.AddScoped<IConversionHistoryService, ConversionHistoryService>();

            /// 
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Add services to the container.
            // Register generic Repository
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Register specific Repository
            builder.Services.AddScoped<IConversionRepository, ConversionRepository>();

            //1️-Configure DbContext with SQLite
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
