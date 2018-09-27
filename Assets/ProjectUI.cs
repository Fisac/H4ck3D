using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectUI : MonoBehaviour {

    public GameObject armUI;
    public GameObject gameObject1;          // Reference to the first GameObject
    public GameObject gameObject2;          // Reference to the second GameObject
    private LineRenderer line;

  
    public Material material1;

    // Use this for initialization
    void Start ()
    {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        // Set the width of the Line Renderer
        line.startWidth = 0.01f;
        line.material = material1;


    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if (armUI.activeSelf == true)
        {
            // Check if the GameObjects are not null
            if (gameObject1 != null && gameObject2 != null)
            {
                // Update position of the two vertex of the Line Renderer
                line.SetPosition(0, gameObject1.transform.position);
                line.SetPosition(1, gameObject2.transform.position);
            }
        }
    }
}

