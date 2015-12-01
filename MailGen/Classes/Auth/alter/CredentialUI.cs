﻿/*
 * CredentialUI.cs - Windows Credential UI Helper
 * 
 * License: Public Domain
 * 
 */

namespace MailGen.Classes.Auth.alter
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Credential UI Helper
    /// </summary>
    /// <example>
    /// var credentials = CredentialUI.Prompt("Caption", "Message", "DOMAIN\\KazariUiharu", "P@ssw0rd1"); // Vista or 7: PromptForWindowsCredentials / 2000 or XP or 2003: PromptForCredentials
    /// var credentials2 = CredentialUI.PromptForWindowsCredentials("Caption", "Message");
    /// Console.WriteLine("UserName: {0}", credentials2.UserName);
    /// Console.WriteLine("DomainName: {0}", credentials2.DomainName);
    /// Console.WriteLine("Password: {0}", credentials2.Password);
    /// </example>
    internal static class CredentialUi
    {
        /// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsResult Prompt(
            string caption, string message, string userName = null, string password = null)
        {
            return Prompt(caption, message, IntPtr.Zero, userName, password);
        }

        /// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        private static PromptCredentialsResult Prompt(
            string caption,
            string message,
            IntPtr hwndParent,
            string userName = null,
            string password = null)
        {
            return Environment.OSVersion.Version.Major >= 6
                ? PromptForWindowsCredentials(caption, message, hwndParent, userName, password)
                : PromptForCredentials(Environment.UserDomainName, caption, message, hwndParent, userName, password);
            // Windows 2000 or 2003 or XP
        }

        /*/// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptWithSecureString(string caption, string message)
        {
            return PromptWithSecureString(caption, message, IntPtr.Zero);
        }*/

        /*/// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptWithSecureString(
            string caption,
            string message,
            IntPtr hwndParent)
        {
            return PromptWithSecureString(caption, message, IntPtr.Zero, null, null);
        }*/

        /*/// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptWithSecureString(
            string caption,
            string message,
            SecureString userName,
            SecureString password)
        {
            return PromptWithSecureString(caption, message, IntPtr.Zero, userName, password);
        }*/

        /*/// <summary>
        /// Show dialog box for generic credential.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptWithSecureString(
            string caption,
            string message,
            IntPtr hwndParent,
            SecureString userName,
            SecureString password)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                // Windows Vista or 2008 or 7 or later
                return PromptForWindowsCredentialsWithSecureString(caption, message, hwndParent, userName, password);
            }
            // Windows 2000 or 2003 or XP
            return PromptForCredentialsWithSecureString(
                Environment.UserDomainName,
                caption,
                message,
                hwndParent,
                userName,
                password);
        }*/


        #region Method: PromptForWindowsCredentials

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForWindowsCredentials(string caption, string message)
        {
            return PromptForWindowsCredentials(caption, message, string.Empty, string.Empty);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForWindowsCredentials(
            string caption,
            string message,
            IntPtr hwndParent)
        {
            return PromptForWindowsCredentials(caption, message, hwndParent);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForWindowsCredentials(
            string caption,
            string message,
            string userName,
            string password)
        {
            return PromptForWindowsCredentials(caption, message, IntPtr.Zero, userName, password);
        }*/

        /// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static PromptCredentialsResult PromptForWindowsCredentials(
            string caption,
            string message,
            IntPtr hwndParent,
            string userName,
            string password)
        {
            PromptForWindowsCredentialsOptions options = new PromptForWindowsCredentialsOptions(caption, message)
            {
                HwndParent = hwndParent,
                IsSaveChecked = true
            };
            return PromptForWindowsCredentials(options, userName, password);

        }

        /// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static PromptCredentialsResult PromptForWindowsCredentials(
            PromptForWindowsCredentialsOptions options,
            string userName,
            string password)
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
                return PromptForWindowsCredentialsInternal<PromptCredentialsResult>(options, null, null);

            using (SecureString userNameS = new SecureString())
            using (SecureString passwordS = new SecureString())
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    foreach (char c in userName)
                        userNameS.AppendChar(c);
                }
                if (!string.IsNullOrEmpty(password))
                {
                    foreach (char c in password)
                        passwordS.AppendChar(c);
                }

                userNameS.MakeReadOnly();
                passwordS.MakeReadOnly();
                return PromptForWindowsCredentialsInternal<PromptCredentialsResult>(options, userNameS, passwordS);
            }
        }

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForWindowsCredentialsWithSecureString(
            string caption,
            string message)
        {
            return PromptForWindowsCredentialsWithSecureString(caption, message, IntPtr.Zero, null, null);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForWindowsCredentialsWithSecureString(
            string caption,
            string message,
            IntPtr hwndParent)
        {
            return PromptForWindowsCredentialsWithSecureString(caption, message, hwndParent, null, null);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForWindowsCredentialsWithSecureString(
            string caption,
            string message,
            SecureString userName,
            SecureString password)
        {
            return PromptForWindowsCredentialsWithSecureString(caption, message, IntPtr.Zero, userName, password);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForWindowsCredentialsWithSecureString(
            string caption,
            string message,
            IntPtr hwndParent,
            SecureString userName,
            SecureString password)
        {
            PromptForWindowsCredentialsOptions options = new PromptForWindowsCredentialsOptions(caption, message)
            {
                HwndParent = hwndParent,
                IsSaveChecked = false
            };
            return PromptForWindowsCredentialsWithSecureString(options, userName, password);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that allows users to supply credential information by using any credential provider installed on the local computer.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForWindowsCredentialsWithSecureString(
            PromptForWindowsCredentialsOptions options,
            SecureString userName,
            SecureString password)
        {
            return PromptForWindowsCredentialsInternal<PromptCredentialsSecureStringResult>(options, userName, password);
        }*/

        private static T PromptForWindowsCredentialsInternal<T>(
            PromptForWindowsCredentialsOptions options,
            SecureString userName,
            SecureString password) where T : class, IPromptCredentialsResult
        {
            NativeMethods.CreduiInfo creduiInfo = new NativeMethods.CreduiInfo
            {
                pszCaptionText = options.Caption,
                pszMessageText = options.Message,
                hwndParent = options.HwndParent,
                hbmBanner = options.HbmBanner
            };

            PromptForWindowsCredentialsFlag credentialsFlag = options.Flags;

            IntPtr userNamePtr = IntPtr.Zero;
            IntPtr passwordPtr = IntPtr.Zero;
            int authPackage = 0;
            IntPtr outAuthBuffer = IntPtr.Zero;
            IntPtr inAuthBuffer = IntPtr.Zero;
            int inAuthBufferSize = 0;
            bool save = options.IsSaveChecked;
            try
            {
                if (userName != null || password != null)
                {
                    if (userName == null) userName = new SecureString();
                    if (password == null) password = new SecureString();
                    userNamePtr = Marshal.SecureStringToCoTaskMemUnicode(userName);
                    passwordPtr = Marshal.SecureStringToCoTaskMemUnicode(password);
                }

                // prefilled with UserName or Password
                if (userNamePtr != IntPtr.Zero || passwordPtr != IntPtr.Zero)
                {
                    inAuthBufferSize = 1024;
                    inAuthBuffer = Marshal.AllocCoTaskMem(inAuthBufferSize);
                    if (
                        !NativeMethods.CredPackAuthenticationBuffer(
                            0x00,
                            userNamePtr,
                            passwordPtr,
                            inAuthBuffer,
                            ref inAuthBufferSize))
                    {
                        int win32Error = Marshal.GetLastWin32Error();
                        if (win32Error == 122 /*ERROR_INSUFFICIENT_BUFFER*/)
                        {
                            inAuthBuffer = Marshal.ReAllocCoTaskMem(inAuthBuffer, inAuthBufferSize);
                            if (
                                !NativeMethods.CredPackAuthenticationBuffer(
                                    0x00,
                                    userNamePtr,
                                    passwordPtr,
                                    inAuthBuffer,
                                    ref inAuthBufferSize))
                            {
                                throw new Win32Exception(Marshal.GetLastWin32Error());
                            }
                        }
                        else
                        {
                            throw new Win32Exception(win32Error);
                        }
                    }
                }

                int outAuthBufferSize;
                NativeMethods.CredUiPromptReturnCode retVal = NativeMethods.CredUIPromptForWindowsCredentials(
                    creduiInfo,
                    options.AuthErrorCode,
                    ref authPackage,
                    inAuthBuffer,
                    inAuthBufferSize,
                    out outAuthBuffer,
                    out outAuthBufferSize,
                    ref save,
                    credentialsFlag);

                switch (retVal)
                {
                    case NativeMethods.CredUiPromptReturnCode.Cancelled:
                        return null;
                    case NativeMethods.CredUiPromptReturnCode.Success:
                        break;
                    default:
                        throw new Win32Exception((int)retVal);
                }


                if (typeof(T) == typeof(PromptCredentialsSecureStringResult))
                {
                    PromptCredentialsSecureStringResult credResult =
                        NativeMethods.CredUnPackAuthenticationBufferWrapSecureString(
                            true,
                            outAuthBuffer,
                            outAuthBufferSize);
                    credResult.IsSaveChecked = save;
                    return credResult as T;
                }
                else
                {
                    PromptCredentialsResult credResult = NativeMethods.CredUnPackAuthenticationBufferWrap(
                        true,
                        outAuthBuffer,
                        outAuthBufferSize);
                    credResult.IsSaveChecked = save;
                    return credResult as T;
                }
            }
            finally
            {
                if (inAuthBuffer != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(inAuthBuffer);
                if (outAuthBuffer != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(outAuthBuffer);
                if (userNamePtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(userNamePtr);
                if (passwordPtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(passwordPtr);
            }
        }

        #endregion

        #region Method: PromptForCredentials

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForCredentials(string targetName, string caption, string message)
        {
            return PromptForCredentials(new PromptForCredentialsOptions(targetName, caption, message));
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForCredentials(
            string targetName,
            string caption,
            string message,
            IntPtr hwndParent)
        {
            return PromptForCredentials(targetName, caption, message, hwndParent);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForCredentials(
            string targetName,
            string caption,
            string message,
            string userName,
            string password)
        {
            return PromptForCredentials(targetName, caption, message, IntPtr.Zero, userName, password);
        }*/

        /// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static PromptCredentialsResult PromptForCredentials(
            string targetName,
            string caption,
            string message,
            IntPtr hwndParent,
            string userName,
            string password)
        {
            return
                PromptForCredentials(
                    new PromptForCredentialsOptions(targetName, caption, message) { HwndParent = hwndParent },
                    userName,
                    password);
        }

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static PromptCredentialsResult PromptForCredentials(PromptForCredentialsOptions options)
        {
            return PromptForCredentials(options, null, null);
        }*/

        /// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static PromptCredentialsResult PromptForCredentials(
            PromptForCredentialsOptions options,
            string userName,
            string password)
        {
            using (SecureString userNameS = new SecureString())
            using (SecureString passwordS = new SecureString())
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    foreach (char c in userName) userNameS.AppendChar(c);
                }
                if (!string.IsNullOrEmpty(password))
                {
                    foreach (char c in password) passwordS.AppendChar(c);
                }

                userNameS.MakeReadOnly();
                passwordS.MakeReadOnly();
                return PromptForCredentialsInternal<PromptCredentialsResult>(options, userNameS, passwordS);
            }
        }

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            string targetName,
            string caption,
            string message)
        {
            return PromptForCredentialsWithSecureString(new PromptForCredentialsOptions(targetName, caption, message));
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            string targetName,
            string caption,
            string message,
            IntPtr hwndParent)
        {
            return PromptForCredentialsWithSecureString(targetName, caption, message, hwndParent, null, null);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            string targetName,
            string caption,
            string message,
            SecureString userName,
            SecureString password)
        {
            return PromptForCredentialsWithSecureString(targetName, caption, message, IntPtr.Zero, userName, password);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="hwndParent"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            string targetName,
            string caption,
            string message,
            IntPtr hwndParent,
            SecureString userName,
            SecureString password)
        {
            return
                PromptForCredentialsWithSecureString(
                    new PromptForCredentialsOptions(targetName, caption, message) { HwndParent = hwndParent },
                    userName,
                    password);
        }*/

        /*/// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            PromptForCredentialsOptions options)
        {
            return PromptForCredentialsInternal<PromptCredentialsSecureStringResult>(options, null, null);
        }

        /// <summary>
        /// Creates and displays a configurable dialog box that accepts credentials information from a user.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PromptCredentialsSecureStringResult PromptForCredentialsWithSecureString(
            PromptForCredentialsOptions options,
            SecureString userName,
            SecureString password)
        {
            return PromptForCredentialsInternal<PromptCredentialsSecureStringResult>(options, userName, password);
        }*/

        private static T PromptForCredentialsInternal<T>(
            PromptForCredentialsOptions options,
            SecureString userName,
            SecureString password) where T : class, IPromptCredentialsResult
        {
            if (options == null) throw new ArgumentNullException("options");
            if (userName != null && (userName.Length > NativeMethods.CreduiMaxUsernameLength))
                throw new ArgumentOutOfRangeException("userName", @"CREDUI_MAX_USERNAME_LENGTH");
            if (password != null && (password.Length > NativeMethods.CreduiMaxPasswordLength))
                throw new ArgumentOutOfRangeException("password", @"CREDUI_MAX_PASSWORD_LENGTH");

            NativeMethods.CreduiInfo creduiInfo = new NativeMethods.CreduiInfo
            {
                pszCaptionText = options.Caption,
                pszMessageText = options.Message,
                hwndParent = options.HwndParent,
                hbmBanner = options.HbmBanner
            };
            IntPtr userNamePtr = IntPtr.Zero;
            IntPtr passwordPtr = IntPtr.Zero;
            bool save = options.IsSaveChecked;
            try
            {
                // The maximum number of characters that can be copied to (pszUserName|szPassword) including the terminating null character.
                if (userName == null)
                {
                    userNamePtr = Marshal.AllocCoTaskMem((NativeMethods.CreduiMaxUsernameLength + 1) * sizeof(short));
                    Marshal.WriteInt16(userNamePtr, 0, 0x00);
                }
                else
                {
                    userNamePtr = Marshal.SecureStringToCoTaskMemUnicode(userName);
                    userNamePtr = Marshal.ReAllocCoTaskMem(
                        userNamePtr,
                        (NativeMethods.CreduiMaxUsernameLength + 1) * sizeof(short));
                }

                if (password == null)
                {
                    passwordPtr = Marshal.AllocCoTaskMem((NativeMethods.CreduiMaxPasswordLength + 1) * sizeof(short));
                    Marshal.WriteInt16(passwordPtr, 0, 0x00);
                }
                else
                {
                    passwordPtr = Marshal.SecureStringToCoTaskMemUnicode(password);
                    passwordPtr = Marshal.ReAllocCoTaskMem(
                        passwordPtr,
                        (NativeMethods.CreduiMaxPasswordLength + 1) * sizeof(short));
                }
                Marshal.WriteInt16(userNamePtr, NativeMethods.CreduiMaxUsernameLength * sizeof(short), 0x00);
                Marshal.WriteInt16(passwordPtr, NativeMethods.CreduiMaxPasswordLength * sizeof(short), 0x00);

                NativeMethods.CredUiPromptReturnCode retVal = NativeMethods.CredUIPromptForCredentials(
                    creduiInfo,
                    options.TargetName,
                    IntPtr.Zero,
                    options.AuthErrorCode,
                    userNamePtr,
                    NativeMethods.CreduiMaxUsernameLength,
                    passwordPtr,
                    NativeMethods.CreduiMaxPasswordLength,
                    ref save,
                    options.Flags);
                switch (retVal)
                {
                    case NativeMethods.CredUiPromptReturnCode.Cancelled:
                        return null;
                    case NativeMethods.CredUiPromptReturnCode.InvalidParameter:
                        throw new Win32Exception((int)retVal);
                    case NativeMethods.CredUiPromptReturnCode.InvalidFlags:
                        throw new Win32Exception((int)retVal);
                    case NativeMethods.CredUiPromptReturnCode.Success:
                        break;
                    default:
                        throw new Win32Exception((int)retVal);
                }


                if (typeof(T) == typeof(PromptCredentialsSecureStringResult))
                {
                    return
                        new PromptCredentialsSecureStringResult
                        {
                            UserName = NativeMethods.PtrToSecureString(userNamePtr),
                            Password = NativeMethods.PtrToSecureString(passwordPtr),
                            IsSaveChecked = save
                        } as T;
                }
                else
                {
                    return
                        new PromptCredentialsResult
                        {
                            UserName = Marshal.PtrToStringUni(userNamePtr),
                            Password = Marshal.PtrToStringUni(passwordPtr),
                            IsSaveChecked = save
                        } as T;
                }
            }
            finally
            {
                if (userNamePtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(userNamePtr);
                if (passwordPtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(passwordPtr);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        private enum PromptForWindowsCredentialsFlag
        {
            /// <summary>
            /// Plain text username/password is being requested
            /// </summary>
            CreduiwinGeneric = 0x00000001,

            /// <summary>
            /// Show the Save Credential checkbox
            /// </summary>
            CreduiwinCheckbox = 0x00000002,

            /// <summary>
            /// Only Cred Providers that support the input auth package should enumerate
            /// </summary>
            CreduiwinAuthpackageOnly = 0x00000010,

            /// <summary>
            /// Only the incoming cred for the specific auth package should be enumerated
            /// </summary>
            CreduiwinInCredOnly = 0x00000020,

            /// <summary>
            /// Cred Providers should enumerate administrators only
            /// </summary>
            CreduiwinEnumerateAdmins = 0x00000100,

            /// <summary>
            /// Only the incoming cred for the specific auth package should be enumerated
            /// </summary>
            CreduiwinEnumerateCurrentUser = 0x00000200,

            /// <summary>
            /// The Credui prompt should be displayed on the secure desktop
            /// </summary>
            CreduiwinSecurePrompt = 0x00001000,

            /// <summary>
            /// Tell the credential provider it should be packing its Auth Blob 32 bit even though it is running 64 native
            /// </summary>
            CreduiwinPack32Wow = 0x10000000
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        private enum PromptForCredentialsFlag
        {
            /// <summary>
            /// indicates the username is valid, but password is not
            /// </summary>
            CreduiFlagsIncorrectPassword = 0x00001,

            /// <summary>
            /// Do not show "Save" checkbox, and do not persist credentials
            /// </summary>
            CreduiFlagsDoNotPersist = 0x00002,

            /// <summary>
            /// Populate list box with admin accounts
            /// </summary>
            CreduiFlagsRequestAdministrator = 0x00004,

            /// <summary>
            /// do not include certificates in the drop list
            /// </summary>
            CreduiFlagsExcludeCertificates = 0x00008,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsRequireCertificate = 0x00010,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsShowSaveCheckBox = 0x00040,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsAlwaysShowUi = 0x00080,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsRequireSmartcard = 0x00100,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsPasswordOnlyOk = 0x00200,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsValidateUsername = 0x00400,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsCompleteUsername = 0x00800,

            /// <summary>
            /// Do not show "Save" checkbox, but persist credentials anyway
            /// </summary>
            CreduiFlagsPersist = 0x01000,

            /// <summary>
            /// 
            /// </summary>
            CreduiFlagsServerCredential = 0x04000,

            /// <summary>
            /// do not persist unless caller later confirms credential via CredUIConfirmCredential() api
            /// </summary>
            CreduiFlagsExpectConfirmation = 0x20000,

            /// <summary>
            /// Credential is a generic credential
            /// </summary>
            CreduiFlagsGenericCredentials = 0x40000,

            /// <summary>
            /// Credential has a username as the target
            /// </summary>
            CreduiFlagsUsernameTargetCredentials = 0x80000,

            /// <summary>
            /// don't allow the user to change the supplied username
            /// </summary>
            CreduiFlagsKeepUsername = 0x100000
        }

        /// <summary>
        /// 
        /// </summary>
        private sealed class PromptForWindowsCredentialsOptions
        {
            private string _caption;

            private string _message;

            public string Caption
            {
                get
                {
                    return this._caption;
                }
                set
                {
                    if (value.Length > NativeMethods.CreduiMaxCaptionLength) throw new ArgumentOutOfRangeException("value");
                    this._caption = value;
                }
            }

            public string Message
            {
                get
                {
                    return this._message;
                }
                set
                {
                    if (value.Length > NativeMethods.CreduiMaxMessageLength) throw new ArgumentOutOfRangeException("value");
                    this._message = value;
                }
            }

            public IntPtr HwndParent { get; set; }

            public IntPtr HbmBanner { get; set; }

            public bool IsSaveChecked { get; set; }

            public PromptForWindowsCredentialsFlag Flags { get; set; }

            public int AuthErrorCode { get; set; }

            public PromptForWindowsCredentialsOptions(string caption, string message)
            {
                if (string.IsNullOrEmpty(caption)) throw new ArgumentNullException("caption");
                if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
                this.Caption = caption;
                this.Message = message;
                this.Flags = 
                    PromptForWindowsCredentialsFlag.CreduiwinGeneric 
                    | PromptForWindowsCredentialsFlag.CreduiwinCheckbox;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private sealed class PromptForCredentialsOptions
        {
            private string _caption;

            private string _message;

            public string Caption
            {
                get
                {
                    return this._caption;
                }
                set
                {
                    if (value.Length > NativeMethods.CreduiMaxCaptionLength) throw new ArgumentOutOfRangeException("value");
                    this._caption = value;
                }
            }

            public string Message
            {
                get
                {
                    return this._message;
                }
                set
                {
                    if (value.Length > NativeMethods.CreduiMaxMessageLength) throw new ArgumentOutOfRangeException("value");
                    this._message = value;
                }
            }

            public string TargetName { get; set; }

            public IntPtr HwndParent { get; set; }

            public IntPtr HbmBanner { get; set; }

            public bool IsSaveChecked { get; set; }

            public PromptForCredentialsFlag Flags { get; set; }

            public int AuthErrorCode { get; set; }

            public PromptForCredentialsOptions(string targetName, string caption, string message)
            {
                if (string.IsNullOrEmpty(targetName)) throw new ArgumentNullException("targetName");
                if (string.IsNullOrEmpty(caption)) throw new ArgumentNullException("caption");
                if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
                this.TargetName = targetName;
                this.Caption = caption;
                this.Message = message;
                this.Flags = PromptForCredentialsFlag.CreduiFlagsGenericCredentials
                        | PromptForCredentialsFlag.CreduiFlagsDoNotPersist;
            }
        }

        private static class NativeMethods
        {
            public const int CreduiMaxMessageLength = 32767;

            public const int CreduiMaxCaptionLength = 128;

            public const int CredMaxUsernameLength = (256 + 1 + 256);

            public const int CreduiMaxUsernameLength = CredMaxUsernameLength;

            public const int CreduiMaxPasswordLength = (512 / 2);

            public enum CredUiPromptReturnCode
            {
                Success = 0,

                Cancelled = 1223,

                InvalidParameter = 87,

                InvalidFlags = 1004
            }

            [StructLayout(LayoutKind.Sequential)]
            [SuppressMessage("ReSharper", "NotAccessedField.Local")]
            public sealed class CreduiInfo
            {
                public int cbSize;

#pragma warning disable 414
                public IntPtr hwndParent;
#pragma warning restore 414

                [MarshalAs(UnmanagedType.LPWStr)]
#pragma warning disable 414
                public string pszMessageText;
#pragma warning restore 414

                [MarshalAs(UnmanagedType.LPWStr)]
#pragma warning disable 414
                public string pszCaptionText;
#pragma warning restore 414

#pragma warning disable 414
                public IntPtr hbmBanner;
#pragma warning restore 414

                public CreduiInfo()
                {
                    this.cbSize = Marshal.SizeOf(typeof(CreduiInfo));
                }
            }

            //
            // CredUIPromptForCredentials -------------------------------------
            //
            [DllImport(@"credui.dll", CharSet = CharSet.Unicode)]
            public static extern CredUiPromptReturnCode CredUIPromptForCredentials(
                CreduiInfo pUiInfo,
                string pszTargetName,
                IntPtr reserved,
                int dwAuthError,
                IntPtr pszUserName,
                int ulUserNameMaxChars,
                IntPtr pszPassword,
                int ulPasswordMaxChars,
                ref bool pfSave,
                PromptForCredentialsFlag dwFlags);

            //
            // CredUIPromptForWindowsCredentials ------------------------------
            //
            [DllImport(@"credui.dll", CharSet = CharSet.Unicode)]
            public static extern CredUiPromptReturnCode CredUIPromptForWindowsCredentials(
                CreduiInfo pUiInfo,
                int dwAuthError,
                ref int pulAuthPackage,
                IntPtr pvInAuthBuffer,
                int ulInAuthBufferSize,
                out IntPtr ppvOutAuthBuffer,
                out int pulOutAuthBufferSize,
                ref bool pfSave,
                PromptForWindowsCredentialsFlag dwFlags);

            [DllImport(@"credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool CredPackAuthenticationBuffer(
                int dwFlags,
                string pszUserName,
                string pszPassword,
                IntPtr pPackedCredentials,
                ref int pcbPackedCredentials);

            [DllImport(@"credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool CredPackAuthenticationBuffer(
                int dwFlags,
                IntPtr pszUserName,
                IntPtr pszPassword,
                IntPtr pPackedCredentials,
                ref int pcbPackedCredentials);

            [DllImport(@"credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern bool CredUnPackAuthenticationBuffer(
                int dwFlags,
                IntPtr pAuthBuffer,
                int cbAuthBuffer,
                StringBuilder pszUserName,
                ref int pcchMaxUserName,
                StringBuilder pszDomainName,
                ref int pcchMaxDomainame,
                StringBuilder pszPassword,
                ref int pcchMaxPassword);

            [DllImport(@"credui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern bool CredUnPackAuthenticationBuffer(
                int dwFlags,
                IntPtr pAuthBuffer,
                int cbAuthBuffer,
                IntPtr pszUserName,
                ref int pcchMaxUserName,
                IntPtr pszDomainName,
                ref int pcchMaxDomainame,
                IntPtr pszPassword,
                ref int pcchMaxPassword);

            public static PromptCredentialsResult CredUnPackAuthenticationBufferWrap(
                bool decryptProtectedCredentials,
                IntPtr authBufferPtr,
                int authBufferSize)
            {
                StringBuilder sbUserName = new StringBuilder(255);
                StringBuilder sbDomainName = new StringBuilder(255);
                StringBuilder sbPassword = new StringBuilder(255);
                int userNameSize = sbUserName.Capacity;
                int domainNameSize = sbDomainName.Capacity;
                int passwordSize = sbPassword.Capacity;

                //#define CRED_PACK_PROTECTED_CREDENTIALS      0x1
                //#define CRED_PACK_WOW_BUFFER                 0x2
                //#define CRED_PACK_GENERIC_CREDENTIALS        0x4

                bool result = CredUnPackAuthenticationBuffer(
                    (decryptProtectedCredentials ? 0x1 : 0x0),
                    authBufferPtr,
                    authBufferSize,
                    sbUserName,
                    ref userNameSize,
                    sbDomainName,
                    ref domainNameSize,
                    sbPassword,
                    ref passwordSize);

                if (result)
                {
                    return new PromptCredentialsResult
                    {
                        UserName = sbUserName.ToString(),
                        DomainName = sbDomainName.ToString(),
                        Password = sbPassword.ToString()
                    };
                }

                int win32Error = Marshal.GetLastWin32Error();
                if (win32Error == 122 /*ERROR_INSUFFICIENT_BUFFER*/)
                {
                    sbUserName.Capacity = userNameSize;
                    sbPassword.Capacity = passwordSize;
                    sbDomainName.Capacity = domainNameSize;
                    result = CredUnPackAuthenticationBuffer(
                        (decryptProtectedCredentials ? 0x1 : 0x0),
                        authBufferPtr,
                        authBufferSize,
                        sbUserName,
                        ref userNameSize,
                        sbDomainName,
                        ref domainNameSize,
                        sbPassword,
                        ref passwordSize);
                    if (!result)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
                else
                {
                    throw new Win32Exception(win32Error);
                }

                return new PromptCredentialsResult
                {
                    UserName = sbUserName.ToString(),
                    DomainName = sbDomainName.ToString(),
                    Password = sbPassword.ToString()
                };
            }

            public static PromptCredentialsSecureStringResult CredUnPackAuthenticationBufferWrapSecureString(
                bool decryptProtectedCredentials,
                IntPtr authBufferPtr,
                int authBufferSize)
            {
                int userNameSize = 255;
                int domainNameSize = 255;
                int passwordSize = 255;
                IntPtr userNamePtr = IntPtr.Zero;
                IntPtr domainNamePtr = IntPtr.Zero;
                IntPtr passwordPtr = IntPtr.Zero;
                try
                {
                    userNamePtr = Marshal.AllocCoTaskMem(userNameSize);
                    domainNamePtr = Marshal.AllocCoTaskMem(domainNameSize);
                    passwordPtr = Marshal.AllocCoTaskMem(passwordSize);

                    //#define CRED_PACK_PROTECTED_CREDENTIALS      0x1
                    //#define CRED_PACK_WOW_BUFFER                 0x2
                    //#define CRED_PACK_GENERIC_CREDENTIALS        0x4

                    bool result = CredUnPackAuthenticationBuffer(
                        (decryptProtectedCredentials ? 0x1 : 0x0),
                        authBufferPtr,
                        authBufferSize,
                        userNamePtr,
                        ref userNameSize,
                        domainNamePtr,
                        ref domainNameSize,
                        passwordPtr,
                        ref passwordSize);

                    if (result)
                    {
                        return new PromptCredentialsSecureStringResult
                        {
                            UserName = PtrToSecureString(userNamePtr, userNameSize),
                            DomainName = PtrToSecureString(domainNamePtr, domainNameSize),
                            Password = PtrToSecureString(passwordPtr, passwordSize)
                        };
                    }

                    int win32Error = Marshal.GetLastWin32Error();
                    if (win32Error == 122 /*ERROR_INSUFFICIENT_BUFFER*/)
                    {
                        userNamePtr = Marshal.ReAllocCoTaskMem(userNamePtr, userNameSize);
                        domainNamePtr = Marshal.ReAllocCoTaskMem(domainNamePtr, domainNameSize);
                        passwordPtr = Marshal.ReAllocCoTaskMem(passwordPtr, passwordSize);
                        result = CredUnPackAuthenticationBuffer(
                            (decryptProtectedCredentials ? 0x1 : 0x0),
                            authBufferPtr,
                            authBufferSize,
                            userNamePtr,
                            ref userNameSize,
                            domainNamePtr,
                            ref domainNameSize,
                            passwordPtr,
                            ref passwordSize);
                        if (!result)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(win32Error);
                    }

                    return new PromptCredentialsSecureStringResult
                    {
                        UserName = PtrToSecureString(userNamePtr, userNameSize),
                        DomainName = PtrToSecureString(domainNamePtr, domainNameSize),
                        Password = PtrToSecureString(passwordPtr, passwordSize)
                    };
                }
                finally
                {
                    if (userNamePtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(userNamePtr);
                    if (domainNamePtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(domainNamePtr);
                    if (passwordPtr != IntPtr.Zero) Marshal.ZeroFreeCoTaskMemUnicode(passwordPtr);
                }
            }

            #region Utility Methods

            public static SecureString PtrToSecureString(IntPtr p)
            {
                SecureString s = new SecureString();
                int i = 0;
                while (true)
                {
                    char c = (char)Marshal.ReadInt16(p, ((i++) * sizeof(short)));
                    if (c == '\u0000') break;
                    s.AppendChar(c);
                }
                s.MakeReadOnly();
                return s;
            }

            private static SecureString PtrToSecureString(IntPtr p, int length)
            {
                SecureString s = new SecureString();
                for (int i = 0; i < length; i++) s.AppendChar((char)Marshal.ReadInt16(p, i * sizeof(short)));
                s.MakeReadOnly();
                return s;
            }

            #endregion
        }
    }
}