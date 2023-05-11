using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestAPIChallenge.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RestAPIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("deals")]
        public IActionResult GetDeals(string? title = null, string? qsalePrice = null)
        {
            // Read the JSON file
            var path = @"DAL\\json\\dataset.json";
            var json = System.IO.File.ReadAllText(path);
            // Convert the JSON to a  Dictionary<string, List<ItemModel>> object
            var dealsDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<ItemModel>>>(json);

            // Get all games in the the dictionary 
            var deals = dealsDict["items"];

            // Parse qsalePrice to float type.
            float price = 0;
            if (!string.IsNullOrEmpty(qsalePrice))
            {
                float.TryParse(qsalePrice, out price);
            }

            //Apply filters
            if (!string.IsNullOrEmpty(title))
            {
                deals = deals.Where(d => d.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (price > 0)
            {
                deals = deals.Where(d => float.Parse(d.salePrice) == price).ToList();
            }

            // Return the filtered list with JSON format


            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(qsalePrice))
            {
                return Ok(new Dictionary<string, List<ItemModel>>());
            }




            else
            {
                return Ok(deals);
            }
        }
    }
}


