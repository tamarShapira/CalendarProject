using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetScriptContent()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://www.hebcal.com/etc/hdate-he.js");
                if (response.IsSuccessStatusCode)
                {
                    string scriptContent = await response.Content.ReadAsStringAsync();
                    return Ok(scriptContent);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }
    }
}
