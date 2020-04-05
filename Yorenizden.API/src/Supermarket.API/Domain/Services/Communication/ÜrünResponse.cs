using Yorenizden.API.Domain.Models;

namespace Yorenizden.API.Domain.Services.Communication
{
    public class ÜrünResponse : BaseResponse<Ürün>
    {
        public ÜrünResponse(Ürün ürün) : base(ürün) { }

        public ÜrünResponse(string message) : base(message) { }
    }
}