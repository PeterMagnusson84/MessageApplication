using System;
using System.Collections.Generic;

namespace ViewMessagesApplication.Models.Repositories
{
    public interface IRepository
    {
        IEnumerable<ConsoleMessage> GetMessages();
    }
}
