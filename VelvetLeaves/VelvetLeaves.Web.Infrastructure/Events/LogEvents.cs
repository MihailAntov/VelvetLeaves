

namespace VelvetLeaves.Web.Infrastructure.Events
{
    public class LogEvents
    {
        public const int GetActionCalled = 1000;
        public const int PostActionCalled = 1001;
        public const int ActionSucceeded = 2000;
        public const int ActionReturnedNull = 2001;
        public const int ExceptionWasThrown = 2002;
    }
}
