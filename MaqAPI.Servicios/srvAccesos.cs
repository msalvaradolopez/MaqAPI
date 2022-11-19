﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MaqAPI.Entidades;

namespace MaqAPI.Servicios
{
    public class srvAccesos
    {
        public OperadorEntidad operadorEntidad { get; set; }
        private srvOperadores _svrOPeradores = new srvOperadores();
        public string Login() {

            try
            {
                var _operadorEntity = _svrOPeradores.ListadoPorId(this.operadorEntidad.idOperador);
                var _operador = JsonConvert.DeserializeObject<OperadorEntidad>(JsonConvert.SerializeObject(_operadorEntity, Newtonsoft.Json.Formatting.None));

                if (_operador == null)
                    throw new Exception("Usuario no existe.");

                if(_operador.estatus == "B")
                    throw new Exception("Usuario dado de baja.");

                if (_operador.passw != this.operadorEntidad.passw)
                    throw new Exception("La constraseña no es correcta.");

                if(_operador.categoria == "O")
                    throw new Exception("Usuario no autorizado.");

                return _operador.categoria;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
