using Game.Core;

public abstract class BoxState : State
{
    public BoxState(BoxController boxController)
    {
        
    }

    public abstract void OnClick();
}
