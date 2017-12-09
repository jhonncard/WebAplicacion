using System;
using System.Collections.Generic;
using System.Linq;
using static Factoring.Negocios.Reflection;

namespace Factoring.Negocios
{
    public class Reflection
    {
        public struct stObjDif
        {
            public string Campo;
            public string ValorObj1;
            public string ValorObj2;
        }

        public List<stObjDif> fieldsValuesDiff(object obj1, object obj2)
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
    }
}