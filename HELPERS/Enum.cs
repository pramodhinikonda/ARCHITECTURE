using System.ComponentModel;

namespace Y_HELPERS
{
    public enum NotificationType
    {
        [Description("Information")]
        Information = 1,
        [Description("Warning")]
        Warning = 2,
        [Description("Error")]
        Error = 3
    }

    public enum ActivationStatus
    {
        [Description("Activated")]
        Activated = 1,
        [Description("Initiated")]
        Initiated = 2,
        [Description("Disabled")]
        Disabled = 3
    }
}
