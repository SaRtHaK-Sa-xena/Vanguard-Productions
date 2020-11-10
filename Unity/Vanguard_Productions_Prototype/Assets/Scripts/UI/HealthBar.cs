using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // player Obj
    [SerializeField] private GameObject playerObj;

    // health Image
    [SerializeField] private Image healthImage;

    // updating speed of health decrease
    [SerializeField] private float updateSpeedSeconds = 0.2f;

    private void Awake()
    {
        // pass in event
        playerObj.GetComponent<HealthScript>().OnHealthPctChanged += HandleHealthChanged;
    }

    void HandleHealthChanged(float pct)
    {
        // change to percentage
        // pass in float value
        StartCoroutine(ChangeToPct(pct));
    }


    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = healthImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            healthImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        healthImage.fillAmount = pct;
        if(healthImage.fillAmount <= 0)
        {
            healthImage.fillAmount = 100f;
        }
    }
}
