using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.Services.Contracts
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressListViewModel>> GetAddressOptionsAsync(string userId);
    }
}
