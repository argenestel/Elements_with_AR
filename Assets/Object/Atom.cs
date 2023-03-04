using UnityEngine;

[CreateAssetMenu(fileName = "Atoms", menuName = "New Atom")]
public class Atom : ScriptableObject
{
    public int AtomicNumber;
    public string ElementName;
    public string ElementSymbol;

}
