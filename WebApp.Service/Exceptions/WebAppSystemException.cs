using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Service.Exceptions
{
    public class WebAppSystemException:Exception
    {
        public int Code { get; set; }
        public WebAppSystemException(int code, string message):base(message)
        {
            Code = code;
        }
    }
}
