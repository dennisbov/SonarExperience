using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "sonarSound", menuName ="sonarSound")]
public class EmmitingSoundInfo : ScriptableObject
{
    public int RaysNumber;
    public float RaysLenth;
    public float DistantModifier;
    public float ShowcaseDuration;
    public bool IsPiercingRays = false;
}

[System.Serializable]
public class EmmitingSoundAction : UnityEvent<EmmitingSoundInfo> { }
