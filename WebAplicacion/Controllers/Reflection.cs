using System;
using System.Collections.Generic;
using System.Linq;
using WebAplicacion.Models;
using System.Net.Http;
using System.Threading; 

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
            Type tOb1 = obj1.GetType();
            Type tOb2 = obj2.GetType();

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

        


        public  async void Comprar(object obj1, object obj2, string usuario, string relacionada)
         {

            List<LogersViewModel> logs = new List<LogersViewModel>();
            List<stObjDif> dif = new List<stObjDif>();
            dif =fieldsValuesDiff(obj1, obj2);

            foreach (var item in dif)
            {
                LogersViewModel log = new LogersViewModel();
                log.Usuario = usuario;
                log.Descripcion = string.Format("Se ha modificado el valor de {3} del Valor {0} al valor {1}", item.ValorObj1, item.ValorObj2, item.Campo);
                log.fecha = DateTime.Now;
                log.Relacion = relacionada;
            
                var cliente = new HttpClient();
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "mZCP5dT9sQn8gLK1IGcPS12xniDB9bcoC38pARZ29g6JZAXb");
                HttpResponseMessage response = await cliente.PostAsJsonAsync ( " http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarLogFactoring", log);
            }
        }

        

        
    }
} 
