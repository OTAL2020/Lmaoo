namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.DataAccessObjects.Base;
    using Otal.lmaoo.Data.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class TicketDao : DaoBase, ITicketDao
    {
        private new static IConfiguration _configuration;

        public TicketDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Ticket Create(Ticket ticket)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Ticket>("[dbo].[Ticket_Create]", new
                {
                    Summary = ticket.Summary,
                    ReporterId = ticket.ReporterId,
                    FeatureId = ticket.FeatureId,
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public Ticket GetById(int ticketId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Ticket>("[dbo].[Ticket_GetById]", new { TicketId = ticketId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<Ticket> GetByFeatureId(int featureId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Ticket>("[dbo].[Ticket_GetByFeatureId]", new { FeatureId = featureId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Ticket Update(Ticket ticket)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Ticket>("[dbo].[Ticket_Update]", new
                {
                    TicketId = ticket.TicketId,
                    Summary = ticket.Summary,
                    AssigneeId = ticket.AssigneeId,
                    Progress = ticket.Progress,
                    Deadline = ticket.Deadline,
                    FeatureId = ticket.FeatureId
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void Delete(int ticketId)
        {
            using (var con = NewSqlConnection)
            {
                con.Query<Ticket>("[dbo].[Ticket_Delete]", new { TicketId = ticketId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}