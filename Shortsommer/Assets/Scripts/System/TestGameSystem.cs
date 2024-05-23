using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameSystem : MonoBehaviour
{
    [SerializeField] HumanCharacter defaultCharacter;
    [SerializeField] PcController defaultController;
    // Start is called before the first frame update
    void Start()
    {
        defaultCharacter.AttachController(defaultController);
    }
}
