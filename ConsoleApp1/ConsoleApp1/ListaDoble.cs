using System;
using System.Collections.Generic;

public class ListaDoble<T> where T : IComparable<T>
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

    public bool Existe(T valor)
    {
        var actual = cabeza;
        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Dato, valor))
                return true;
            actual = actual.Siguiente;
        }
        return false;
    }

    public void EliminarUna(T valor)
    {
        var actual = cabeza;
        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Dato, valor))
            {
                if (actual.Anterior != null)
                    actual.Anterior.Siguiente = actual.Siguiente;
                else
                    cabeza = actual.Siguiente;

                if (actual.Siguiente != null)
                    actual.Siguiente.Anterior = actual.Anterior;
                else
                    cola = actual.Anterior;

                break;
            }
            actual = actual.Siguiente;
        }
    }

    public void EliminarTodas(T valor)
    {
        var actual = cabeza;
        while (actual != null)
        {
            var siguiente = actual.Siguiente;
            if (EqualityComparer<T>.Default.Equals(actual.Dato, valor))
            {
                if (actual.Anterior != null)
                    actual.Anterior.Siguiente = actual.Siguiente;
                else
                    cabeza = actual.Siguiente;

                if (actual.Siguiente != null)
                    actual.Siguiente.Anterior = actual.Anterior;
                else
                    cola = actual.Anterior;
            }
            actual = siguiente;
        }
    }

    public void MostrarModa()
    {
        var frecuencia = new Dictionary<T, int>();
        var actual = cabeza;
        while (actual != null)
        {
            if (frecuencia.ContainsKey(actual.Dato))
                frecuencia[actual.Dato]++;
            else
                frecuencia[actual.Dato] = 1;
            actual = actual.Siguiente;
        }

        int maxFrecuencia = 0;
        foreach (var par in frecuencia)
        {
            if (par.Value > maxFrecuencia)
                maxFrecuencia = par.Value;
        }

        Console.Write("Moda(s): ");
        foreach (var par in frecuencia)
        {
            if (par.Value == maxFrecuencia)
                Console.Write($"{par.Key} ");
        }
        Console.WriteLine();
    }

    public void MostrarGrafico()
    {
        var frecuencia = new Dictionary<T, int>();
        var actual = cabeza;
        while (actual != null)
        {
            if (frecuencia.ContainsKey(actual.Dato))
                frecuencia[actual.Dato]++;
            else
                frecuencia[actual.Dato] = 1;
            actual = actual.Siguiente;
        }

        foreach (var par in frecuencia)
        {
            Console.Write($"{par.Key} ");
            for (int i = 0; i < par.Value; i++)
                Console.Write("*");
            Console.WriteLine();
        }
    }

    public void OrdenarAscendente()
    {
        if (cabeza == null || cabeza.Siguiente == null) return;

        for (var i = cabeza; i != null; i = i.Siguiente)
        {
            for (var j = i.Siguiente; j != null; j = j.Siguiente)
            {
                if (j.Dato.CompareTo(i.Dato) < 0)
                {
                    var temp = i.Dato;
                    i.Dato = j.Dato;
                    j.Dato = temp;
                }
            }
        }
    }

    public void OrdenarDescendente()
    {
        if (cabeza == null || cabeza.Siguiente == null) return;

        for (var i = cabeza; i != null; i = i.Siguiente)
        {
            for (var j = i.Siguiente; j != null; j = j.Siguiente)
            {
                if (j.Dato.CompareTo(i.Dato) > 0)
                {
                    var temp = i.Dato;
                    i.Dato = j.Dato;
                    j.Dato = temp;
                }
            }
        }
    }
}
