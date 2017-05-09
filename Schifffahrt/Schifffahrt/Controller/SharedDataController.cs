using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schifffahrt.Model;

namespace Schifffahrt.Controller
{
    public static class SharedDataController
    {
        static SharedData _sharedata;

        public static SharedData sharedData
        {
            get { return _sharedata; }
            set { _sharedata = value; }
        }

    }
}
