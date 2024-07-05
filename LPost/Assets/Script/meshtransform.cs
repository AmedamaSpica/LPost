using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshtransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            Vector3[] vertices = meshFilter.mesh.vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].y > 0)
                {
                    vertices[i] += new Vector3(0.3f, 0.3f, 0);
                }
            }
            meshFilter.mesh.vertices = vertices;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
