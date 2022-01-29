using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum State {
        PLAYER_TURN,
        ENEMY_TURN
    };

    public GameObject m_playerPrefab, m_enemyPrefab;
    public Transform m_playerSpawnPos, m_enemySpawnPos;
    public string[] m_wordPool;
    public Unit m_playerUnit, m_enemyUnit;
    public State m_state;

    float m_delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InitBattle();
    }

    void InitBattle() {
        // Spawn player and enemy
        Debug.Log("Starting Battle");
        GameObject player = Instantiate(m_playerPrefab, m_playerSpawnPos.position, m_playerSpawnPos.rotation);
        m_playerUnit = player.GetComponent<Unit>();

        GameObject enemy = Instantiate(m_enemyPrefab, m_enemySpawnPos.position, m_enemySpawnPos.rotation);
        m_enemyUnit = enemy.GetComponent<Unit>();

        m_playerUnit.Init();
        m_enemyUnit.Init();

        //StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn() {
        // Wait for player input
        while (!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)) {
            yield return null;
        }

        // TODO: Replace with typing interface
        /*string word = m_wordPool[Random.Range(0, m_wordPool.Length)];
        Debug.Log("Prompt word: " + word);
        TypeManager.ins.SetTargetWord(word);

        TypeManager.ins.StartTyping();

        while (TypeManager.ins.IsTyping()) {
            yield return null;
        }*/

        Debug.Log("Player Attack");
        
        // For now, press any key to attack for PoC
        yield return new WaitForSeconds(m_delay);
        bool kill = m_playerUnit.Attack(m_enemyUnit);

        if (kill) {
            EndBattle(true);
        } else {
            StartCoroutine(EnemyTurn());
        } 
    }

    IEnumerator EnemyTurn() {
        // Wait for enemy
        yield return new WaitForSeconds(m_delay);

        // Attack player
        bool kill = m_enemyUnit.Attack(m_playerUnit);

        if (kill) {
            EndBattle(false);
        } else {
            StartCoroutine(PlayerTurn());
        } 
    }

    void EndBattle(bool win) {
        if (win) {
            // Show victory
            Debug.Log("Player win");
        } else {
            // Show defeat
            Debug.Log("Player defeat");
        }
        
        // End Scene here
        StartCoroutine(WaitForEscape());
    }

    IEnumerator WaitForEscape() {
        while (!Input.GetKeyDown(KeyCode.Escape)) {
            yield return null;
        }

        Application.Quit();
    }

    
}
