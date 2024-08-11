namespace EspacioCalculadora
{
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }

    public class Calculadora
    {
        private double dato;
        private List<Operacion> historial;

        public double Resultado { get => dato; }
        public List<Operacion> Historial { get => historial; set => historial = value; }

        // Constructor
        public Calculadora()
        {
            dato = 0;
            historial = new List<Operacion>();
        }

        // Operaciones

        public void Sumar(double termino)
        {
            double anterior = dato;
            dato += termino;
            AgregarOperacion(anterior, dato, TipoOperacion.Suma);
        }

        public void Restar(double termino)
        {
            double anterior = dato;
            dato -= termino;
            AgregarOperacion(anterior, dato, TipoOperacion.Resta);
        }

        public void Multiplicar(double termino)
        {
            double anterior = dato;
            dato *= termino;
            AgregarOperacion(anterior, dato, TipoOperacion.Multiplicacion);
        }

        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                double anterior = dato;
                dato /= termino;
                AgregarOperacion(anterior, dato, TipoOperacion.Division);
            }
            else
            {
                Console.WriteLine("No se puede dividir por 0");
            }
        }

        public void Limpiar()
        {
            double anterior = dato;
            dato = 0;
            AgregarOperacion(anterior, dato, TipoOperacion.Limpiar);
        }

        // Método para agregar la operación al historial
        private void AgregarOperacion(double anterior, double nuevo, TipoOperacion operacion)
        {
            Operacion realizoOp = new Operacion(anterior, nuevo, operacion);

            if (Historial == null)
            {
                Historial = new List<Operacion>();
            }

            Historial.Add(realizoOp);
        }

        public class Operacion
        {
            private double resultadoAnterior;
            private double nuevoValor;
            private TipoOperacion operacion;

            public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
            public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
            public TipoOperacion OperacionRealizar { get => operacion; set => operacion = value; }

            public Operacion(double resulAnt, double resulNuevo, TipoOperacion operacion)
            {
                ResultadoAnterior = resulAnt;
                NuevoValor = resulNuevo;
                OperacionRealizar = operacion;
            }
        }
    }
}
