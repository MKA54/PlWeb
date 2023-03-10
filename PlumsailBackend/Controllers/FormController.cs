using Microsoft.AspNetCore.Mvc;
using plumsailbackend.JSONParser;
using plumsailbackend.Models;
using System.Collections;
using plumsailbackend.Repository;

namespace PlumsailBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : Controller
    {
        [HttpPost]
        public void AddForm([FromBody] object model)
        {
            var input = model.ToString();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var form = GetForm(input);

            if (form != null)
            {
                FormTable.AddForm(form);
            }
        }

        [HttpOptions]
        public dynamic AddForm()
        {
            return Ok();
        }

        private static Form? GetForm(string input)
        {
            try
            {
                var formJSON = JsonEntity.Parse(input);

                     var firstName = formJSON["first_name"].GetValue<string>();
                     var lastName = formJSON["last_name"].GetValue<string>();
                     var carModel = formJSON["car_model"].GetValue<string>();
                     var engineType = formJSON["engine_type"].GetValue<string>();
                     var checkedOptionsCount = formJSON["checked_options_count"].GetValue<int>();
                     var checkedOptions = new ArrayList();

                     if (checkedOptionsCount > 0)
                     {
                          for (var i = 0; i < checkedOptionsCount; i++)
                          {
                              checkedOptions.Add(formJSON["checked_options"][i].GetValue<string>());
                          }
                     }       

                return new Form(firstName, lastName, carModel, engineType, checkedOptionsCount, checkedOptions);

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return null;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}