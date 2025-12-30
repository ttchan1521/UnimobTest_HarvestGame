using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBuildingState : BoxState
{
    private BoxController _boxController;
    private float _currentBuildTime;
    private BuildingView _buildingView;

    public BoxBuildingState(BoxController boxController) : base(boxController)
    {
        _boxController = boxController;
    }

    public override void Dispose()
    {
        GameManager.Instance.timer.TICK -= OnTick;
        _buildingView.Hide();
    }

    public override void Initialize()
    {
        _buildingView = _boxController.BoxEntity.GetBuildingView();
        _currentBuildTime = _boxController.BoxModel.buildingTime;
        _buildingView.Show();

        GameManager.Instance.timer.TICK += OnTick;
    }

    private void OnTick()
    {
        _currentBuildTime -= Time.deltaTime;
        if (_currentBuildTime <= 0)
        {
            _boxController.SwitchToState(new BoxPlantableState(_boxController));
            return;
        }

        _buildingView.UpdateView(
            _currentBuildTime / _boxController.BoxModel.buildingTime,
            _currentBuildTime
        );
    }

    public override void OnClick()
    {
        
    }
}
