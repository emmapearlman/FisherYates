using FisherYates.Algorithm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FisherYatesWebApp
{
    [Route("api/[controller]")]
    public class FisherYates : Controller
    {
        private readonly IShufflerService _shuffler ;

        public FisherYates(IShufflerService shuffler)
        {
                _shuffler =shuffler;
        }

        /// <summary>
        /// todo: Add the skeleton structure for the solution, and implement unit tests (in the FisherYatesTests project)!
        /// </summary>
        /// <param name="input">List of dasherized elements to shuffle (e.g. "D-B-A-C").</param>
        /// <returns>A "200 OK" HTTP output with a content-type of `text/plain; charset=utf-8`. The content should be the dasherized output of the algorithm, e.g. "C-D-A-B".</returns>
        [Route("Index")]
        [HttpGet]
        public ActionResult Index([FromQuery] string input)
        {
            throw new NotImplementedException();
        }

    }
}