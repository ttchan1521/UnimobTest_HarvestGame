using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ConstructionModuleEntity _constructionModuleEntity;
    public DeliveryModuleEntity _deliveryModuleEntity;
    public MarketModuleEntity _marketModuleEntity;

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
        timer = new Timer();
        Initialize();
    }

    private void Initialize()
    {
        var constructionModule = new ConstructionModule(_constructionModuleEntity);
        constructionModule.Initialize();

        var deliveryModule = new DeliveryModule(_deliveryModuleEntity);
        deliveryModule.Initialize();

        var marketModule = new MarketModule(_marketModuleEntity);
        marketModule.Initialize();

        constructionModule.deliveryModule = deliveryModule;
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
