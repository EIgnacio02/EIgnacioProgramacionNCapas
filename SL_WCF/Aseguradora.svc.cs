using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Aseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Aseguradora.svc or Aseguradora.svc.cs at the Solution Explorer and start debugging.
    public class Aseguradora : IAseguradora
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            return new SL_WCF.Result { Correct=result.Correct, Message=result.Message, Ex=result.Ex,Objects=result.Objects,Object=result.Object};
        }


        public SL_WCF.Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Aseguradora.GetById(IdUsuario);
            return new SL_WCF.Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex, Objects = result.Objects, Object = result.Object };
        }
        public SL_WCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Add(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex, Objects = result.Objects, Object = result.Object };
        }

        public SL_WCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Update(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex, Objects = result.Objects, Object = result.Object };
        }

        public SL_WCF.Result Delete(int IdUsuario)
        {
            ML.Result result = BL.Aseguradora.Delete(IdUsuario);
            return new SL_WCF.Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex, Objects = result.Objects, Object = result.Object };
        }
    }
}
