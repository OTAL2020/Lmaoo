namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.DataAccessObjects.Base;
    using Otal.lmaoo.Data.Interfaces;
    using System;
    using System.Collections.Generic;

    public class TicketDao : DaoBase, ITicketDao
    {
        private new static IConfiguration _configuration;

        public TicketDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Ticket Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetByFeatureId(int featureId)
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}