using Application.Features.SocialLinks.Commands.CreateSocialLink;
using Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Models;
using Application.Features.SocialLinks.Queries.GetListSocialLink;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListSocialLinkQuery getListSocialLinkQuery)
        {
            SocialLinkListModel result = await Mediator.Send(getListSocialLinkQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialLinkCommand createSocialLinkCommand)
        {
            CreatedSocialLinkDto result = await Mediator.Send(createSocialLinkCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialLinkCommand updateSocialLinkCommand)
        {
            UpdateSocialLinkDto result = await Mediator.Send(updateSocialLinkCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteSocialLinkCommand deleteSocialLinkCommand)
        {
            DeletedSocialLinkDto result = await Mediator.Send(deleteSocialLinkCommand);
            return Ok(result);
        }
    }
}
