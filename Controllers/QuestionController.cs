using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Net6WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ILogger<QuestionController> _logger;

    public QuestionController(ILogger<QuestionController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Why")]
    public ActionResult Why()
    {
        var result = new {
            Hello = "大家好！",
            Qustion = "想請求大家幫助我解答這個問題，為什麼我已經在program.cs的service加入AddJsonOptions Encoder，編碼還是無法顯示中文？",
            Thanks = "謝謝 :)"
            };
        var js = JsonSerializer.Serialize(result);
        return Ok(js);
    }
    

    [HttpGet("Solved")]
    public ActionResult Solved()
    {
        var options = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        
        var result = new {
            Message = "我知道這個方法可以，但是為什麼不能宣告全域呢？每一段JsonSerializer.Serialize都要先設定option這樣好像有點麻煩QQ"
            };
        var js = JsonSerializer.Serialize(result, options);
        return Ok(js);
    }
}
