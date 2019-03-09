using System.Threading.Tasks;

namespace Questor.UI
{
    public delegate Task CommandTaskDelegate();


    public delegate Task CommandTaskDelegate<in T>(T parameter);
}