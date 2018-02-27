using UnityEngine;

public class DeveloperNote : MonoBehaviour
{
#if UNITY_EDITOR
    [TextAreaAttribute(5, 3000)]
    public string PlayerMechanics;
#endif
}
