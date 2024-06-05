using System.Collections;

public interface ILifeCycler
{
    public void Init();

    public IEnumerator StartLifeCycle();
}
