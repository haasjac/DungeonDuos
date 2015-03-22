using UnityEngine;
using System.Collections;

public class noDestroy : MonoBehaviour {
	// Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
