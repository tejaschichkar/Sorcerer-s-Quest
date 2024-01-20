using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int PHealth;
    public Text Health;
    public GameObject Door1;
    public SceneController sceneTake;
    public bool domainAffect;

    void Start()
    {
        
    }

    void Update()
    {
        Health.text = "HP: " + PHealth;
        if (PHealth <= 0)
        {
            sceneTake.Invoke("ReloadFirstScene", 1f);
        }
    }

    public IEnumerator DecreaseHealthOverTime()
    {
        while ( domainAffect == true)
        {
            yield return new WaitForSeconds(4f); // Wait for 5 seconds
            PHealth -= 3;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == Door1)
        {
            domainAffect = true;
            StartCoroutine(DecreaseHealthOverTime());
        }
    }
}
