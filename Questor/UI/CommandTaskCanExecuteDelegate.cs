using System.Threading.Tasks;

namespace Questor.UI
{
    public delegate Task<bool> CommandTaskCanExecuteDelegate<in T>(T parameter);

    public delegate Task<bool> CommandTaskCanExecuteDelegate();
}