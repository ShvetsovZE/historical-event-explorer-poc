using HistoricalEventExporter.Abstraction;

namespace HistoricalEventExporter.TeamMemberInvitedEvent
{
    public class TeamMemberInvitedEventDataReader : IEventDataReader<TeamMemberInvitedEvent>
    {
        public async Task<IEnumerable<TeamMemberInvitedEvent>> GetDataAsync()
        {
            //TODO: Replace With real data source
            var teamMemberInvitedEvents = new List<TeamMemberInvitedEvent>();

            for (int i = 0; i < 350; i++)
            {
                teamMemberInvitedEvents.Add(new TeamMemberInvitedEvent { OrganisationId = i });
            }

            await Task.Delay(1000);

            return teamMemberInvitedEvents;
        }
    }
}
