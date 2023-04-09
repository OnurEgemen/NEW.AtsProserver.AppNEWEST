using AtsProServer.App.Application.Features.CQRS.Commands;
using AtsProServer.App.Application.Features.CQRS.Queries;
using AtsProServer.App.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AtsProServer.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        
        public async Task<IActionResult> Login (CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı ya da şifre hatalı");
            }
        }


        /*Kullanıcıları biz atayacağımız için bu şekilde yazdım
        eğer kullanıcıya bırakacaksak if kontrolü ile daha önce aynı isim ile
        kayıt yapılıp yapılmadığını kontrol eden bir kontrol bloğu ekleyebiliriz.
        Kendi kullancılarını eklemeleri durumuna göre bir register yapısı oluşturulabilir.
        örn: Bir kullanıcı bir kullanıcıya yetki verip alır vb. */

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("",result);
        }


    }
}
