using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private IMapper _mapper;
        private IOrdersRepository _ordersRepository;
        private readonly ILogger<PayController> _logger;
        public PayController(ILogger<PayController> logger, IOrdersRepository ordersRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid id)
        {
            var order = _ordersRepository.GetOrderById(id);

            var orderToGet = _mapper.Map<OrderToGet>(order);

            return Ok(orderToGet);
        }

        [HttpPost()]
        public IActionResult AddOrder([FromBody] OrderToCreate orderToAdd)
        {
            if (orderToAdd == null)
                return BadRequest();

            var order = _mapper.Map<Order>(orderToAdd);

            if (order.StoreId == Guid.Empty)
                return new Helper.UnprocessableEntityResult(ModelState);

            _ordersRepository.Add(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<OrderToGet>(order);

            return CreatedAtRoute("GetProduct",
                new { id = orderToGet.OrderId },
                orderToGet);
        }
    }
}
