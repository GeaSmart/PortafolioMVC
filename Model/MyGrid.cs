using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyGrid
    {
        public string columna { get; set; }
        public string columna_orden { get; set; }
        public int limite { get; set; }
        public int pagina { get; set; }

        public List<MyGridFiltro> filtros { get; set; }
        public List<MyGridParametro> parametros { get; set; }

        private MyGridResponde aresponde = new MyGridResponde();

        public void Inicializar()
        {
            /* Cantidad de registros por página */
            pagina = pagina - 1;

            /* Desde que número de fila va a paginar */
            if (pagina > 0) pagina = pagina * limite;

            /* Filtros */
            if (filtros == null)
                filtros = new List<MyGridFiltro>();

            /* Parametros adicionales */
            if (parametros == null)
                parametros = new List<MyGridParametro>();
        }

        public void SetData(dynamic data, int total)
        {
            aresponde = new MyGridResponde
            {
                data = data,
                total = total
            };
        }

        public MyGridResponde responde()
        {
            return aresponde;
        }
    }

    public class MyGridResponde
    {
        public int total { get; set; }
        public dynamic data { get; set; }
    }

    public class MyGridFiltro
    {
        public string columna { get; set; }
        public string valor { get; set; }
    }

    public class MyGridParametro
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }
}
