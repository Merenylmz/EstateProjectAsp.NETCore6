using EmlakSiteAPI.Application.Repositories.Adverts;
using EmlakSiteAPI.Application.ViewModel.Adverts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmlakSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertReadRepository _advertReadRepository;
        private readonly IAdvertWriteRepository _advertWriteRepository;

        public AdvertController(IAdvertWriteRepository advertWriteRepository, IAdvertReadRepository advertReadRepository)
        {
            _advertWriteRepository = advertWriteRepository;
            _advertReadRepository = advertReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = _advertReadRepository.GetAll(false);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var values = await _advertReadRepository.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddData(Vm_AddAdvert advert)
        {

            await _advertWriteRepository.AddAsync(new()
            {
                Name = advert.Name,
                Description = advert.Description,
                ImageUrl = advert.ImageUrl,
                Price = advert.Price,
                UserId = advert.UserId
            });

            await _advertWriteRepository.SaveAsync();

            return Ok((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData(Vm_UpdateAdvert advert)
        {
            var data = await _advertReadRepository.GetByIdAsync(advert.Id);
            data.Description = advert.Description;
            data.Price = advert.Price;
            data.UserId = advert.UserId;
            data.ImageUrl = advert.ImageUrl;
            data.Name = advert.Name;

            await _advertWriteRepository.SaveAsync();

            return Ok((int)HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(string id)
        {
            var data = await _advertReadRepository.GetByIdAsync(id);
            _advertWriteRepository.Delete(data);
            await _advertWriteRepository.SaveAsync();
            return Ok((int)HttpStatusCode.OK);
        }
    }
}
