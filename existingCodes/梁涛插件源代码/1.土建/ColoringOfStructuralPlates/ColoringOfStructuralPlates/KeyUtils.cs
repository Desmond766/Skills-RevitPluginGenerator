using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColoringOfStructuralPlates
{
    public class KeyUtils
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // ESC键的虚拟键码
        private const byte VK_ESCAPE = 0x1B;

        // 按键标志
        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        /// <summary>
        /// 使用Windows API模拟ESC键
        /// </summary>
        public static void SimulateEscapePress()
        {
            try
            {
                // 按下ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);

                // 等待10毫秒
                System.Threading.Thread.Sleep(10);

                // 释放ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception($"模拟ESC键失败: {ex.Message}");
            }
        }
    }
}
