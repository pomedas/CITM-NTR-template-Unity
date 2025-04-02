using UnityEngine;
public class PlayerMetrics : MonoBehaviour
{
    public int deathsInRow = 0;
    public int hitsTaken = 0;

    public void ResetCombatStats()
    {
        hitsTaken = 0;
    }
}
