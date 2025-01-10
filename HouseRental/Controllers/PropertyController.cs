using HouseRental.Interfaces;
using HouseRental.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HouseRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IWebHostEnvironment _environment;

        public PropertyController(IPropertyRepository propertyRepository, IWebHostEnvironment environment)
        {
            _propertyRepository = propertyRepository;
            _environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllProperties()
        {
            var properties = _propertyRepository.GetAllProperties();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetPropertyById(int id)
        {
            var property = _propertyRepository.GetPropertyById(id);
            if (property == null)
                return NotFound();
            return Ok(property);
        }

        [HttpGet("status/{status}")]
        [AllowAnonymous]
        public IActionResult GetPropertiesByStatus(string status)
        {
            var properties = _propertyRepository.GetPropertiesByStatus(status);
            return Ok(properties);
        }

        [HttpGet("category/{category}")]
        [AllowAnonymous]
        public IActionResult GetPropertiesByCategory(string category)
        {
            var properties = _propertyRepository.GetPropertiesByStatus(category);
            return Ok(properties);
        }

        [HttpGet("country/{country}")]
        [AllowAnonymous]
        public IActionResult GetPropertiesByCountry(string country)
        {
            var properties = _propertyRepository.GetPropertiesByCountry(country);
            return Ok(properties);
        }

        [HttpGet("city/{city}")]
        [AllowAnonymous]
        public IActionResult GetPropertiesByCity(string city)
        {
            var properties = _propertyRepository.GetPropertiesByCity(city);
            return Ok(properties);
        }

        [HttpGet("subcity/{subcity}")]
        [AllowAnonymous]
        public IActionResult GetPropertiesBySubcity(string subcity)
        {
            var properties = _propertyRepository.GetPropertiesBySubcity(subcity);
            return Ok(properties);
        }

        [HttpPost]
        [Authorize(Roles = "Staff")]
        public IActionResult AddProperty([FromForm] PropertyUploadModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Property == null)
            {
                return BadRequest("Property details are missing.");
            }

            if (model.ImageFile != null)
            {
                if (string.IsNullOrEmpty(_environment.WebRootPath))
                {
                    return StatusCode(500, "The web root path is not configured.");
                }

                try
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    model.Property.Imgurl = $"images/{uniqueFileName}";
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while uploading the file: {ex.Message}");
                }
            }

            try
            {
                _propertyRepository.AddProperty(model.Property);
                return CreatedAtAction(nameof(GetAllProperties), new { id = model.Property.PropertyId }, model.Property);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the property: {ex.Message}");
            }
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdatePropertyStatus(int id, [FromBody] string newStatus)
        {
            try
            {
                _propertyRepository.UpdatePropertyStatus(id, newStatus);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the property status: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Staff")]
        public IActionResult DeleteProperty(int id)
        {
            try
            {
                _propertyRepository.DeleteProperty(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the property: {ex.Message}");
            }
        }
    }

    public class PropertyUploadModel
    {
        public Property Property { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
