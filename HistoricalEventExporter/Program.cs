

using HistoricalEventExporter.Abstraction;
using HistoricalEventExporter.Exporters;

namespace HistoricalEventExporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfigureServices(builder.Services);

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

        private static void ConfigureServices(IServiceCollection services)
        {
            //TeamMemberInvitedEvent exporter registration          
            RegisterExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>(services);

            //BookingMadeEvent exporter registration
            RegisterExporter<BookingMadeEvent.BookingMadeEvent>(services);
        }

        private static void RegisterExporter<T>(IServiceCollection services)
        {
            services.AddSingleton<IEventExporter<T>, EventExporter<T>>();
            services.AddHostedService<EventExporter<T>>(provider => provider.GetService<IEventExporter<T>>() as EventExporter<T>);
        }
    }
}
