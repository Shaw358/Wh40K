using System.Collections.Generic;

public class Inventory<T>
{
    List<T> item_list = new List<T>();

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

    public void RemoveItems(int first_index, int last_index = 0)
    {
        if (last_index != 0)
        {
            item_list.RemoveRange(first_index, last_index);
        }
        else
        {
            item_list.RemoveAt(first_index);
        }
    }
}
