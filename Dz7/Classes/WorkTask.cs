using Dz7lat.enums;

namespace Dz7lat.Classes
{
    public class WorkTask
    {
        public string Title { get; }
        public TaskTarget Target { get; }

        public WorkTask(string title, TaskTarget target)
        {
            Title = title;
            Target = target;
        }
    }
}
