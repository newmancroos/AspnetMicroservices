using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _oderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        public UpdateOrderCommandHandler(IOrderRepository oderRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateOrderCommandHandler> logger)
        {
            _oderRepository = oderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _oderRepository.GetByIdAsync(request.Id);

            if (orderToUpdate == null)
            {
                _logger.LogError("Order not exist on database.");
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));
            await _oderRepository.UpdateAsync(orderToUpdate);
            return Unit.Value;
        }
    }
}
