using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using Exiled.API.Enums;
using System.Collections.Specialized;
using PlayerRoles;
namespace ReverseFriendlyFire
{
    
   
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Should Reverse Friendly Fire should be enabled for MTF/ Guards")]
        public bool RFF_MTF { get; set; } = true;
        [Description("Should Reverse Friendly Fire should be enabled for Chaos")]
        public bool RFF_CHAOS { get; set; } = true;
        [Description("Multiplier for the damage returned to sender")]
        public float RFF_Multiplier { get; set; } = 1.5f;

        [Description("Should the vicitm still take damage")]
        public bool RFF_VictimDamage { get; set; } = false;

        [Description("Multipler for the damage for the victim if they still take damage")]

        public float RFF_VictimMultiplier { get; set; } = 0.25f;
       
      
    }
}
