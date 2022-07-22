using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoWebAPI.Repositories;
using DemoWebAPI.Models;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        ICollegeRepo _colzRepo;
        public CollegeController(ICollegeRepo colzRepo)
        {
            _colzRepo = colzRepo;
        }
        [HttpPost]
        [Route("add-college")]
        public IActionResult AddCollege(College colz)
        {
            if (colz == null)
            {
                return BadRequest("Invalid Data");
            }
            try
            {
                var clz = _colzRepo.AddCollegeData(colz);
                if (clz!= null)
                {
                    return Ok($"{clz.Id}");
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpGet("get-all-colleges")]
        public IActionResult GetAllColleges()
        {
            try
            {
                var colzList = _colzRepo.GetAllCollegeData();
                if(colzList!=null)
                {
                    return Ok(colzList);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("get-college/{id}")]
        public IActionResult GetCollege(int id)
        {
            try
            {
                var colz = _colzRepo.GetCollegeData(id);
                if (colz != null)
                {
                    return Ok(colz);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut("edit-college/{id}")]
        public IActionResult EditCollege(int id,College c)
        {
            if(id != c.Id)
            {
                return BadRequest();
            }
            try
            {
                var colz = _colzRepo.UpdateCollegeData(id,c);

                if (colz != null)
                {
                    return Ok(colz);
               
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteCollege/{id}")]
        public IActionResult DeleteCollege(int id)
        {
            try
            {
                var colz = _colzRepo.DeleteCollegeData(id);
                if (colz != null)
                {
                    return NoContent();

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
