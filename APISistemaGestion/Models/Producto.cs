using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.models
{
    public class Producto
    {
        private int _id;
        private string _descripcion;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private int _idUsuario;


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public decimal precioventa
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }
        public int stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public int idusuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

    }
}
