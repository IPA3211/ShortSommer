using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameSystem instance;
    ItemSystem itemSystem;

    [SerializeField] SommerCharacter defaultCharacter;
    [SerializeField] IController defaultController;

    public static GameSystem Instance => instance;
    public ItemSystem ItemSystem => itemSystem;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        itemSystem = new ItemSystem();
    }

    void Start()
    {
        defaultController = GetComponent<IController>();
        defaultCharacter.AttachController(defaultController);
    }
}
