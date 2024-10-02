using Polly;

namespace RetryPatternCSharp;

public class RetryUsingPolly
{
    public Dictionary<int, string> LogMessages = [];
    private int totalRetries = 0;
    private Policy _policy;

    public RetryUsingPolly(int maxRetries, int delayInSeconds)
    {
        _policy = Policy
            .Handle<Exception>()
            .WaitAndRetry(
                retryCount: maxRetries,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(delayInSeconds),
                onRetry: (exception, timespan, retryCount, context) => {
                    totalRetries++;
                LogMessages[retryCount] = 
                    $"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.";
            });
    }

    public void Execute()
    {
        try
        {
            _policy.Execute(unreliableServiceCall);
        }
        catch (Exception Ex)
        {
            LogMessages[totalRetries] = $"Operation failed after {totalRetries} tries, Ex: {Ex.Message}";
        }
    }

    private void unreliableServiceCall()
    {
        Random rnd = new Random();

        if (rnd.Next(10) < 5)
            throw new Exception("Service unavailable!");
    }
}
