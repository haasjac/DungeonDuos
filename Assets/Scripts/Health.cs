using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public RectTransform healthTransform;
    public int player;
    public float cachedY;
    public float minXValue;
    public float maxXValue;
    private int currentHealth;
    public int maxHealth;
    public Text healthtext;
    public Image visualHealth;

	// Use this for initialization
	void Start () {
        cachedY = healthTransform.position.y;
        if (player == 2) {
            maxXValue = healthTransform.position.x;
            minXValue = healthTransform.position.x + healthTransform.rect.width;
            Debug.Log(minXValue);
            Debug.Log(maxXValue);
        }
        else {
            maxXValue = healthTransform.position.x;
            minXValue = healthTransform.position.x - healthTransform.rect.width;
        }
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar();
    }

    private void healthBar()
    {
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        healthtext.text = "Health: " + currentHealth;
        float currentXValue = mapValues(currentHealth, maxHealth, minXValue, maxXValue);
        healthTransform.position = new Vector3(currentXValue, cachedY);

        if (currentHealth > maxHealth / 2) {
            visualHealth.color = new Color32((byte)mapColor(currentHealth, maxHealth, true), 255, 0, 255);
        }
        else {
            visualHealth.color = new Color32(255, (byte)mapColor(currentHealth, maxHealth, false), 0, 255);
        }
    }

    private float mapValues(float currentHealth, float maxHealth, float outMin, float outMax)
    {
        if (player == 2) {
            return outMin - ((currentHealth / maxHealth) * (outMin - outMax));
        }
        return (currentHealth / maxHealth) * (outMax + Mathf.Abs(outMin)) + outMin;
    }

    private float mapColor(float currentHealth, float maxHealth, bool half)
    {
        if (!half) {
            return (currentHealth / maxHealth) * 255;
        }
        return 255 - ((currentHealth / maxHealth) * 255);
    }

    public void changeHealth(int change) {
        currentHealth += change;
    }
}
