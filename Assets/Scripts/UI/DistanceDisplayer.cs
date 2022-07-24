using Services;

namespace UI
{
    public class DistanceDisplayer : UIDisplayer 
    {
        private void OnEnable()
        {
            DistanceService.OnChanged += Display;
        }

        private void OnDisable()
        {
            DistanceService.OnChanged -= Display;
        }
    }
}
