using FluentDateTime;
using Newtonsoft.Json;
using PinCab.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    [Serializable]
    public class AuthenticationSettings
    {
        public AuthenticationSettings()
        {
        }

        public string GithubAccessToken { get; set; }
    }
}

