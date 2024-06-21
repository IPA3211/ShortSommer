using UnityEngine;

public class TestGameSystem : MonoBehaviour
{
    [SerializeField] SommerCharacter defaultCharacter;
    [SerializeField] IController defaultController;
    // Start is called before the first frame update
    void Start()
    {
        defaultController = GetComponent<IController>();
        defaultCharacter.AttachController(defaultController);
    }
}
