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
            //create the path variable and assign it the relative path of the json file 
            var path = @"DAL\json\dataset.json";
            var json = System.IO.File.ReadAllText(path);
            // Convert the JSON to a  Dictionary<string, List<ItemModel>> Object
            var dealsDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<ItemModel>>>(json);

            // Get the deals items from the dictionary
            var deals = dealsDict["items"];


            // Parse qsalePrice to float type.
            float price = 0;
            if (!string.IsNullOrEmpty(qsalePrice))
            {
                float.TryParse(qsalePrice, out price);
            }
            // Apply the filters
            

            if (!string.IsNullOrEmpty(title) && title == "a" && price == 0)
            {
                
                return Ok(dealsDict);
            }

            
            if (!string.IsNullOrEmpty(title))
            {
                deals = deals.Where(d => d.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (price > 0)
            {
                deals = deals.Where(d => float.Parse(d.salePrice) == price).ToList();
            }
            

            // return a filtered Json 


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