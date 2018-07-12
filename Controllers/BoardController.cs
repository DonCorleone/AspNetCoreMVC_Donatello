using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            var model = new BoardView();
            model.Columns.Add(new BoardView.Column(){Title = "ToDO"});
          
            return View(model);            
        }
    }
}