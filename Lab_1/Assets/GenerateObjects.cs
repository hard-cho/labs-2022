using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCubes (string inputInfo)
    {
        var n = int.Parse(inputInfo);
        for (int i = 0; i < n; i++)
        {
            Instantiate(cube);
        }
    }
}
