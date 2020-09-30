using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Sword Item")]
public class SwordItem : Item
{

    /*
     * The sword item class is a scriptable object. This class is a
     * class constructor. Items just hold 2 values, ID and sprite.
     * Using the CreateAssetMenu tag above the class allows you to
     * create files that can be dragged into the ItemManager.
     */

    [SerializeField] private int damage;
    public int Damage { get { return damage; } }
}
