using Discount.Grpc.Protos;
using Grpc.Net.Client;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            try
            {

                var discountRequest = new GetDiscountRequest { ProductName = productName };

                //using var channel = GrpcChannel.ForAddress("http://localhost:5003");
                //var client = new DiscountProtoServiceClient(channel);
                //var sdasd = client.GetDiscount(discountRequest);

                return await _discountProtoService.GetDiscountAsync(discountRequest);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
