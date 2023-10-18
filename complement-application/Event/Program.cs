// See https://aka.ms/new-console-template for more information

using Event;

Console.WriteLine("Hello, World!");

var backgroundTask = new BackgrounndTask();
backgroundTask.OnProcessFinished += HandleOnProcessFinished;
// backgroundTask.OnProcessFinished += HandleOnProcessFinished;
// backgroundTask.OnProcessFinished += HandleOnProcessFinished;
backgroundTask.StartProcessing();

void HandleOnProcessFinished(object sender, BackgroundTaskEventArgs args)
{
    Console.WriteLine("Le processus en tâche de fond est terminé");
    Console.WriteLine($"Envoyé par ? {sender}");
    Console.WriteLine($"Est en succès ? {args.IsSuccess}");
    Console.WriteLine($"Date de fin ? {args.CompletionTime}");
    Console.WriteLine($"Temps écoulé en ms ? {args.ProcessDurationInMs}");
}

// backgroundTask.OnProcessFinished -= HandleOnProcessFinished;