﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.models
{
    public class Venta
    {
        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }

        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
    }
}
