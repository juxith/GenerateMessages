using GenerateMessages.BLL;
using GenerateMessages.Models;
using System.Web.Http;

namespace GenerateMessages.Controllers
{
    public class RouteController : ApiController
    {
        Manager mgr = Factory.Create();

        [Route("api/index/guests")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetGuests()
        {
            var guests = mgr.LoadAllGuests();

            if (guests == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(guests);
            }
        }

        [Route("api/index/companies")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetCompanies()
        {
            var companies = mgr.LoadAlCompanies();

            if (companies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(companies);
            }
        }

        [Route("api/index/templates")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTemplates()
        {
            var templates = mgr.LoadAllTemplates();

            if (templates == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(templates);
            }
        }

        [Route("api/index/template/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult PreviewTemplate(int id)
        {
            var template = mgr.LoadTemplate(id);

            if (template == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(template);
            }
        }


        [Route("api/index/generate/{guestId}/{companyId}/{templateId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GenerateMessage(int guestId, int companyId, int templateId)
        {
            var repo = Factory.Create();
            var guest = mgr.LoadGuest(guestId);
            var company = mgr.LoadCompany(companyId);
            var template = mgr.LoadTemplate(templateId);
            var message = mgr.LoadMessage(guest, company, template);

            if (message == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(message);
            }
        }

        [Route("api/index/template/add/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddTemplate(Template model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var template = new Template()
            {
                Name = model.Name,
                Message = model.Message
            };

            mgr.CreateTemplate(template);

            return Created($"api/index/template/{template.Id}", template);
        }
    }
}
