using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public TMPro.TextMeshProUGUI hitsTakenTxt;
    public TMPro.TextMeshProUGUI deathsInRow;

    private PlayerMetrics playerMetrics;

    void Start()
    {
        currentHealth = maxHealth;
        playerMetrics = GetComponent<PlayerMetrics>();

        hitsTakenTxt.text = playerMetrics.hitsTaken.ToString();
        deathsInRow.text = playerMetrics.deathsInRow.ToString();
    }

    public void TakeDamage(float amount)
    {
        // Increments the hits taken by the player
        playerMetrics.hitsTaken++;
        hitsTakenTxt.text = playerMetrics.hitsTaken.ToString();

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerMetrics.deathsInRow++;
        deathsInRow.text = playerMetrics.deathsInRow.ToString();

        playerMetrics.ResetCombatStats();
        hitsTakenTxt.text = playerMetrics.hitsTaken.ToString();

        currentHealth = maxHealth;

        //Reset to initial position. Hay que desactivar el character controller para mover el player
        var controller = GetComponent<CharacterController>();
        if (controller != null) controller.enabled = false;
        transform.position = Vector3.zero;
        if (controller != null) controller.enabled = true;

        Debug.Log("¡El jugador ha muerto!");
    }
}
