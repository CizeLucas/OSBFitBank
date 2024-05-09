using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;
using System.Net.Http.Headers;


namespace FruitWebApp.Pages
{
    public class AddModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public FruitModel FruitModels { get; set; }

        // Begin POST operation code
        public async Task<IActionResult> OnPost() {
            // Serialize the information to be added to be sent in the HTTP Request
            var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels), Encoding.UTF8);

            // Create the HTTP client using the FruitAPI named factory
            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            //Creating a HTTP Request Message Object and intializing its attributes for setting up the correct request
            var httpReqMessage = new HttpRequestMessage();
            httpReqMessage.RequestUri = httpClient.BaseAddress; //new Uri("http://localhost:5050/fruitlist");
            httpReqMessage.Method = HttpMethod.Post;
            httpReqMessage.Content = jsonContent;
            //httpReqMessage.Content.Headers.Add("Content-Type", "application/json"); //I could not make it work
            //Sending the HttpReqMessage that we configured before (post req)
            HttpResponseMessage response = await httpClient.SendAsync(httpReqMessage);

            if(response.IsSuccessStatusCode){
                TempData["success"] = "Data was added successfully.";
                return RedirectToPage("Index");
            } else {
                TempData["faliure"] = "Data was added successfully.";
                return RedirectToPage("Index");
            }
        }
        // End POST operation code
    }
}

