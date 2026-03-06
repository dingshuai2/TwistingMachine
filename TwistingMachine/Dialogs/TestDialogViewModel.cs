using Prism.Mvvm;

namespace TwistingMachine.Dialogs
{
    public class TestDialogViewModel : BindableBase
    {
        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public TestDialogViewModel()
        {
            Message = "这是测试弹窗的视图模型";
        }
    }
}
