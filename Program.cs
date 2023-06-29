using EspacioToDo;

List<ToDo> TareasPendientes = new List<ToDo>();
List<ToDo> TareasRealizadas = new List<ToDo>();

Random random = new Random();
int cant = random.Next(1, 5);

for (int i = 0; i < cant; i++)
{
    Console.WriteLine($"Descripcion de tarea {i + 1}: ");
    string? desc = Console.ReadLine();
    int duracion = random.Next(10, 101);

    ToDo nuevaTarea = new ToDo(i, desc, duracion);
    TareasPendientes.Add(nuevaTarea);
}

void mostrarLista(List<ToDo> lista)
{
    foreach (ToDo tarea in lista)
    {
        Console.WriteLine("----------");
        Console.WriteLine("TareaID: " + tarea.TareaID);
        Console.WriteLine("Descripcion: " + tarea.Descripcion);
        Console.WriteLine("Duracion: " + tarea.Duracion);
    }
}
int horasTotales(List<ToDo> lista)
{
    int total = 0;
    foreach (ToDo tarea in lista)
    {
        total += tarea.Duracion;
    }
    return total;
}

int aux;
do
{
    Console.WriteLine("Elija una opcion:\n0-Salir 1-Mover tarea a realizada 2-Buscar tarea por desc.");
    int.TryParse(Console.ReadLine(), out aux);
    if (aux == 1)
    {
        int idBuscado;
        mostrarLista(TareasPendientes);
        Console.WriteLine("ID de tarea a mover:");
        int.TryParse(Console.ReadLine(), out idBuscado);

        foreach (ToDo tarea in TareasPendientes)
        {
            if (idBuscado == tarea.TareaID)
            {
                TareasRealizadas.Add(tarea);
                TareasPendientes.Remove(tarea);
                Console.WriteLine("Tarea movida correctamente");
                break;
            }
        }
    }
    else if (aux == 2)
    {
        Console.WriteLine("Ingrese la descripcion a buscar:");
        string? desc = Console.ReadLine();
        bool encontrado = false;

        foreach (ToDo tarea in TareasPendientes)
        {
            if (desc == tarea.Descripcion)
            {
                Console.WriteLine("-----Tarea Pendiente-----");
                Console.WriteLine("TareaID: " + tarea.TareaID);
                Console.WriteLine("Descripcion: " + tarea.Descripcion);
                Console.WriteLine("Duracion: " + tarea.Duracion);
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            foreach (ToDo tarea in TareasRealizadas)
            {
                if (desc == tarea.Descripcion)
                {
                    Console.WriteLine("-----Tarea Realizada-----");
                    Console.WriteLine("TareaID: " + tarea.TareaID);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                    break;
                }
            }
        }
        if (!encontrado) Console.WriteLine("No se encontro la tarea...");
    }
} while (aux == 1 || aux == 2);

int hsTotales = horasTotales(TareasRealizadas);
string ruta = "horasTrabajadas.txt";
StreamWriter archivo = new StreamWriter(ruta, true);
archivo.WriteLine("Horas trabajadas: " + hsTotales);
archivo.Close();