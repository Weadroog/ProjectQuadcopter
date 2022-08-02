using Services;

namespace UI
{
    public class MoneyDisplayer : UIDisplayer 
    {
        private void OnEnable()
        {
            MoneyService.OnChanged += Display;
        }

        private void OnDisable()
        {
            MoneyService.OnChanged -= Display;
        }
    }
}
