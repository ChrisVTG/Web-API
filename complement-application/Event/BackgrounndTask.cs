using System.Diagnostics;

namespace Event;

public class BackgrounndTask
{
    public EventHandler<BackgroundTaskEventArgs> OnProcessFinished;
    
    public void StartProcessing()
    {
        var sw = new Stopwatch();
        sw.Start();
        try
        {
            //
            // do something
            //
            Thread.Sleep(5000);
            throw new Exception("quelque chose s'est mal passé");
            //
            // do something
            // 
            OnProcessCompleted(new BackgroundTaskEventArgs()
            {
                IsSuccess = true,
                CompletionTime = DateTime.Now,
                ProcessDurationInMs = sw.ElapsedMilliseconds
            });
        }
        catch (Exception ex)
        {
            OnProcessCompleted(new BackgroundTaskEventArgs()
            {
                IsSuccess = false,
                CompletionTime = DateTime.Now,
                ProcessDurationInMs = sw.ElapsedMilliseconds
            });
        }
    }

    private void OnProcessCompleted(BackgroundTaskEventArgs eventArgs)
    {
        OnProcessFinished.Invoke(this, eventArgs);
    }
}