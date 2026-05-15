using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealthBar : MonoBehaviour
{
    private Image fillImage;
    private TextMeshProUGUI healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay(float currentHealth, float maxHealth)
    {
        if (maxHealth <= 0) return;

        float fillPercentage = currentHealth / maxHealth;

        fillImage.fillAmount = Mathf.Clamp01(fillPercentage);

        healthText.text = $"{Mathf.Max(0, currentHealth)} / {maxHealth}";
    }
}
