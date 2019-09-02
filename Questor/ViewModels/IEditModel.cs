namespace Questor.ViewModels
{
    public interface IEditModel
    {
        void Insert();
        void Create();
        void Delete();
        bool Validate();
    }
}