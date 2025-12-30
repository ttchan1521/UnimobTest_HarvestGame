using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEntity : ClickItem
{
    [SerializeField] private Animator _animator;
    public Canvas canvas;

    private ConstructionModuleEntity _constructionModuleEntity;
    private BoxController _boxController;

    public void Init(ConstructionModuleEntity constructionModuleEntity, BoxController boxController)
    {
        _boxController = boxController;
        _constructionModuleEntity = constructionModuleEntity;
    }

    public void PlayAnim(string animationName)
    {
        _animator.Play(animationName);
    }

    public ConstructionUnlockView GetConstructionUnlockView()
    {
        if (_constructionModuleEntity == null)
            return null;
        
        var unlockView = _constructionModuleEntity.GetConstructionUnlockView();
        var canvas = unlockView.transform.parent.GetComponent<Canvas>();
        var canvasPos = UIExtension.GetPositionFromWorldPoint(transform.position, canvas);

        unlockView.SetParentAndPosition(canvas.transform, canvasPos + new Vector3(0, 200));
        return unlockView;
    }

    public BuildingView GetBuildingView()
    {
        if (_constructionModuleEntity == null)
            return null;
        
        var buildingView = 
            _constructionModuleEntity.GetBuildingView(canvas.gameObject, new Vector3(0, 100f, 0));

        return buildingView;
    }

    public override void OnClick()
    {
        _boxController.OnClick();
    }
}
