using EmlakSiteAPI.Application.Repositories.Messages;
using EmlakSiteAPI.Application.ViewModel.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmlakSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageWriteRepository _messageWriteRepository;
        private readonly IMessageReadRepository _messageReadRepository;

        public MessageController(IMessageWriteRepository messageWriteRepository, IMessageReadRepository messageReadRepository)
        {
            _messageWriteRepository = messageWriteRepository;
            _messageReadRepository = messageReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _messageReadRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> NewMessage(Vm_AddMessage vm_AddMessage)
        {
            await _messageWriteRepository.AddAsync(new(){
                Email = vm_AddMessage.Email,
                MessageTitle = vm_AddMessage.MessageTitle,
                MessageDescription = vm_AddMessage.MessageDescription,
            });

            await _messageWriteRepository.SaveAsync();

            return Ok(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageWriteRepository.DeleteAsync(id);
            await _messageWriteRepository.SaveAsync();

            return Ok((int)HttpStatusCode.OK);
        }
    }

}
