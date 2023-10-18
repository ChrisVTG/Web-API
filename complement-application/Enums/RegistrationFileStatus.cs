using System.ComponentModel;

namespace Enums;

// https://docs.mollie.com/reference/v2/payments-api/create-payment
// https://github.com/Viincenttt/MollieApi/blob/development/src/Mollie.Api/Models/Payment/PaymentMethod.cs
// naming convention : PascalCase
public enum RegistrationFileStatus
{
    // new status here
    RandomNewStatus = 7,
    [Description("En cours de complétion")]
    CompletionInProgress = 0,
    [Description("Entièrement complété")]
    FullyCompleted = 1,
    [Description("En cours d'analyse")]
    InAnalysis = 2,
    [Description("Validé")]
    Validated = 3,
    [Description("Refusé")]
    Refused = 4,
    [Description("En attente d'un complément d'innformations")]
    WaitingForAdditionalInformation = 5,
    [Description("Abandonné")]
    Canceled = 6,
}