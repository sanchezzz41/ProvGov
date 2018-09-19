using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProverkiGov.Models;

namespace ProverkiGov
{
    public class ProverkiGovService
    {
        private readonly HttpClient _httpClient;

        public ProverkiGovService()
        {
            //Сайт https://proverki.gov.ru
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://proverki.gov.ru")
            };
        }

        public async Task UpdateReestrProverki()
        {
            var reestr = await GetReestr();
            await GetLastVerification(reestr);
        }

        private async Task<List<ReestrItem>> GetReestr()
        {
            //Ниже Url содержит ссылку на Открытые данные/реестр наборов данных
            //TODO проверить, не меняется ли ссылка со временем
            //Много непонятных символов это хз что
            var url =
                "/wps/portal/Home/opendata/!ut/p/" +
                "z1/lZLNTsJAEMdfpRx6LDNbPoregETCwRjBCt0LWeyCK_1KKZVw4q7vwCPYoCRGo77C9o3setKDoHOZmex" +
                "_fskvWaAwBBqwVExZIsKAeeCAQ61Rt9vokg6S00blqI3neNKqdi57iNUaDFLBb8H22VL4YsVd6AMFKlxwiBoSkXgcHLmRrzKTb_JdbvM7udPkR75Wi9wV_UU-a8VbpsmHom1llq" +
                "_ze81EUtPkY5F6kplieSKYgXOdJNH8WEcdozhMeTwT5WmYluOFjmHEA5clTEfLIkiqdYKmEXksCLhriGAe8SulZSiyQcpL31PYSRj7LAFHrcNCt_6rLlow-Argj2piq2e2KoidMxPo" +
                "_--_k_52vydA9-MHyviAwSHGRRHY-yf68WLUsyHy2-MVH68mvm0P8abWbJZKn18D-PY!/dz/d5/L2dBISEvZ0FBIS9nQSEh" +
                "/p0/IZ7_II8I1G01M839C0Q0FB4GVR0046=CZ6_II8I1G01M839C0Q0FB4GVR0007=NJ" +
                "downloadRegistryXml=/";

            var result = await GetXmlRequest<ProverkiList>(url);
            //Берем для примера 5 последних данных, так как 
            //все нам не нужны(можно кол-во поменять)
            return result.Standardversion.Item
                .OrderBy(x => x.Identifier)
                .TakeLast(5)
                .ToList();
        }

        /// <summary>
        /// Возвращаем последнию проверку(хз может и не нужно)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private async Task GetLastVerification(IEnumerable<ReestrItem> items)
        {
            //Берем список проверок, сортируем по id ещё лучше по дате потом искать
            var lastItem = items.OrderBy(x => x.Identifier).Last();
            //Делаем запрос на получение xml документа проверки(в данном случае)
            //на последний месяц и год в реестре
            //В списке Data лежат ссылки на нужные в итоге zip файлы
            //Сделать проверку на пустоту xml файлв в zip(такое бывает, что там нет данных)
            //И ещё по дате надо сортировать
            var meta = await GetXmlRequest<Meta>(lastItem.Link);
        }

        private async Task<T> GetXmlRequest<T>(string uri) where T : class
        {
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStreamAsync();
            //Эти данные в виде xml
            var serializer = new XmlSerializer(typeof(T));
            var result = (T)serializer.Deserialize(content);
            return result;
        }
    }
}