using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProverkiGov
{
    class Program
    {
        static void Main(string[] args)
        {
            GetXml().Wait();
        }

        public static async Task GetXml()
        {
            var service = new ProverkiGovService();
            await service.UpdateReestrProverki();
        }
    }
}
