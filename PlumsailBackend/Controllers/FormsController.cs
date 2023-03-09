using Microsoft.AspNetCore.Mvc;
using plumsailbackend.Models;
using plumsailbackend.Repository;

namespace plumsailbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {
        [HttpGet]
        public List<Form> GetAllForms()
        {
            return FormTable.GetAllForms();
        }

        [HttpGet("{term}")]
        public List<Form> GetRequiredForms(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return new List<Form>();
            }

            var index = term.IndexOf("=");

            if (index < 0)
            {
                return new List<Form>();
            }

            var param = term[(index + 1)..];

            return FormTable.GetRequiredForms(param);
        }
    }
}
