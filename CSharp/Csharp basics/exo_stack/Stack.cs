using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_stack;

public class Stack<T>
{
    public T[] Elements { get; set; } = [];

    public void stack(T element)
    {
        Elements.Append(element);
    }

    public void unstack()
    {
        Elements = Elements.Take(Elements.Length - 1).ToArray();
    }

    public void remove(T element)
    {
       Elements = Elements.Where(e => !e.Equals(element)).ToArray();
    }
}
