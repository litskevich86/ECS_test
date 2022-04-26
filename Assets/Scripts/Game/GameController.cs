using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private LogHealthSystem _logHealthSystem;
    private CreatePlayerSystem _createPlayerSystem;
    
    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        _logHealthSystem = new LogHealthSystem(contexts);
        _createPlayerSystem = new CreatePlayerSystem(contexts);
        
        _createPlayerSystem.Initialize();
    }

    private void Update()
    {
        _logHealthSystem.Execute();
    }
}
