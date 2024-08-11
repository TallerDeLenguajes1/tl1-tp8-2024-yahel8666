namespace tareas;

public enum Estados
{
    pendiente,
    realizada
}

public class Tarea
{

    //campos
    int duracion;
    string descripcion;
    int id;
    Estados estado;

    public global::System.Int32 Duracion { get => duracion; set => duracion = value; }
    public global::System.String Descripcion { get => descripcion; set => descripcion = value; }
    public global::System.Int32 Id { get => id; set => id = value; }
    internal Estados Estado { get => estado; set => estado = value; }

    //constructor con parametros 
    public Tarea(int duracion, int id, string desc, Estados estado)
    {
        this.duracion = duracion;
        this.id = id;
        descripcion = desc;
        this.estado = estado;
    }
}

class GestorDeTareas
{
    public List<Tarea> crearNTareas(int n)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        int id = 1000;
        var semilla = Environment.TickCount;
        var random = new Random(semilla);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nIngrese la descripcion de la tarea {i + 1}");
            string descripcion = Console.ReadLine();
            int duracion = random.Next(10, 101);

            Tarea tarea = new Tarea(duracion, id, descripcion, Estados.pendiente);

            listaTareas.Add(tarea);

            id++;
        }
        return listaTareas;
    }

    public void moverTareasARealizadasId(List<Tarea> pendientes, List<Tarea> realizadas, int id)
    {
        int i = 0;

        while (i < pendientes.Count && pendientes[i].Id != id) i++;
        if (pendientes[i].Id == id)
        {
            Tarea tareaATransferir = pendientes[i];

            tareaATransferir.Estado = Estados.realizada;

            realizadas.Add(tareaATransferir);
            pendientes.Remove(tareaATransferir);

        }
        else
        {
            Console.WriteLine("\nNo existe una tarea con ese ID");
        }
    }

    public Tarea BuscarTareaPorDescripcion(List<Tarea> Pendientes, string descripcion)
    {
        Tarea TareaBuscada = null;
        foreach (Tarea tarea in Pendientes)
        {
            if (tarea.Descripcion == descripcion)
            {
                TareaBuscada = tarea;
            }
        }
        return TareaBuscada;
    }

}
