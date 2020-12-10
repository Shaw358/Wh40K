using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRebellion : MonoBehaviour
{
    private PlanetCollection planet_col = new PlanetCollection();
    [SerializeField] PopUpManager pop_man;
    [SerializeField] int rebellion_level = 1;

    public void Rebel()
    {
        int random = Random.Range(0, 5);

        if (true)
        {
            Planet spawn_planet = planet_col.GetRandomPlanet();

            string rebel_information = "";
            for(int i = 0; i < rebellion_level; i++)
            {
                foreach (Planet planet in spawn_planet.GetLane().GetAccessiblePlanets())
                {
                    rebel_information += planet.GetName();
                    planet.SetFaction(Factions.FACTION.ENEMY);
                }
            }
            rebel_information += "have Rebelled!";
            pop_man.ActivatePopup(rebel_information, "Good riddance...");
        }
    }
}