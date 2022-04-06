using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api
{
    public class Sample: Test
    {
        public Sample()
        {
            var x = new Test();
        }

        public override void Q()
        {
            throw new NotImplementedException();
        }
    }

    public interface Poo
    {
        void T();
    }
    public class Test
    {
        public virtual void Q()
        {
            Console.WriteLine("Q");
        }
    }

    public class Testing
    {
        protected void Test()
        {

        }
    }

}
