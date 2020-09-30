using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{

    /*
     * The item class is a scriptable object. This class is a
     * class constructor. Items just hold 2 values, ID and sprite.
     * Using the CreateAssetMenu tag above the class allows you to
     * create files that can be dragged into the ItemManager.
     */

    [SerializeField] private int id;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string description;
    [SerializeField] private string name;
    [SerializeField] private bool stackable;

    public Sprite Sprite { get { return sprite; } }
    public int ID { get { return id; } }
    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public bool Stackable { get { return stackable; } }
}
