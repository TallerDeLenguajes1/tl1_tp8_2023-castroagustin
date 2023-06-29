Console.WriteLine("Ingrese una ruta:");
string? ruta = Console.ReadLine();

if (Directory.Exists(ruta))
{
    string[] archivos = Directory.GetFiles(ruta);

    Console.WriteLine("Listado de archivos:");
    foreach (string archivo in archivos)
    {
        Console.WriteLine(archivo);
    }

    StreamWriter index = new StreamWriter("index.csv");
    for (int i = 0; i < archivos.Length; i++)
    {
        string[] partes = archivos[i].Split(@"\").Last().Split(".");
        index.WriteLine($"{i + 1}, {partes[0]}, {partes[1]}");
    }
    index.Close();
}