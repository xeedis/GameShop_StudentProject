using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class HardwareRequirements
    {
        public int HardwareRequirementsId { get; set; }
        
        public string System { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }

        public string GraphicsCard { get; set; }
        public string DirectX { get; set; }
        public string HardDrive { get; set; }
        
    }
}