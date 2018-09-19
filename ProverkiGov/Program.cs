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
            Console.WriteLine("Hello World!");
        }

        public static async Task GetXml()
        {
            var url =
                "https://proverki.gov.ru/wps/portal/Home/opendata/!ut/p/" +
                "z1/lZLNTsJAEMdfpRx6LDNbPoregETCwRjBCt0LWeyCK_1KKZVw4q7vwCPYoCRGo77C9o3setKDoHOZmex" +
                "_fskvWaAwBBqwVExZIsKAeeCAQ61Rt9vokg6S00blqI3neNKqdi57iNUaDFLBb8H22VL4YsVd6AMFKlxwiBoSkXgcHLmRrzKTb_JdbvM7udPkR75Wi9wV_UU-a8VbpsmHom1llq" +
                "_ze81EUtPkY5F6kplieSKYgXOdJNH8WEcdozhMeTwT5WmYluOFjmHEA5clTEfLIkiqdYKmEXksCLhriGAe8SulZSiyQcpL31PYSRj7LAFHrcNCt_6rLlow-Argj2piq2e2KoidMxPo" +
                "_--_k_52vydA9-MHyviAwSHGRRHY-yf68WLUsyHy2-MVH68mvm0P8abWbJZKn18D-PY!/dz/d5/L2dBISEvZ0FBIS9nQSEh" +
                "/p0/IZ7_II8I1G01M839C0Q0FB4GVR0046=CZ6_II8I1G01M839C0Q0FB4GVR0007=NJ" +
                "downloadRegistryXml=/";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStreamAsync();
            var str = await response.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(ProverkiList));
            var obj = serializer.Deserialize(content);
            
            using (var file = new FileStream("./list.xml",FileMode.Create,FileAccess.ReadWrite))
            {
                content.Seek(0, SeekOrigin.Begin);
                await content.CopyToAsync(file);
            }
        }
    }


}
