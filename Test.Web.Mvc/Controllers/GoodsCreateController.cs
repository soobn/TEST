using BF.Data.Repostories;
using BF.Web.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Goods;
using Model.Goods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.Mvc.Controllers
{
    [ApiController,Route("[controller]")]
    public class GoodsCreateController:BaseApiController, IRequestHandler<GoodsCreateDto,ReturnValue<GoodsDto>>
    {

        private readonly ILogger<GoodsCreateDto> _logger;
        private readonly IRepository<GoodsInfo, Guid> _repository;

        public GoodsCreateController(ILogger<GoodsCreateDto> logger, IRepository<GoodsInfo,Guid> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpPost]
        public async Task<ReturnValue<GoodsDto>> Handle(GoodsCreateDto request)
        {
            var result = new ReturnValue<GoodsDto>();
            if (_repository.Any(x => x.Url.Equals(request.Url)))
            {
                var entity = ObjectMapper.Map<GoodsInfo>(request);
                var r= await _repository.InsertAsync(entity);
                result.True(ObjectMapper.Map<GoodsDto>(r));
            }
            else {
                result.False("URL已经存在");
            }
            return result;
        }
    }
}
