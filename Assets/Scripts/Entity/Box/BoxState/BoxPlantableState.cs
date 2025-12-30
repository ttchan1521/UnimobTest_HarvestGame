using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlantableState : BoxState
{
    private BoxController _boxController;

    public BoxPlantableState(BoxController boxController) : base(boxController)
    {
        _boxController = boxController;
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        _boxController.BoxModel.plantable = true;
        _boxController.SetChanged();
    }

    public override void OnClick()
    {
        
    }
}
