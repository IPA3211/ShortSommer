using UnityEngine;

public class TestGameSystem : MonoBehaviour
{
    [SerializeField] SommerCharacter defaultCharacter;
    [SerializeField] PcController defaultController;
    // Start is called before the first frame update
    void Start()
    {
        defaultCharacter.AttachController(defaultController);
    }
}
