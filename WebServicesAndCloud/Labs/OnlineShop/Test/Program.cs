using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using OnlineShop.Data;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new OnlineShopContext();
            var ads = context.Ads.Count();
        }
    }
}
