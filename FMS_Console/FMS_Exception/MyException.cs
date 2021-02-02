using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Exception
{
    public class MyException : ApplicationException
    {
        public MyException()
        {

        }

        public MyException(string msg) : base(msg)
        {

        }
    }
}