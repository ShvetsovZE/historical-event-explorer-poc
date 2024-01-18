

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
            builder.Services.AddSingleton<IEventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>, EventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>>();
            builder.Services.AddHostedService<EventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>>(provider => provider.GetService<IEventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>>() as EventExporter<TeamMemberInvitedEvent.TeamMemberInvitedEvent>);

            //BookingMadeEvent exporter registration
            builder.Services.AddSingleton<IEventExporter<BookingMadeEvent.BookingMadeEvent>, EventExporter<BookingMadeEvent.BookingMadeEvent>>();
            builder.Services.AddHostedService<EventExporter<BookingMadeEvent.BookingMadeEvent>>(provider => provider.GetService<IEventExporter<BookingMadeEvent.BookingMadeEvent>>() as EventExporter<BookingMadeEvent.BookingMadeEvent>);


        }
    }
}
