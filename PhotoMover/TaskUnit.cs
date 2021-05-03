using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    public class TaskUnit
    {
        private string srcFileName;
        private string destFileName;
        private bool isMove;
        private DateProviderBase dateProvider;
        private TaskStatus status;

    }
    public enum TaskStatus
    {
        NotStarted,
        Skipped,
        GettingDate,
        GetDateFailed,
        Moving,
        Copying,
        Moved,
        Copied,
        MoveFailed,
        CopyFailed
    }
}
