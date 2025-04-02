using UnityEngine;
using System.Collections.Generic;
using TMPro;

public enum DifficultyState { EASY, NORMAL, HARD }

public class DifficultyManager : MonoBehaviour
{
    public PlayerMetrics playerMetrics;
    public DifficultyState currentDifficulty = DifficultyState.NORMAL;
    public List<EnemyStats> enemies = new List<EnemyStats>();
    public float checkInterval = 30f;
    private float timer;
    public TMP_Text difficultyText;
    public TMP_Text moveSpeed;
    public TMP_Text damage;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= checkInterval)
        {
            EvaluateDifficulty();
            timer = 0;
        }


        //Inicializa varaibles de la UI
        difficultyText.text = "Dificultad: " + currentDifficulty.ToString();
        moveSpeed.text = enemies[0].moveSpeed.ToString();
        damage.text = enemies[0].damage.ToString();
    }

    void EvaluateDifficulty()
    {
        Debug.Log("EvaluateDifficulty");
        Debug.Log(playerMetrics.hitsTaken + playerMetrics.deathsInRow);

        // Ajusta la dificultad de acuerdo a parámetros de player metrics
        if (playerMetrics.hitsTaken > 5) {
            currentDifficulty = DifficultyState.EASY;
        }
        else if (playerMetrics.hitsTaken <= 5 && playerMetrics.hitsTaken >= 2)
        {
            currentDifficulty = DifficultyState.NORMAL;
        }
        else {
            currentDifficulty = DifficultyState.HARD;
        }

        //Fuerza a EASY cuando hemos muerto mas de una vez
        if (playerMetrics.deathsInRow > 1)
        {
            currentDifficulty = DifficultyState.EASY;
        }


        ApplyDifficulty();
    }

    void ApplyDifficulty()
    {
        foreach (EnemyStats enemy in enemies)
        {
            switch (currentDifficulty)
            {
                case DifficultyState.EASY:
                    enemy.health = 50f;
                    enemy.damage = 5f;
                    enemy.moveSpeed = 1f;
                    break;
                case DifficultyState.NORMAL:
                    enemy.health = 100f;
                    enemy.damage = 10f;
                    enemy.moveSpeed = 3f;
                    break;
                case DifficultyState.HARD:
                    enemy.health = 150f;
                    enemy.damage = 20f;
                    enemy.moveSpeed = 5f;
                    break;
            }

            //Apply difficulty changes to the enemies
            enemy.Apply();
        }

        Debug.Log("Dificultad ajustada a: "+ currentDifficulty);
        moveSpeed.text = enemies[0].moveSpeed.ToString();
        damage.text = enemies[0].damage.ToString();
    }
}
