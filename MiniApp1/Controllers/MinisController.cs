using Microsoft.AspNetCore.Mvc;
using MiniApp1.Filters;
using MiniApp1.Filters.Exception_Filters;
using MiniApp1.Models;
using MiniApp1.Models.Repositories;

namespace MiniApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinisController : ControllerBase  // : means extends
    {

        [HttpGet]
        //Action Methods
        public IActionResult GetMinis()
        {
            return Ok(MiniRepo.GetMinis());
        }

        [HttpGet("{id}")]
        [Mini_ValidateMiniIdFilter]

        public IActionResult GetMiniById(int id)
        {
            return Ok(MiniRepo.GetMiniById(id));
        }

        [HttpPost]
        [Mini_ValidateCreateMiniFilter]
        public IActionResult CreateMini([FromBody] Mini mini)
        {
            MiniRepo.AddMini(mini);

            return CreatedAtAction(nameof(GetMiniById),
                new { id = mini.MiniId },
                mini);
        }

        [HttpPut("{id}")]
        [Mini_ValidateMiniIdFilter]
        [Mini_ValidateUpdateMiniFilter]
        [Mini_HandleUpdateExceptionsFilter]
        public IActionResult UpdateMini(int id, Mini mini)
        {
            MiniRepo.UpdateMini(mini);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Mini_ValidateMiniIdFilter]
        public IActionResult DeleteMini(int id)
        {
            var mini = MiniRepo.GetMiniById(id);
            MiniRepo.DeleteMini(id);

            return Ok(mini);
        }

    }
}