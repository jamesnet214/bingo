using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWasm.Shared.ResponseModels
{
    public class ResponseData
    {
        public dynamic MainData { get; set; }
        public dynamic SubData { get; set; }
        public string Message { get; set; }
        
    }
}
