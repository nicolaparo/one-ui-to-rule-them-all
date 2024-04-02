using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Abstractions.Models;

namespace OneUiToRuleThemAll.Services
{
    public class RingLocatorService : IRingLocatorService
    {
        public Task<Location> LocateRingAsync()
        {
            return Task.FromResult(new Location { X = .53f, Y = .52f });
        }
    }

    //public record OrderData
    //{
    //    public string Customer { get; set; }
    //    public List<OrderDetailData> Details { get; set; } = new();
    //}
    //public record OrderDetailData
    //{
    //    public Guid ProductId { get; set; }
    //    public int Quantity { get; set; }
    //}

}
