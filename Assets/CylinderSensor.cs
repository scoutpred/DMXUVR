using UnityEngine;
using System.Runtime.InteropServices;

public class CylinderSensor : MonoBehaviour
{
    // Use WinAPI to simulate a key press
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

    private const uint KEYEVENTF_KEYUP = 0x0002;

    [Tooltip("Assign the key to simulate when the sphere enters.")]
    public KeyCode assignedKey = KeyCode.Q;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the sphere enters the trigger zone
        if (other.CompareTag("Sphere"))
        {
            Debug.Log($"Sphere entered the cylinder's sensor zone! Simulating '{assignedKey}' key press.");

            // Convert Unity KeyCode to a Windows virtual key code
            byte virtualKey = GetVirtualKeyCode(assignedKey);

            // Simulate key press for the assigned key
            if (virtualKey != 0)
            {
                keybd_event(virtualKey, 0, 0, 0); // Key down
                keybd_event(virtualKey, 0, KEYEVENTF_KEYUP, 0); // Key up
            }
            else
            {
                Debug.LogWarning($"Key '{assignedKey}' does not have a mapped virtual key code.");
            }
        }
    }

    private byte GetVirtualKeyCode(KeyCode key)
    {
        // Map Unity KeyCode to Windows Virtual Key Codes
        switch (key)
        {
            case KeyCode.A: return 0x41;
            case KeyCode.B: return 0x42;
            case KeyCode.C: return 0x43;
            case KeyCode.D: return 0x44;
            case KeyCode.E: return 0x45;
            case KeyCode.F: return 0x46;
            case KeyCode.G: return 0x47;
            case KeyCode.H: return 0x48;
            case KeyCode.I: return 0x49;
            case KeyCode.J: return 0x4A;
            case KeyCode.K: return 0x4B;
            case KeyCode.L: return 0x4C;
            case KeyCode.M: return 0x4D;
            case KeyCode.N: return 0x4E;
            case KeyCode.O: return 0x4F;
            case KeyCode.P: return 0x50;
            case KeyCode.Q: return 0x51;
            case KeyCode.R: return 0x52;
            case KeyCode.S: return 0x53;
            case KeyCode.T: return 0x54;
            case KeyCode.U: return 0x55;
            case KeyCode.V: return 0x56;
            case KeyCode.W: return 0x57;
            case KeyCode.X: return 0x58;
            case KeyCode.Y: return 0x59;
            case KeyCode.Z: return 0x5A;
            case KeyCode.Alpha0: return 0x30;
            case KeyCode.Alpha1: return 0x31;
            case KeyCode.Alpha2: return 0x32;
            case KeyCode.Alpha3: return 0x33;
            case KeyCode.Alpha4: return 0x34;
            case KeyCode.Alpha5: return 0x35;
            case KeyCode.Alpha6: return 0x36;
            case KeyCode.Alpha7: return 0x37;
            case KeyCode.Alpha8: return 0x38;
            case KeyCode.Alpha9: return 0x39;
            case KeyCode.F1: return 0x70;
            case KeyCode.F2: return 0x71;
            case KeyCode.F3: return 0x72;
            case KeyCode.F4: return 0x73;
            case KeyCode.F5: return 0x74;
            case KeyCode.F6: return 0x75;
            case KeyCode.F7: return 0x76;
            case KeyCode.F8: return 0x77;
            case KeyCode.F9: return 0x78;
            case KeyCode.F10: return 0x79;
            case KeyCode.F11: return 0x7A;
            case KeyCode.F12: return 0x7B;
            case KeyCode.Space: return 0x20;
            case KeyCode.Escape: return 0x1B;
            case KeyCode.Return: return 0x0D;
            case KeyCode.Tab: return 0x09;
            default: return 0; // No valid mapping
        }
    }
}
