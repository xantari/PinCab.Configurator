using PinCab.Configurator.Utils;
using PinCab.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Configurator.Models
{
    public class DatabaseManagerBackgroundAction
    {
        public DatabaseManagerBackgroundAction()
        {
        }
        public DatabaseManagerBackgroundProgressAction Action { get; set; }
    }
}
