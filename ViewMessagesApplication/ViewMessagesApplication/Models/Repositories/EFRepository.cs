using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewMessagesApplication.Models.Repositories
{
    public class EFRepository : IRepository
    {
        private contactsdatabaseEntities _entities = new contactsdatabaseEntities();

        public IEnumerable<ConsoleMessage> GetMessages()
        {
            return _entities.ConsoleMessages.OrderByDescending(a => a.Tid).ToList();
        }
    }
}