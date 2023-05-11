using UnityEngine;

// Cette ligne nous permet de pouvoir appeler cette fonction dans d'autre endroit
[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}
