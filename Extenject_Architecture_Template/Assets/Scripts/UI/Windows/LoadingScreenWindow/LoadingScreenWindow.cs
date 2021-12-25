using DG.Tweening;
using Infrastructure.Helpers.DoTweenHelper;
using UI.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.LoadingScreenWindow
{
    public class LoadingScreenWindow : ObjectWindow
    {
        private const float ZERO_PROGRESS_VALUE = 0f;
        private const float MIDDLE_PROGRESS_VALUE = 0.7f;
        private const float MAX_PROGRESS_VALUE = 1f;
        
        [SerializeField] private Image _progressSliderImage = null;
        [SerializeField] private float _beginProgressFillSpeed = 6f;
        [SerializeField] private float _endProgressFillSpeed = 0.5f;
        [SerializeField] private Ease _beginAnimationEasing;
        [SerializeField] private Ease _endAnimationEasing;

        private DoTweenHelper _doTweenHelper = null;
        private UIController _uiController = null;
        private Sequence _currentAnimationSequence = null;
        
        [Inject]
        public void Construct(DoTweenHelper doTweenHelper, UIController uiController)
        {
            _doTweenHelper = doTweenHelper;
            _uiController = uiController;
        }
        
        public override void Initialize()
        {
            base.Initialize();
            ResetProgressbar();
        }

        public override void Show()
        {
            base.Show();
        }

        public void StartLoading()
        {
            BeginProgressFillAnimation();
        }

        public void FinalizeLoading()
        {
            EndProgressFillAnimation();
        }

        public override void Close()
        {
            base.Close();
        }

        private void ResetProgressbar()
        {
            _progressSliderImage.fillAmount = ZERO_PROGRESS_VALUE;
        }

        private void BeginProgressFillAnimation()
        {
            _currentAnimationSequence = _doTweenHelper
                .CreateImageFillSequence(_progressSliderImage, MIDDLE_PROGRESS_VALUE, _beginProgressFillSpeed, _beginAnimationEasing);

            _currentAnimationSequence.Play();
        }
        
        private void EndProgressFillAnimation()
        {
            _currentAnimationSequence?.Kill();
            _currentAnimationSequence = _doTweenHelper
                .CreateImageFillSequence(_progressSliderImage, MAX_PROGRESS_VALUE, _endProgressFillSpeed, _endAnimationEasing,
                    () =>
                    {
                        _uiController.OnCloseWindow<LoadingScreenWindow>();
                    });

            _currentAnimationSequence.Play();
        }
    }
}