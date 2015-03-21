using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public GameObject test;

    public Transform back;
    public GameObject visual;
    public float cachedX;
    public float cachedY;
    public float cachedZ;

    public float minXValue;
    public float minZValue;
    public int currentHealth;
    public int maxHealth;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 1 ,0) + back.position;

        cachedX = visual.transform.localScale.x;
        cachedY = visual.transform.localScale.y;
        cachedZ = visual.transform.localScale.z;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 1, 0) + back.position;
        healthBar();
    }

    private void healthBar()
    {
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        float percent = ((float) currentHealth / (float) maxHealth);
        visual.transform.localScale = new Vector3(percent * cachedX, cachedY, cachedZ);

        if (currentHealth > maxHealth / 2) {
            visual.GetComponent<SpriteRenderer>().color = new Color32((byte)mapColor(currentHealth, maxHealth, true), 255, 0, 255);
        }
        else
        {
            visual.GetComponent<SpriteRenderer>().color = new Color32(255, (byte)mapColor(currentHealth, maxHealth, false), 0, 255);
        }
    }

    private float mapColor(float currentHealth, float maxHealth, bool half)
    {
        if (!half)
        {
            return (currentHealth / maxHealth) * 255;
        }
        return 255 - ((currentHealth / maxHealth) * 255);
    }

    public void changeHealth(int change)
    {
        GameObject.Find("Shout" + Random.Range(1, 4)).GetComponent<AudioSource>().Play();
        currentHealth += change;
    }
}
