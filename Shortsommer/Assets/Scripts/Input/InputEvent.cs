using System;

// �Է��� ���� �� ���� �� �ִ� �̺�Ʈ ����
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