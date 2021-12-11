using System;
using DG.Tweening;
using UnityEngine.UI;

namespace Infrastructure.Helpers.DoTweenHelper
{
    public class DoTweenHelper
    {
        public Sequence CreateImageFillSequence(Image objectToFill, float endValue, float duration, Ease ease, Action onCompleteAction = null)
        {
            Sequence imageSequence = DOTween.Sequence();
            imageSequence.SetEase(ease);
            imageSequence.Append(objectToFill.DOFillAmount(endValue, duration));
            imageSequence.AppendCallback(() => onCompleteAction?.Invoke());

            return imageSequence;
        }
    }
}