using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
	BoxCollider2D m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        float screenHeight = 2f * mainCamera.orthographicSize;
 		float screenWeigth = screenHeight * mainCamera.aspect;

        m_Collider = GetComponent<BoxCollider2D>();
 		m_Collider.size = new Vector2(screenWeigth, screenHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
    }
}
