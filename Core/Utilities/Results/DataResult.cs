namespace Core.Utilities.Results;

public class DataResult<T> :Result,IDataResult<T>
{
    public DataResult(T data,bool success, string message) : base(success, message)
    {
        this.Data = data;
    }

    public DataResult(T data ,bool succes) : base(succes)
    {
        this.Data = data;
    }

    public T Data { get; }
}

// success data result
public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message) : base(data, true, message)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }
}

// fail data result

public class FailDataResult<T> : DataResult<T>
{
    public FailDataResult(T data, string message) : base(data, false, message)
    {
    }

    public FailDataResult(T data) : base(data, false)
    {
    }
}