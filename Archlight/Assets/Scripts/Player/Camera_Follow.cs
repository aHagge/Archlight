using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Camera_Follow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed;
    
    IEnumerator findplayer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (target == null)
        {
            target = GameObject.Find("Player").transform;
            StartCoroutine(findplayer());
        }
        

    }

    private void Start()
    {       
        gameObject.transform.position = new Vector3 (Game_manager.velocity.x, Game_manager.velocity.y, Game_manager.velocity.z - 200);
        StartCoroutine(findplayer());
    }
    void FixedUpdate()
    {
        if (target == null)
        {
            StartCoroutine(findplayer());
        }

        if (target != null)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}

