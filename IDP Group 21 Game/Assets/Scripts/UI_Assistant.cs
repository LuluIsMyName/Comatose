using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Assistant : MonoBehaviour
{
    
    [SerializeField] private TextWriter textWriter;
    private TextMeshProUGUI textMesh;

    void Awake() {
        textMesh = GetComponent<TextMeshProUGUI> ();
        Application.targetFrameRate = 60;
    }

    void Start() {
        textMesh.text = "Hello World!";
        textWriter.AddWriter (textMesh, "Hi this is Mr. Buzzy Bee speaking with you today. We've been trying to reach you about your car's extended warranty. ", .05f, true);
    }
    
}
