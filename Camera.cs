using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject target;
    public GameObject canvas;

    public static Camera instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }
}
