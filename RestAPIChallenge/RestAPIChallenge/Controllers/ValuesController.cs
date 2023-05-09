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
            // Leer el archivo JSON
            var path = "C:\\Users\\ldz-z\\OneDrive\\Escritorio\\deals-dataset.json";
            var json = System.IO.File.ReadAllText(path);
            // Convertir el JSON a un objeto Dictionary<string, List<ItemModel>>
            var dealsDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<ItemModel>>>(json);

            // Obtener la lista de items desde el diccionario
            var deals = dealsDict["items"];

            // Resto del código...

            // Convertir el JSON a una lista de objetos ItemModel
            //List<ItemModel> deals = System.Text.Json.JsonSerializer.Deserialize<List<ItemModel>>(json);

            // Parsear el qsalePrice a float
            float price = 0;
            if (!string.IsNullOrEmpty(qsalePrice))
            {
                float.TryParse(qsalePrice, out price);
            }

            // Aplicar los filtros
            if (!string.IsNullOrEmpty(title))
            {
                deals = deals.Where(d => d.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (price > 0)
            {
                deals = deals.Where(d => float.Parse(d.salePrice) == price).ToList();
            }

            // Devolver la lista filtrada en formato JSON


            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(qsalePrice))
            {
                return Ok(new Dictionary<string, List<ItemModel>>());
            }



            /*
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(qsalePrice))
            {
                return Ok(new List<ItemModel>());
            }*/
            else
            {
                return Ok(deals);
            }
        }


        /*    [HttpGet("deals")]
            public IActionResult GetDeals(string title = null, string? qsalePrice = null)
            {
                // Leer el archivo JSON
                var path = "C:\\Users\\ldz-z\\OneDrive\\Escritorio\\deals-dataset.json";
                var json = System.IO.File.ReadAllText(path);

                // Convertir el JSON a una lista de objetos Deal
                List<ItemModel> deals= System.Text.Json.JsonSerializer.Deserialize<List<ItemModel>>(json);
                //ItemModel deals = JsonConvert.DeserializeObject<ItemModel>(json);
                float price=float.Parse(qsalePrice);
                // Aplicar los filtros
                if (!string.IsNullOrEmpty(title))
                {
                    deals = deals.Where(d => d.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (price>0)
                {
                    deals = float.Parse(qsalePrice) > 0 ? deals.Where(d => float.Parse(d.salePrice) > price).ToList() : deals.Where(d => float.Parse(d.salePrice) < price).ToList();
                }

                // Devolver la lista filtrada en formato JSON
                if (deals.Count == 0 && string.IsNullOrEmpty(title))
                {
                    return Ok(new List<ItemModel>());
                }
                else
                {
                    return Ok(deals);
                }
            }*/

    }
}