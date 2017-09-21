using System;
using System.Collections.Generic;
using System.Text;

namespace AstroAnts.JsonServices.DataModels
{
    class RequestAntModel
    {
        public RequestAntModel(string path)
        {
            this.path = path;
        }

        public string path { get; set; }
    }
}
