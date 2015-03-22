using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string Vertical = "DPad_YAxis_1";
    public string A_button = "A_1";
    public GameObject top;
    public GameObject bot;

    GameObject anim;

    int position = 0;

    bool started = false;

	// Use this for initialization
	void Start () {
        anim = GameObject.Find("Buttons");
	}
	
	// Update is called once per frame
	void Update () {
        if(started == false) {
            if (Input.GetAxis(Vertical) > 0 || Input.GetAxis(Vertical) < 0)
            { // up
                print("false");
                started = true;
                anim.GetComponent<Animator>().CrossFade("Play", 0f);
            }
            if (Input.GetButtonDown(A_button)) {
                if (position == 0) {
                    Application.LoadLevel("Tutorial_level");
                }
                else {
                    Application.Quit();
                }
            }

        }
        else {
            if (Input.GetAxis(Vertical) > 0 || Input.GetAxis(Vertical) < 0)
            { // up
                print("increment: " + position);
                StartCoroutine(animate());
                if (position == 0)
                {
                    anim.GetComponent<Animator>().CrossFade("Play", 0f);
                }
                else if (position == 1)
                {
                    anim.GetComponent<Animator>().CrossFade("Exit", 0f);
                }
            }
            if (Input.GetButtonDown(A_button))
            {
                if (position == 0)
                {
                    Application.LoadLevel("Tutorial_level");
                }
                else
                {
                    Application.Quit();
                }
            }
        }
	}

    void increment()
    {
        ++position;
        if (position > 1)
        {
            position = 0;
        }
    }

    IEnumerator animate()
    {
        increment();

        if (position == 0)
        {
            anim.GetComponent<Animator>().CrossFade("Play", 0f);
        }
        else if (position == 1)
        {
            anim.GetComponent<Animator>().CrossFade("Exit", 0f);
        }
        yield return new WaitForSeconds(0.1f);

    }
}
