using UnityEngine;

namespace CardManagement
{
    public class InventoryN : MonoBehaviour
    {
        public static int SearchEmptyIndex(Ship[] ship_array)
        {
            if (ship_array == null)
            {
                return ship_array.Length + 1;
            }
            else
            {
                bool card_set = false;
                for (int i = 0; i < ship_array.Length; i++)
                {
                    if (ship_array[i] == null)
                    {
                        card_set = true;
                        return i;
                    }
                }
                if (card_set == false)
                {
                    return ship_array.Length + 1;
                }
                throw new System.InvalidProgramException("This line of code should not be reachable");
            }
        }
    }
}