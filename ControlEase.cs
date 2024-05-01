namespace ControlEase
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.XR;

    public static class ControlEase
    {
        // Static method to query if a button is pressed on a given controller (left or right hand)
        public static bool IsButtonPressed(HandType handType, InputFeatureUsage<bool> usage)
        {
            return GetDevice(handType).TryGetFeatureValue(usage, out bool value) && value;
        }

        // Static method to provide haptic feedback to a specific hand controller
        public static IEnumerator ProvideHapticFeedback(HandType handType, float amplitude, float duration)
        {
            InputDevice device = GetDevice(handType);
            device.SendHapticImpulse(0, amplitude, duration);
            yield return new WaitForSeconds(duration);
        }

        // Static helper method to get the appropriate device (left or right hand) based on the hand type
        private static InputDevice GetDevice(HandType handType)
        {
            return handType == HandType.Left ? InputDevices.GetDeviceAtXRNode(XRNode.LeftHand) : InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }
    }

    // Enum for differentiating between left and right hands
    public enum HandType
    {
        Left,
        Right
    }
}
