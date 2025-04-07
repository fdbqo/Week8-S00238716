using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductModel;

namespace ProductWebAPI2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Store Manager")]
    public class GRNController : ControllerBase
    {
        private readonly IGRN<GRN> _grnRepository;

        public GRNController(IGRN<GRN> grnRepository)
        {
            _grnRepository = grnRepository;
        }

        // GET: api/GRN
        [HttpGet]
        public ActionResult<IEnumerable<GRN>> GetAll()
        {
            return Ok(_grnRepository.GetAll());
        }

        // GET: api/GRN/5
        [HttpGet("{id}")]
        public ActionResult<GRN> Get(int id)
        {
            var grn = _grnRepository.Get(id);
            if (grn == null)
                return NotFound();

            return Ok(grn);
        }
    }
}