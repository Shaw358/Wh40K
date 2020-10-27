using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    int game_speed = 1;
    public void UpdateGameSpeed(int speed)
    {
        game_speed = speed;
    }

    public int GetGameSpeed()
    {
        return game_speed;
    }
}
