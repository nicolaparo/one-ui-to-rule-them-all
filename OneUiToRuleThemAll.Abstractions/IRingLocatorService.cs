using OneUiToRuleThemAll.Abstractions.Models;

namespace OneUiToRuleThemAll.Abstractions
{

    public interface IRingLocatorService
    {
        Task<Location> LocateRingAsync();
    }

}
