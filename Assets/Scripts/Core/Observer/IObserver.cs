namespace Core
{
	public interface IObserver<T>
	{
		void OnObjectChanged(T observable);
	}
}