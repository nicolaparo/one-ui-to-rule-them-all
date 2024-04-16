using OneUiToRuleThemAll.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneUiToRuleThemAll.MauiHybridApp.Services
{
    public class MauiRingLocatorService : IRingLocatorService
    {
        public Task<Abstractions.Models.Location> LocateRingAsync()
        {
            return Task.FromResult(new Abstractions.Models.Location { X = .5f, Y = .5f });
        }

   
    }
}
