
public interface Module
{
    public void Initialize();

    public void Dispose();
}


public abstract class Module<T> : Module
{
    protected readonly T _view;

    protected Module(T view)
    {
        _view = view;
    }

    public abstract void Initialize();
    public abstract void Dispose();
}
