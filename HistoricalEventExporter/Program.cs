

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

            ConfigureServices(builder);

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

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            //TeamMemberInvitedEvent exporter registration
            builder.Services.AddSingleton<IEventExporter<TeamMemberInvitedEvent>, EventExporter<TeamMemberInvitedEvent>>();
            builder.Services.AddHostedService<EventExporter<TeamMemberInvitedEvent>>(provider => provider.GetService<IEventExporter<TeamMemberInvitedEvent>>() as EventExporter<TeamMemberInvitedEvent>);

            //BookingMadeEvent exporter registration
            builder.Services.AddSingleton<IEventExporter<BookingMadeEvent>, EventExporter<BookingMadeEvent>>();
            builder.Services.AddHostedService<EventExporter<BookingMadeEvent>>(provider => provider.GetService<IEventExporter<BookingMadeEvent>>() as EventExporter<BookingMadeEvent>);


        }
    }
}
