using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schifffahrt
{
    public static class Controller
    {
        

        static SharedData _sharedata;

        public static SharedData sharedData
        {
            get { return _sharedata; }
            set { _sharedata = value; }
        }

    }
}
