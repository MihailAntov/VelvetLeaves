using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelvetLeaves.Data.Configuration
{
    public class VelvetLeavesDbContextConfiguration
    {
        public bool SeedDb { get; set; }
        public string AdminEmail { get; set; } = null!;
        public string AdminPassword { get; set; } = null!;
    }
}
