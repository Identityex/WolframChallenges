using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WolframChallenges;
using WolframChallenges.Shared;
using WolframEntities.Models;
using WolframWeb.Areas.Wolfram.Models;

namespace WolframWeb.Areas.Wolfram.Controllers
{
    //Would Normally use an authorize attribute here
    [Area("Wolfram")]
    public class WolframController : Controller
    {

        private readonly WolframDBContext _wolframDB;
        private readonly DeriffleList _deriffleList;
        private readonly IUtilities _utilities;
        
        //Store where these pages will be stored
        private const string sharedPageArea = "~/Areas/Wolfram/Views/Shared/";
        private const string pageArea = "~/Areas/Wolfram/Views/";

        public WolframController(WolframDBContext wolframDB, 
            DeriffleList deriffleList, 
            IUtilities utilities)
        {
            _wolframDB = wolframDB;
            _deriffleList = deriffleList;
            _utilities = utilities;
        }

        public IActionResult Index()
        {
            List<Challenges> challenges = _wolframDB.Challenges
                .Include(c => c.ChallengeStatus)
                .Include(c => c.ChallengeType)
                .Where(c => c.ChallengeStatus.Status == "Completed")
                .ToList();

            return View(pageArea + "Wolfram/ChallengeList.cshtml", challenges);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Riffle()
        {
            return PartialView(sharedPageArea + "Riffle.cshtml");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public string RiffleArrays([FromBody] RiffleModel model)
        {
            //I know this isn't practical, but using what I have currently
            List<List<object>> objList = new List<List<object>>();

            objList.Add(model.array1.ToList());
            objList.Add(model.array2.ToList());
            
            return _utilities.GetListString(_deriffleList.Riffle(objList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string DeRiffleArray([FromBody] RiffleModel model)
        {
            return _utilities.GetListString(_deriffleList.DeRiffle(model.array1.ToList(), 2));
        }
    }
}