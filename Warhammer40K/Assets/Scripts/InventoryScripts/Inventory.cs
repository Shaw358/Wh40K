using System.Collections.Generic;
using UnityEngine;

public class Inventory<T>
{
    List<T> item_list = new List<T>();

    public T GetItem(int index)
    {
        return item_list[index];
    }

    public List<T> GetItems()
    {
        return item_list;
    }

    public void AddItem(T item)
    {
        item_list.Add(item);
    }

    public void AddItems(List<T> items)
    {
        item_list.AddRange(items);
    }

    public void RemoveItem(T item)
    {
        item_list.Remove(item);
    }

    public void RemoveItems(List<T> to_remove)
    {
        for (int i = 0; i < to_remove.Count; i++)
        {
            int index = item_list.IndexOf(to_remove[i]);
            item_list.RemoveAt(index);
        }
    }
}