using System;

// 입력이 있을 때 생길 수 있는 이벤트 종류
public struct InputEvent<T>
{
    public event Action<T> started;
    public event Action<T> performed;
    public event Action<T> canceled;

    public void OnStarted(T param)
    {
        started?.Invoke(param);
    }
    public void OnPerformed(T param)
    {
        performed?.Invoke(param);
    }
    public void OnCanceled(T param)
    {
        canceled?.Invoke(param);
    }
}