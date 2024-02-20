using Castle.DynamicProxy;

public class MethodInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.Clear();
        invocation.Proceed();
    }
}