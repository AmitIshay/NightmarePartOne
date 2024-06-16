using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] Text hellText;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    int hits = 0;
    void Start () {
        hellText.color = Color.white;
    }
    void Update () {
    UpdateTimerDisplay();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Hit") 
        {
            hits++;
            Debug.Log("many times: " + hits);
            successParticles.Play();
            crashParticles.Play();
            LoadSceneAndKeepValue();

        }
    }

        private void UpdateTimerDisplay()
    {
        if (hellText != null)
        {
            hellText.text = string.Format("Hits: {0}", hits);
            LoadSceneAndKeepValue();
        }
    }
    public void LoadSceneAndKeepValue()
    {
        string dataToKeep = hellText.text;
        StaticData.valueToKeep = dataToKeep;
        Debug.Log("many times: " + dataToKeep);
        Debug.Log("many times: " + StaticData.valueToKeep);
        //SceneManager.LoadScene(2);
    }
}
