/*using Microsoft.AspNetCore.Mvc;
using RestAPIChallenge.DAL.Models;
using System.Text.Json;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetDeals(
            //property binding for query strings
            [FromQuery (Name ="title")]string qtitle,
            [FromQuery(Name ="salePrice")]string qsalePrice
            )
           
      

        {
            //string filePath = "C:\\Users\\ldz-z\\OneDrive\\Escritorio\\deals-dataset.json";
            try
            {
                //string JsonData = "C:\\Users\\ldz-z\\OneDrive\\Escritorio\\example.json";
                string filePath = "C:\\Users\\ldz-z\\OneDrive\\Escritorio\\deals-dataset.json";
                string json = System.IO.File.ReadAllText(filePath); // Leer el archivo como una cadena
                JObject jsonObj = JObject.Parse(json); // Analizar el JSON como un objeto de JObject
                JArray items = (JArray)jsonObj["items"]; // Obtener el arreglo de objetos bajo la clave "items"

                // Iterar sobre los elementos en el arreglo y obtener sus propiedades
                /* foreach (JObject item in items)
                 {
                     string title = (string)item["title"];
                     string sale_price = (string)item["salePrice"];
                     //if(float.Parse(sale_price) >2) {
                     //    Console.WriteLine("too expensive!!!");
                     //}
                     Console.WriteLine("JSON DATA " + item["title"]+ item["salePrice"]);

                     // Hacer algo con los datos obtenidos...
                 }*/

        //        if (!string.IsNullOrEmpty(qtitle))
      //          {
    //                items = new JArray(await items.Where(deal =>
   //                     ((string)deal["title"]).Contains(qtitle, StringComparison.OrdinalIgnoreCase)).ToListAsync());
     //           }

                /* if (!string.IsNullOrEmpty(qdescription))
                 {
                     items = new JArray(await items.Where(deal =>
                         ((string)deal["description"]).Contains(qdescription, StringComparison.OrdinalIgnoreCase)).ToListAsync());
                 }*/
      //          float price = float.Parse(qsalePrice);
      //          if (price>0)
         //       {
                    
                   /* items = new JArray(await items.Where(deal =>
                        deal["salePrice"] != null && (float)deal["salePrice"] >= qsalePrice.Value).ToListAsync());
                    items = new JArray(await items.Where(deal =>
                        deal["salePrice"] != null && (decimal)deal["salePrice"] <= maxSalePrice.Value).ToListAsync());*/
             //   }
         ////       return new JsonResult(items);
            

                /*if (maxSalePrice.HasValue)
                {
                    deals = new JArray(await deals.Where(deal =>
                        deal["salePrice"] != null && (decimal)deal["salePrice"] <= maxSalePrice.Value).ToListAsync());
                }*/

              

















































                //Check for existance of JSON file and corrrect path 
                //if(JsonData!=null||JsonData!="") {
                //FileStream data=System.IO.File.ReadAllTextAsync(JsonData);
                //string data = "";
                //var data = await System.IO.File.ReadAllTextAsync(JsonData);
                //await Console.Out.WriteLineAsync("Json Data" +data);
                //if
                //}
  //          }
  //          catch (Exception)
    //        {

  //              throw;
  //          }
   //         return new JsonResult(null);

            //string jsonString = File.ReadAllText(JsonData);
            //ItemModel myClass = JsonSerializer.Deserialize<ItemModel>(jsonString);
            //Console.WriteLine("data: "+myClass);
            //return new string[] { "value1", "value2" };
//        }
        

        // GET api/<ValuesController>/5
     /*   [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<ValuesController>
     /*   [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}*/
