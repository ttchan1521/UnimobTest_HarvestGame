using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private ConstructionModuleEntity _constructionModuleEntity;

    public Timer timer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Initialize();

        timer = new Timer();
    }

    private void Initialize()
    {
        var constructionModule = new ConstructionModule(_constructionModuleEntity);
        constructionModule.Initialize();
    }

    private void Update()
    {
        timer.Update();
    }

    private void LateUpdate()
    {
        timer.LateUpdate();
    }


    private void FixedUpdate()
    {
        timer.FixedUpdate();
    }
}
