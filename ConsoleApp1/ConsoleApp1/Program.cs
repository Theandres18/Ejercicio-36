using System;
using System.Windows.Markup;

class program
{
    static void Main()
}

var lista = new ListaDoble<string>();
int opcion;
string valor;

do
{
    Console.WriteLine("\nMenu: ");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar Adelante");
    Console.WriteLine("3. Mostrar Atras");
    Console.WriteLine("4. Ordenar");
    Console.WriteLine("5. Moda");
    Console.WriteLine("6. Grafico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una");
    Console.WriteLine("9. Eliminar Todas");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese un valor: ");
            valor = Console.ReadLine();
            lista.Adicionar(valor);
            break;
        case 2:
            lista.MostrarAdelante();
            break;
        case 3:
            lista.MostrarAtras();
            break;
        case 4:
            lista.OrdenarAscendente();
            break;
        case 5:
            lista.MostrarModa();
            break;
        case 6:
            lista.MostrarGrafico();
            break;
        case 7:
            Console.Write("Buscar: ");
            valor = Console.ReadLine();
            Console.WriteLine(lista.Existe(valor) ? "Existe" : "No existe");
            break;
        case 8:
            Console.Write("Eliminar: ");
            valor = Console.ReadLine();
            lista.EliminarUna(valor);
            break;
        case 9:
            Console.Write("Eliminar todas: ");
            valor = Console.ReadLine();
            lista.EliminarTodas(valor);
            break;
    }

} while (opcion != 0);
    }
}