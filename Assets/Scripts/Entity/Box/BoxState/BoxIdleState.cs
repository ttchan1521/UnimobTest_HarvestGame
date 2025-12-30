using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIdleState : BoxState
{
    private BoxController _boxController;

    public BoxIdleState(BoxController boxController) : base(boxController)
    {
        _boxController = boxController;
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        
    }

    public override void OnClick()
    {
        var unlockView = _boxController.BoxEntity.GetConstructionUnlockView();

        unlockView.Setup(
            _boxController.BoxModel.plantIcon,
            _boxController.BoxModel.plantName,
            _boxController.BoxModel.cost,
            () => OnBuySuccess(unlockView)
        );

        unlockView.Show();
    }

    private void OnBuySuccess(ConstructionUnlockView unlockView)
    {
        unlockView.Hide();
        _boxController.SwitchToState(new BoxBuildingState(_boxController));
    }
}
