using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Hosting;
using System.Web.Http;

namespace sca.Controllers.api
{
    public class CursoController : ApiController
    {
        // GET api/<controller>/arquitetura
        public IEnumerable<CursoDetalhe> Get(string termo)
        {
            var nomeDoCache = "curso" + termo;
            var curso = PegaDoCache<List<CursoDetalhe>>(nomeDoCache, () =>
            {
                using (var r = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + "/Data/curso.json",System.Text.Encoding.ASCII))
                {
                    string json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<CursoDetalhe>>(json);
                    items.Where(x => x.Curso.ToLower().Contains(termo.ToLower()) || x.Info.Contains(termo.ToLower()));

                    return items;
                }
            });
            return curso;
        }

        private T PegaDoCache<T>(string key, Func<T> valueFactory) where T : class
        {
            var cache = MemoryCache.Default;
            var value = new Lazy<T>(valueFactory);
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) };
            var lazyCache = (Lazy<T>)cache.AddOrGetExisting(key, value, policy);
            return (lazyCache == null ? value.Value : lazyCache.Value);
        }
    }
    
    public class CursoDetalhe
    {
        public string _Id { get; set; }
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public int Vagas { get; set; }
        public string Info { get; set; }
        public int Nota { get; set; }
    }
}