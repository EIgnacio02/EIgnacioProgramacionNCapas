﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context = new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query=context.PaisGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        foreach (var row in query)
                        {
                            ML.Pais pais=new ML.Pais();

                            pais.IdPais=row.IdPais;
                            pais.Nombre=row.Nombre;

                            result.Objects.Add(pais);

                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                throw;
            }
            return result;
        }
    }
}
