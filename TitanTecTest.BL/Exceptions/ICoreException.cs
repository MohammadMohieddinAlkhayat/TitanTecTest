using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TitanTecTest.BL.Exceptions
{
    public interface ICoreException : ISerializable
    {
        string Code { get; set; }
        string Message { get; }
        Dictionary<string, string> ParametersErrors { get; set; }
    }
}
