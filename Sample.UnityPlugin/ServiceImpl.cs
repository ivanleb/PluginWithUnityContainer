using Sample.UnityPlugin.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UnityPlugin
{
    public class ServiceImpl : IService
    {
        public ServiceImpl()
        {
        }

        public void Do(string parameter)
        {
            Console.WriteLine("Action " + parameter);
        }
    }
}
