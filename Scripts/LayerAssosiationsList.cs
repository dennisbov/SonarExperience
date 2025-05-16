using UnityEngine;

[CreateAssetMenu(fileName = "LayerToColor", menuName ="Associations")]
public class LayerAssosiationsList : ScriptableObject
{
    public LayerToColour Default;
    public LayerToColour[] list;
}
