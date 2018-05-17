using System;
using System.Collections.Generic;
using System.Text;

namespace Webjs.src
{
    interface ISettings
    {
        string ParseURL { get; set; }
        string Prefix { get; set; }
        int StartPoint { get; set; }
        int Endpoint { get; set; }
    }
}
