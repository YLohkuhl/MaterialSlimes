using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRML.Config.Attributes;

namespace Configs
{
    [ConfigFile("config", "MS_SETTINGS")]
    class Values
    {
        public static readonly bool OLD_APPEARANCES = false;
    }
}