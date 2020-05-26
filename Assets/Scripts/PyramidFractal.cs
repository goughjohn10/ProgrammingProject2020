using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidFractal : MonoBehaviour
{
    public Mesh mesh;

    public Material material;

    public int maxDepth;

    private int depth;

    public float newScale;

    public GameObject topMount;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            new GameObject("PyramidChild").AddComponent<PyramidFractal>().Initialize(this, Vector3.up, Quaternion.identity);
            new GameObject("PyramidChild").AddComponent<PyramidFractal>().Initialize(this, Vector3.right, Quaternion.Euler(0,0,0));
            new GameObject("PyramidChild").AddComponent<PyramidFractal>().Initialize(this, Vector3.left, Quaternion.Euler(0,0,0));
            new GameObject("PyramidChild").AddComponent<PyramidFractal>().Initialize(this, Vector3.forward, Quaternion.Euler(0,0,0));
            new GameObject("PyramidChild").AddComponent<PyramidFractal>().Initialize(this, Vector3.back, Quaternion.Euler(-0,0,0));
        }
       
    }

    private void Initialize(PyramidFractal parent, Vector3 direction, Quaternion orientation)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        newScale = parent.newScale;
        transform.parent = parent.transform;
         //move the child and give a new scale 
        transform.localPosition = direction * (.5f + .5f * newScale);
        transform.localRotation = orientation;
        transform.localScale = Vector3.one * newScale;
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.AddComponent<BoxCollider>();
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        this.gameObject.layer = (8); //layer 8 is the ground
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
