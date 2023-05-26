using System.ComponentModel;

namespace TaskManager.Enums
{
    public enum TaskStatus
    {
        [Description("Awaiting task")]
        TODO = 1,
        [Description("Task in progress")]
        ONGOIING = 2,
        [Description("Task done")]
        DONE = 3
    }
}
