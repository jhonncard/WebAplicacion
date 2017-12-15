using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WebAplicacion.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAplicacion.Controllers
{

    public class Reflectiones
    {
        public object objeto1 { get; set; }
        public object objeto2 { get; set; }
        public string  usuario { get; set; }
        public string relacion  { get; set; }
        private struct stObjDif
        {
            public string Campo;
            public string ValorObj1;
            public string ValorObj2;
        }

        private List<stObjDif> fieldsValuesDiff(object obj1, object obj2)
        {
            var tOb1 = obj1.GetType();
            var tOb2 = obj2.GetType();

            var listPropOrig = tOb1.GetProperties().Select(p => p).ToList();
            var listPropMod = tOb2.GetProperties().Select(p => p).ToList();

            return listPropMod.Where(pM => listPropOrig.Count(pO => (pO.Name == pM.Name && pO.GetValue(obj1) != null && pM.GetValue(obj2) != null
            && pO.GetValue(obj1).ToString() != pM.GetValue(obj2).ToString())) == 1
            ).Select(pResult => new stObjDif()
            {
                Campo = pResult.Name,
                ValorObj1 = pResult.GetValue(obj1).ToString(),
                ValorObj2 = listPropMod.FirstOrDefault(pM => pM.Name == pResult.Name).GetValue(obj2).ToString()
            }).ToList();
        }

        


        public  async Task<bool> Comprar(object obj1, object obj2, string user, string relacionada)
        {
            var resp = false;
            var logs = new List<LogersViewModel>();
            var dif = fieldsValuesDiff(obj1, obj2);
            
             if (dif.Any())
                  resp = true;
            foreach (var item in dif)
            {
                if (item.Campo.ToUpper() == "ID") continue;
                var log = new LogersViewModel
                {
                    usuario = user,
                    descipcion = string.Format("Se ha modificado el campo {2} con Valor {0} al valor {1}",
                        item.ValorObj1, item.ValorObj2, item.Campo),
                    relacion = relacionada
                };
                var cliente = new HttpClient();
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync ( " http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarLogFactoring", log);

              

            }

            return resp;


        }

        

        
    }
} 
