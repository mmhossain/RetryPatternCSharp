namespace RetryPatternCSharp;

public class SimpleRetryPattern
{
    // This is to simulate logging, which it helps with debug and test.
    public Dictionary<int, string> LogMessages = [];

    public void Execute()
    {
        executeWithRetry(unreliableServiceCall, 3, 5);
    }

    private void executeWithRetry(Action operation, int maxRetries, int delayInSeconds)
    {
        int retryCount = 0;

        while (retryCount < maxRetries) // retry a limited number of times
        {
            try
            {
                operation?.Invoke();
                return;
            }
            catch (Exception ex)
            {
                retryCount++;
                LogMessages[retryCount] = $"Attempt {retryCount} failed with message: {ex.Message}";

                Thread.Sleep(delayInSeconds * 1000);    // wait between retries
            }
        }

        LogMessages[maxRetries] = "All attempts failed!";
    }

    private void unreliableServiceCall()
    {
        Random rnd = new Random();

        if (rnd.Next(10) < 7)
            throw new Exception("Service unavailable!");
    }
}
