using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewMessagesApplication.Models;
using ViewMessagesApplication.Models.Repositories;


namespace ViewMessagesApplication.Controllers
{
    public class ConsoleMessagesController : Controller
    {
        IRepository _repository = new EFRepository();

        public ConsoleMessagesController()
            :this(new EFRepository())
        { 
        }

        public ConsoleMessagesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: ConsoleMessages
        public ActionResult Index()
        {          
            return View(_repository.GetMessages());
        }
    }
}
