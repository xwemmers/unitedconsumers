using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenvragen
{
    class Class1 : Class2
    {
    }

    class Class2 : INewInterface
    {
        void INewInterface.Method1()
        {
            throw new NotImplementedException();
        }
    }

    interface INewInterface
    {
        void Method1();
    }
}
