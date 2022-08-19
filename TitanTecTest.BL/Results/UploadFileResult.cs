using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanTecTest.BL.Results
{
    public class UploadFileResult:Result
    {
        public string FileName { get; set; }
        public bool IsUploadedSuccessFully { get; set; }
    }
}
