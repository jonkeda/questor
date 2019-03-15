namespace Questor.UI
{
    public interface IViewModel
    {
        object GetModel();
        void SetModel(object model);
    }
}