using UnityEngine;

namespace CardManagement
{
    public class InventoryN : MonoBehaviour
    {
        public static int SearchEmptyIndex(Card[] card_array)
        {
            bool card_set = false;
            for (int i = 0; i < card_array.Length; i++)
            {
                if (card_array[i] == null)
                {
                    card_set = true;
                    return i;
                }
            }
            if (card_set == false)
            {
                return card_array.Length + 1;
            }
            throw new System.InvalidProgramException("This line of code should not be reached, ERR: 001");
        }
    }
}