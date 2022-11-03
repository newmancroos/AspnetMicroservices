using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private ILogger<DeleteOrderHandler> _logger;
        private IMapper _mapper;
        private IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<DeleteOrderHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);

            if (orderToDelete == null)
            {
                _logger.LogError($"Order not exist on the database");
                throw new NotFoundException(nameof(orderToDelete), request.Id);
            }
            await _orderRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
