using Castle.DynamicProxy;

namespace GuessGame2;

public class MethodInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.Clear();
        invocation.Proceed();
    }
}