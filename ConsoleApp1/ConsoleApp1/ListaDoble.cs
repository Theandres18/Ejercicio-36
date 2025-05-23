public class Nodo<T>
{
    public T Dato { get; set; }
    public Nodo<T> Siguiente { get; set; }
    public Nodo<T> Anterior { get; set; }

    public Nodo(T valor)
    {
        Dato = valor;
        Siguiente = null;
        Anterior = null;
    }
}

public class ListaDoble<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> cola;

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
    }

    public void Adicionar(T valor)
    {
        var nuevo = new Nodo<T>(valor);
        if (cabeza == null)
        {
            cabeza = cola = nuevo;
        }
        else
        {
            cola.Siguiente = nuevo;
            nuevo.Anterior = cola;
            cola = nuevo;
        }
    }

    public void MostrarAdelante()
    {
        var actual = cabeza;
        while (actual != null)
        {
            Console.Write($"{actual.Dato} <-> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    public void MostrarAtras()
    {
        var actual = cola;
        while (actual != null)
        {
            Console.Write($"{actual.Dato} <-> ");
            actual = actual.Anterior;
        }
        Console.WriteLine("null");
    }
}
bool existe(T valor)
{
    Nodo<T>* actual = cabeza;
    while (actual)
    {
        if (actual->dato == valor) return true;
        actual = actual->siguiente;
    }
    return false;
}

void eliminarUna(T valor)
{
    Nodo<T>* actual = cabeza;
    while (actual)
    {
        if (actual->dato == valor)
        {
            if (actual->anterior) actual->anterior->siguiente = actual->siguiente;
            else cabeza = actual->siguiente;

            if (actual->siguiente) actual->siguiente->anterior = actual->anterior;
            else cola = actual->anterior;

            delete actual;
            break;
        }
        actual = actual->siguiente;
    }
}

void eliminarTodas(Task valor)
{
    Nodo<T>* actual = cabeza;
    while (actual)
    {
        Nodo<T>* siguiente = actual->siguiente;

        if (actual->dato == valor)
        {
            if (actual->anterior) actual->anterior->siguiente = actual->siguiente;
            else cabeza - actual->siguiente;

            if (actual->siguiente) actual->siguiente->anterior - actual->anterior;
            else cola - actual->anterior;


            delete actual;

        }
        else
        {
            actual - siguiente;
        }
    }
}

void mostrarModa()
{
    map<T, int> frecuencia;
    Nodo<T>* actual = cabeza;
    while (actual)
    {
        frecuencia[actual->dato]++;
        actual = actual->siguiente;
    }

    int maxFrecuencia = 0;
    for (auto & par : frecuencia) {
            if (par.second > maxFrecuencia)
                maxFrecuencia = par.second;
        }

        cout << "Moda(s): ";
for (auto & par : frecuencia)
{
    if (par.second == maxFrecuencia)
        cout << par.first << " ";
}
cout << endl;
    }

    void mostrarGrafico()
{
    map<T, int> frecuencia;
    Nodo<T>* actual = cabeza;
    while (actual)
    {
        frecuencia[actual->dato]++;
        actual = actual->siguiente;
    }

    for (auto & par : frecuencia) {
            cout << par.first << " ";
for (int i = 0; i < par.second; i++)
{
    cout << "*";
}
cout << endl;
        }
    }

    void ordenarAscendente()
{
    if (!cabeza || !cabeza->siguiente) return;

    for (Nodo<T>* i = cabeza; i != nullptr; i = i->siguiente)
    {
        for (Nodo<T>* j = i->siguiente; j != nullptr; j = j->siguiente)
        {
            if (j->dato < i->dato)
            {
                swap(i->dato, j->dato);
            }
        }
    }
}

void ordenarDescendente()
{
    if (!cabeza || !cabeza->siguiente) return;

    for (Nodo<T>* i = cabeza; i != nullptr; i = i->siguiente)
    {
        for (Nodo<T>* j = i->siguiente; j != nullptr; j = j->siguiente)
        {
            if (j->dato > i->dato)
            {
                swap(i->dato, j->dato);
            }
        }
    }
}
}