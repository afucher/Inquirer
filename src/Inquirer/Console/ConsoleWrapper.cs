//-----------------------------------------------------------------------------
// Based On https://gist.github.com/logicseed/f19554d992691233fc74
// C# .NET 4.5 Console Wrapper
//
// Marc King < mjking@umich.edu >
// v1.0 2015-04-26
//-----------------------------------------------------------------------------

using SysConsole = System.Console;
using System;
using System.IO;
using System.Text;
using System.Security;

namespace InquirerCore.Console
{
    class ConsoleWrapper : IConsole
    {
        #region System Console Properties Wrapper

        /// <summary>
        /// Gets or sets the background color of the console.
        /// </summary>
        /// <returns>
        /// A <c>System.ConsoleColor</c> that specifies the background color of the console;
        /// that is, the color that appears behind each character. The default is black.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The color specified in a set operation is not a valid member of <c>System.ConsoleColor</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  ConsoleColor BackgroundColor
        {
            get
            {
                return SysConsole.BackgroundColor;
            }
            set
            {
                SysConsole.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the buffer area.
        /// </summary>
        /// <returns>
        /// The current height, in rows, of the buffer area.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value in a set operation is less than or equal to <c>zero</c>.
        /// -or- 
        /// The value in a set operation is greater than or equal to <c>System.Int16.MaxValue</c>.
        /// -or-
        /// The value in a set operation is less than <c>Custom.ConsoleWrapper.WindowTop + 
        /// Custom.ConsoleWrapper.WindowHeight</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int BufferHeight
        {
            get
            {
                return SysConsole.BufferHeight;
            }
            set
            {
                SysConsole.BufferHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the buffer area.
        /// </summary>
        /// <returns>
        /// The current width, in columns, of the buffer area.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value in a set operation is less than or equal to <c>zero</c>.
        /// -or- 
        /// The value in a set operation is greater than or equal to <c>System.Int16.MaxValue</c>.
        /// -or-
        /// The value in a set operation is less than <c>Custom.ConsoleWrapper.WindowLeft +
        /// Custom.ConsoleWrapper.WindowWidth</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int BufferWidth
        {
            get
            {
                return SysConsole.BufferWidth;
            }
            set
            {
                SysConsole.BufferWidth = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the CAPS LOCK keyboard toggle is turned on
        /// or turned off.
        /// </summary>
        /// <returns>
        /// <c>true</c> if CAPS LOCK is turned on; <c>false</c> if CAPS LOCK is turned off.
        /// </returns>
        public  bool CapsLock
        {
            get
            {
                return SysConsole.CapsLock;
            }
        }

        /// <summary>
        /// Gets or sets the column position of the cursor within the buffer area.
        /// </summary>
        /// <returns>
        /// The current position, in columns, of the cursor.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value in a set operation is less than zero.
        /// -or-
        /// The value in a set operation is greater than or equal to 
        /// <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int CursorLeft
        {
            get
            {
                return SysConsole.CursorLeft;
            }
            set
            {
                SysConsole.CursorLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the cursor within a character cell.
        /// </summary>
        /// <returns>
        /// The size of the cursor expressed as a percentage of the height of a character
        /// cell. The property value ranges from <c>1</c> to <c>100</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value specified in a set operation is less than <c>1</c> or greater than <c>100</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int CursorSize
        {
            get
            {
                return SysConsole.CursorSize;
            }
            set
            {
                SysConsole.CursorSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the row position of the cursor within the buffer area.
        /// </summary>
        /// <returns>
        /// The current position, in rows, of the cursor.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value in a set operation is less than zero.
        /// -or-
        /// The value in a set operation is greater than or equal to 
        /// <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int CursorTop
        {
            get
            {
                return SysConsole.CursorTop;
            }
            set
            {
                SysConsole.CursorTop = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the cursor is visible; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  bool CursorVisible
        {
            get
            {
                return SysConsole.CursorVisible;
            }
            set
            {
                SysConsole.CursorVisible = value;
            }
        }

        /// <summary>
        /// Gets the standard error output stream.
        /// </summary>
        /// <returns>
        /// A <c>System.IO.TextWriter</c> that represents the standard error output stream.
        /// </returns>
        public  TextWriter Error
        {
            get
            {
                return SysConsole.Error;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the console.
        /// </summary>
        /// <returns>
        /// A <c>System.ConsoleColor</c> that specifies the foreground color of the console;
        /// that is, the color of each character that is displayed. The default is gray.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The color specified in a set operation is not a valid member of <c>System.ConsoleColor</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  ConsoleColor ForegroundColor
        {
            get
            {
                return SysConsole.ForegroundColor;
            }
            set
            {
                SysConsole.ForegroundColor = value;
            }
        }

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        /// <returns>
        /// A <c>System.IO.TextReader</c> that represents the standard input stream.
        /// </returns>
        public  TextReader In
        {
            get
            {
                return SysConsole.In;
            }
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to read input.
        /// </summary>
        /// <returns>
        /// The encoding used to read console input.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The property value in a set operation is <c>null</c>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An error occurred during the execution of this operation.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// Your application does not have permission to perform this operation.
        /// </exception>
        public  Encoding InputEncoding
        {
            get
            {
                return SysConsole.InputEncoding;
            }
            set
            {
                SysConsole.InputEncoding = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the error output stream has been redirected
        /// from the standard error stream.
        /// </summary>
        /// <returns>
        /// <c>true</c> if error output is redirected; otherwise, <c>false</c>.
        /// </returns>
        public  bool IsErrorRedirected
        {
            get
            {
                return SysConsole.IsErrorRedirected;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether input has been redirected from the standard
        /// input stream.
        /// </summary>
        /// <returns>
        /// <c>true</c> if input is redirected; otherwise, <c>false</c>.
        /// </returns>
        public  bool IsInputRedirected
        {
            get
            {
                return SysConsole.IsInputRedirected;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether output has been redirected from the standard
        /// output stream.
        /// </summary>
        /// <returns>
        /// <c>true</c> if output is redirected; otherwise, <c>false</c>.
        /// </returns>
        public  bool IsOutputRedirected
        {
            get
            {
                return SysConsole.IsOutputRedirected;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a key press is available in the input stream.
        /// </summary>
        /// <returns>
        /// <c>true</c> if a key press is available; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Standard input is redirected to a file instead of the keyboard.
        /// </exception>
        public  bool KeyAvailable
        {
            get
            {
                return SysConsole.KeyAvailable;
            }
        }

        /// <summary>
        /// Gets the largest possible number of console window rows, based on the current
        /// font and screen resolution.
        /// </summary>
        /// <returns>
        /// The height of the largest possible console window measured in rows.
        /// </returns>
        public  int LargestWindowHeight
        {
            get
            {
                return SysConsole.LargestWindowHeight;
            }
        }

        /// <summary>
        /// Gets the largest possible number of console window columns, based on the
        /// current font and screen resolution.
        /// </summary>
        /// <returns>
        /// The width of the largest possible console window measured in columns.
        /// </returns>
        public  int LargestWindowWidth
        {
            get
            {
                return SysConsole.LargestWindowWidth;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the NUM LOCK keyboard toggle is turned on
        /// or turned off.
        /// </summary>
        /// <returns>
        /// <c>true</c> if NUM LOCK is turned on; <c>false</c> if NUM LOCK is turned off.
        /// </returns>
        public  bool NumberLock
        {
            get
            {
                return SysConsole.NumberLock;
            }
        }

        /// <summary>
        /// Gets the standard output stream.
        /// </summary>
        /// <returns>
        /// A <c>System.IO.TextWriter</c> that represents the standard output stream.
        /// </returns>
        public  TextWriter Out
        {
            get
            {
                return SysConsole.Out;
            }
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to write output.
        /// </summary>
        /// <returns>
        /// The encoding used to write console output.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The property value in a set operation is <c>null</c>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An error occurred during the execution of this operation.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// Your application does not have permission to perform this operation.
        /// </exception>
        public  Encoding OutputEncoding
        {
            get
            {
                return SysConsole.OutputEncoding;
            }
            set
            {
                SysConsole.OutputEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets the title to display in the console title bar.
        /// </summary>
        /// <returns>
        /// The string to be displayed in the title bar of the console. The maximum length
        /// of the title string is <c>24500</c> characters.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// In a get operation, the retrieved title is longer than <c>24500</c> characters.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// In a set operation, the specified title is longer than <c>24500</c> characters.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// In a set operation, the specified title is <c>null</c>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  string Title
        {
            get
            {
                return SysConsole.Title;
            }
            set
            {
                SysConsole.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the combination of the 
        /// <c>System.ConsoleModifiers.Control</c> modifier key and 
        /// <c>System.ConsoleKey.C</c> console key (Ctrl+C) is treated as ordinary
        /// input or as an interruption that is handled by the operating system.
        /// </summary>
        /// <returns>
        /// <c>true</c> if Ctrl+C is treated as ordinary input; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.IO.IOException">
        /// Unable to get or set the input mode of the console input buffer.
        /// </exception>
        public  bool TreatControlCAsInput
        {
            get
            {
                return SysConsole.TreatControlCAsInput;
            }
            set
            {
                SysConsole.TreatControlCAsInput = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the console window area.
        /// </summary>
        /// <returns>
        /// The height of the console window measured in rows.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value of the <c>Custom.ConsoleWrapper.WindowWidth</c> property or 
        /// the value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property is
        /// less than or equal to <c>0</c>.
        /// -or-
        /// The value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property plus
        /// the value of the <c>Custom.ConsoleWrapper.WindowTop</c> property is
        /// greater than or equal to <c>System.Int16.MaxValue</c>.
        /// -or-
        /// The value of the <c>Custom.ConsoleWrapper.WindowWidth</c> property or
        /// the value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property is
        /// greater than the largest possible window width or height for the current
        /// screen resolution and console font.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Error reading or writing information.
        /// </exception>
        public  int WindowHeight
        {
            get
            {
                return SysConsole.WindowHeight;
            }
            set
            {
                SysConsole.WindowHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the leftmost position of the console window area relative to
        /// the screen buffer.
        /// </summary>
        /// <returns>
        /// The leftmost console window position measured in columns.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// In a set operation, the value to be assigned is less than <c>zero</c>.
        /// -or-
        /// As a result of the assignment, <c>Custom.ConsoleWrapper.WindowLeft</c>
        /// plus <c>Custom.ConsoleWrapper.WindowWidth</c> would exceed 
        /// <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Error reading or writing information.
        /// </exception>
        public  int WindowLeft
        {
            get
            {
                return SysConsole.WindowLeft;
            }
            set
            {
                SysConsole.WindowLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the top position of the console window area relative to the
        /// screen buffer.
        /// </summary>
        /// <returns>
        /// The uppermost console window position measured in rows.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// In a set operation, the value to be assigned is less than <c>zero</c>.
        /// -or-
        /// As a result of the assignment, <c>Custom.ConsoleWrapper.WindowTop</c>
        /// plus <c>Custom.ConsoleWrapper.WindowHeight</c> would exceed 
        /// <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Error reading or writing information.
        /// </exception>
        public  int WindowTop
        {
            get
            {
                return SysConsole.WindowTop;
            }
            set
            {
                SysConsole.WindowTop = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the console window.
        /// </summary>
        /// <returns>
        /// The width of the console window measured in columns.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value of the <c>Custom.ConsoleWrapper.WindowWidth</c> property or
        /// the value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property is
        /// less than or equal to <c>0</c>.
        /// -or-
        /// The value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property plus
        /// the value of the <c>Custom.ConsoleWrapper.WindowTop</c> property is greater
        /// than or equal to <c>System.Int16.MaxValue</c>.
        /// -or-
        /// The value of the <c>Custom.ConsoleWrapper.WindowWidth</c> property or 
        /// the value of the <c>Custom.ConsoleWrapper.WindowHeight</c> property is
        /// greater than the largest possible window width or height for the current screen
        /// resolution and console font.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Error reading or writing information.
        /// </exception>
        public  int WindowWidth
        {
            get
            {
                return SysConsole.WindowWidth;
            }
            set
            {
                SysConsole.WindowWidth = value;
            }
        }

        #endregion System Console Properties Wrapper

        #region System Console Events Wrapper

        /// <summary>
        /// Occurs when the <c>System.ConsoleModifiers.Control</c> modifier key (Ctrl) and either
        /// the <c>System.ConsoleKey.C</c> console key (C) or the Break key are pressed simultaneously
        /// (Ctrl+C or Ctrl+Break).
        /// </summary>
        public  event ConsoleCancelEventHandler CancelKeyPress;

        #endregion System Console Events Wrapper

        #region System Console Methods Wrapper

        /// <summary>
        /// Plays the sound of a beep through the console speaker.
        /// </summary>
        /// <exception cref="System.Security.HostProtectionException">
        /// This method was executed on a server, such as SQL Server, that does not permit
        /// access to a user interface.
        /// </exception>
        public  void Beep()
        {
            SysConsole.Beep();
        }

        /// <summary>
        /// Plays the sound of a beep of a specified frequency and duration through the
        /// console speaker.
        /// </summary>
        /// <param name="frequency">
        /// The frequency of the beep, ranging from <c>37</c> to <c>32767</c> hertz.
        /// </param>
        /// <param name="duration">
        /// The duration of the beep measured in milliseconds.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="frequency"/> is less than <c>37</c> or more than <c>32767</c> hertz.
        /// -or-
        /// <paramref name="duration"/> is less than or equal to <c>zero</c>.
        /// </exception>
        /// <exception cref="System.Security.HostProtectionException">
        /// This method was executed on a server, such as SQL Server, that does not permit
        /// access to the console.
        /// </exception>
        [SecuritySafeCritical]
        public  void Beep(int frequency, int duration)
        {
            SysConsole.Beep(frequency, duration);
        }

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information.
        /// </summary>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [SecuritySafeCritical]
        public  void Clear()
        {
            SysConsole.Clear();
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination
        /// area.
        /// </summary>
        /// <param name="sourceLeft">
        /// The leftmost column of the source area.
        /// </param>
        /// <param name="sourceTop">
        /// The topmost row of the source area.
        /// </param>
        /// <param name="sourceWidth">
        /// The number of columns in the source area.
        /// </param>
        /// <param name="sourceHeight">
        /// The number of rows in the source area.
        /// </param>
        /// <param name="targetLeft">
        /// The leftmost column of the destination area.
        /// </param>
        /// <param name="targetTop">
        /// The topmost row of the destination area.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// One or more of the parameters is less than <c>zero</c>.
        /// -or-
        /// <paramref name="sourceLeft"/> or <paramref name="targetLeft"/> is greater 
        /// than or equal to <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// -or-
        /// <paramref name="sourceTop"/> or <paramref name="targetTop"/> is greater than
        /// or equal to <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// -or-
        /// <paramref name="sourceTop"/><c> + </c><paramref name="sourceHeight"/> is 
        /// greater than or equal to <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// -or-
        /// <paramref name="sourceLeft"/><c> + </c><paramref name="sourceWidth"/> is 
        /// greater than or equal to <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred
        /// </exception>
        public  void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth,
            int sourceHeight, int targetLeft, int targetTop)
        {
            SysConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight,
                targetLeft, targetTop);
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination
        /// area.
        /// </summary>
        /// <param name="sourceLeft">
        /// The leftmost column of the source area.
        /// </param>
        /// <param name="sourceTop">
        /// The topmost row of the source area.
        /// </param>
        /// <param name="sourceWidth">
        /// The number of columns in the source area.
        /// </param>
        /// <param name="sourceHeight">
        /// The number of rows in the source area.
        /// </param>
        /// <param name="targetLeft">
        /// The leftmost column of the destination area.
        /// </param>
        /// <param name="targetTop">
        /// The topmost row of the destination area.
        /// </param>
        /// <param name="sourceChar">
        /// The character used to fill the source area.
        /// </param>
        /// <param name="sourceForeColor">
        /// The foreground color used to fill the source area.
        /// </param>
        /// <param name="sourceBackColor">
        /// The background color used to fill the source area.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// One or more of the parameters is less than <c>zero</c>.
        /// -or-
        /// <paramref name="sourceLeft"/> or <paramref name="targetLeft"/> is greater 
        /// than or equal to <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// -or-
        /// <paramref name="sourceTop"/> or <paramref name="targetTop"/> is greater than
        /// or equal to <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// -or-
        /// <paramref name="sourceTop"/><c> + </c><paramref name="sourceHeight"/> is 
        /// greater than or equal to <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// -or-
        /// <paramref name="sourceLeft"/><c> + </c><paramref name="sourceWidth"/> is 
        /// greater than or equal to <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// One or both of the color parameters is not a member of the System.ConsoleColor
        /// enumeration.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred
        /// </exception>
        [SecuritySafeCritical]
        public  void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth,
            int sourceHeight, int targetLeft, int targetTop, char sourceChar,
            ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            SysConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight,
                targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        }

        /// <summary>Acquires the standard error stream.
        /// Returns:
        /// The standard error stream.

        /// <summary>
        /// Acquires the standard error stream.
        /// </summary>
        /// <returns>
        /// The standard error stream.
        /// </returns>
        public  Stream OpenStandardError()
        {
            return SysConsole.OpenStandardError();
        }

        /// <summary>
        /// Acquires the standard error stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">
        /// The internal stream buffer size.
        /// </param>
        /// <returns>
        /// The standard error stream.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="bufferSize"/> is less than or equal to <c>zero</c>.
        /// </exception>
        public  Stream OpenStandardError(int bufferSize)
        {
            return SysConsole.OpenStandardError(bufferSize);
        }

        /// <summary>
        /// Acquires the standard input stream.
        /// </summary>
        /// <returns>
        /// The standard input stream.
        /// </returns>
        public  Stream OpenStandardInput()
        {
            return SysConsole.OpenStandardInput();
        }

        /// <summary>
        /// Acquires the standard input stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">
        /// The internal stream buffer size.
        /// </param>
        /// <returns>
        /// The standard input stream.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="bufferSize"/> is less than or equal to <c>zero</c>.
        /// </exception>
        public  Stream OpenStandardInput(int bufferSize)
        {
            return SysConsole.OpenStandardInput(bufferSize);
        }

        /// <summary>
        /// Acquires the standard output stream.
        /// </summary>
        /// <returns>
        /// The standard output stream.
        /// </returns>
        public  Stream OpenStandardOutput()
        {
            return SysConsole.OpenStandardOutput();
        }

        /// <summary>
        /// Acquires the standard output stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">
        /// The internal stream buffer size.
        /// </param>
        /// <returns>
        /// The standard output stream.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="bufferSize"/> is less than or equal to <c>zero</c>.
        /// </exception>
        public  Stream OpenStandardOutput(int bufferSize)
        {
            return SysConsole.OpenStandardOutput(bufferSize);
        }

        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns>
        /// The next character from the input stream, or negative one (<c>-1</c>) if there are
        /// currently no more characters to be read.
        /// </returns>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  int Read()
        {
            return SysConsole.Read();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed
        /// key is displayed in the console window.
        /// </summary>
        /// <returns>
        /// A <c>System.ConsoleKeyInfo</c> object that describes the <c>System.ConsoleKey</c>
        /// constant and Unicode character, if any, that correspond to the pressed console key.
        /// The <c>System.ConsoleKeyInfo</c> object also describes, in a bitwise combination
        /// of <c>System.ConsoleModifiers</c> values, whether one or more Shift, Alt, or Ctrl
        /// modifier keys was pressed simultaneously with the console key.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The <c>Custom.ConsoleWrapper.In</c> property is redirected from some
        /// stream other than the console.
        /// </exception>
        public  ConsoleKeyInfo ReadKey()
        {
            return SysConsole.ReadKey();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed
        /// key is optionally displayed in the console window.
        /// </summary>
        /// <param name="intercept">
        /// Determines whether to display the pressed key in the console window. <c>true</c>
        /// to not display the pressed key; otherwise, <c>false</c>.
        /// </param>
        /// <returns>
        /// A <c>System.ConsoleKeyInfo</c> object that describes the <c>System.ConsoleKey</c>
        /// constant and Unicode character, if any, that correspond to the pressed console key.
        /// The <c>System.ConsoleKeyInfo</c> object also describes, in a bitwise combination
        /// of <c>System.ConsoleModifiers</c> values, whether one or more Shift, Alt, or Ctrl
        /// modifier keys was pressed simultaneously with the console key.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The <c>Custom.ConsoleWrapper.In</c> property is redirected from some
        /// stream other than the console.
        /// </exception>
        [SecuritySafeCritical]
        public  ConsoleKeyInfo ReadKey(bool intercept)
        {
            return SysConsole.ReadKey(intercept);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>
        /// The next line of characters from the input stream, or <c>null</c> if no more lines
        /// are available.
        /// </returns>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">
        /// There is insufficient memory to allocate a buffer for the returned string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The number of characters in the next line of characters is greater than
        /// <c>System.Int32.MaxValue</c>.
        /// </exception>
        public  string ReadLine()
        {
            return SysConsole.ReadLine();
        }

        /// <summary>
        /// Sets the foreground and background console colors to their defaults.
        /// </summary>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [SecuritySafeCritical]
        public  void ResetColor()
        {
            SysConsole.ResetColor();
        }

        /// <summary>
        /// Sets the height and width of the screen buffer area to the specified values.
        /// </summary>
        /// <param name="width">
        /// The width of the buffer area measured in columns.
        /// </param>
        /// <param name="height">
        /// The height of the buffer area measured in rows.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="height"/> or <paramref name="width"/> is less than or equal 
        /// to <c>zero</c>.
        /// -or-
        /// <paramref name="height"/> or <paramref name="width"/> is greater than or equal
        /// to <c>System.Int16.MaxValue</c>.
        /// -or- 
        /// <paramref name="width"/> is less than <c>Custom.ConsoleWrapper.WindowLeft + 
        /// Custom.ConsoleWrapper.WindowWidth</c>.
        /// -or-
        /// <paramref name="height"/> is less than <c>Custom.ConsoleWrapper.WindowTop + 
        /// Custom.ConsoleWrapper.WindowHeight</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetBufferSize(int width, int height)
        {
            SysConsole.SetBufferSize(width, height);
        }

        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left">
        /// The column position of the cursor.
        /// </param>
        /// <param name="top">
        /// The row position of the cursor.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="left"/> or <paramref name="top"/> is less than <c>zero</c>.
        /// -or-
        /// <paramref name="left"/> is greater than or equal to 
        /// <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// -or-
        /// <paramref name="top"/> is greater than or equal to 
        /// <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetCursorPosition(int left, int top)
        {
            SysConsole.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Sets the <c>Custom.ConsoleWrapper.Error</c> property to the specified 
        /// <c>System.IO.TextWriter</c> object.
        /// </summary>
        /// <param name="newError">
        /// A stream that is the new standard error output.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="newError"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetError(TextWriter newError)
        {
            SysConsole.SetError(newError);
        }

        /// <summary>
        /// Sets the <c>Custom.ConsoleWrapper.In</c> property to the specified 
        /// <c>System.IO.TextReader</c> object.
        /// </summary>
        /// <param name="newIn">
        /// A stream that is the new standard input.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <c>newIn</c> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetIn(TextReader newIn)
        {
            SysConsole.SetIn(newIn);
        }

        /// <summary>
        /// Sets the <c>Custom.ConsoleWrapper.Out</c> property to the specified
        /// <c>System.IO.TextWriter</c> object.
        /// </summary>
        /// <param name="newOut">
        /// A stream that is the new standard output.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <c>newOut</c> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetOut(TextWriter newOut)
        {
            SysConsole.SetOut(newOut);
        }

        /// <summary>
        /// Sets the position of the console window relative to the screen buffer.
        /// </summary>
        /// <param name="left">
        /// The column position of the upper left corner of the console window.
        /// </param>
        /// <param name="top">
        /// The row position of the upper left corner of the console window.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="left"/> or <paramref name="top"/> is less than <c>zero</c>.
        /// -or- 
        /// <paramref name="left"/><c> + Custom.ConsoleWrapper.WindowWidth</c> is greater
        /// than <c>Custom.ConsoleWrapper.BufferWidth</c>.
        /// -or- 
        /// <paramref name="top"/><c> + SCustom.ConsoleWrapper.WindowHeight</c> is greater
        /// than <c>Custom.ConsoleWrapper.BufferHeight</c>.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The user does not have permission to perform this action.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetWindowPosition(int left, int top)
        {
            SysConsole.SetWindowPosition(left, top);
        }

        /// <summary>
        /// Sets the height and width of the console window to the specified values.
        /// </summary>
        /// <param name="width">
        /// The width of the console window measured in columns.
        /// </param>
        /// <param name="height">
        /// The height of the console window measured in rows.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="width"/> or <paramref name="height"/> is less than or equal
        /// to <c>zero</c>.
        /// -or- 
        /// <paramref name="width"/> plus <c>Custom.ConsoleWrapper.WindowLeft</c>
        /// or <paramref name="height"/> plus <c>Custom.ConsoleWrapper.WindowTop</c>
        /// is greater than or equal to <c>System.Int16.MaxValue</c>.
        /// -or-
        /// <paramref name="width"/> or <paramref name="height"/> is greater than the 
        /// largest possible window width or height for the current screen resolution 
        /// and console font.
        /// </exception>
        [SecuritySafeCritical]
        public  void SetWindowSize(int width, int height)
        {
            SysConsole.SetWindowSize(width, height);
        }

        /// <summary>
        /// Writes the text representation of the specified Boolean value to the standard
        /// output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(bool value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the specified Unicode character value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(char value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the specified array of Unicode characters to the standard output stream.
        /// </summary>
        /// <param name="buffer">
        /// A Unicode character array.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(char[] buffer)
        {
            SysConsole.Write(buffer);
        }

        /// <summary>
        /// Writes the text representation of the specified <c>System.Decimal</c> value to 
        /// the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(decimal value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified double-precision floating-point
        /// value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(double value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified single-precision floating-point
        /// value to the standard output stream.</summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(float value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit signed integer value
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(int value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit signed integer value
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(long value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output
        /// stream.
        /// </summary>
        /// <param name="value">
        /// The value to write, or null.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(object value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(string value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit unsigned integer value
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [CLSCompliant(false)]
        public  void Write(uint value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit unsigned integer value
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [CLSCompliant(false)]
        public  void Write(ulong value)
        {
            SysConsole.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output
        /// stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// An object to write using <paramref name="format"/>.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void Write(string format, object arg0)
        {
            SysConsole.Write(format, arg0);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard
        /// output stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg">
        /// An array of objects to write using <paramref name="format"/>.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> or <paramref name="arg"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void Write(string format, params object[] arg)
        {
            SysConsole.Write(format, arg);
        }

        /// <summary>
        /// Writes the specified subarray of Unicode characters to the standard output
        /// stream.
        /// </summary>
        /// <param name="buffer">
        /// An array of Unicode characters.
        /// </param>
        /// <param name="index">
        /// The starting position in buffer.
        /// </param>
        /// <param name="count">
        /// The number of characters to write.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="buffer"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is less than <c>zero</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="index"/> plus <paramref name="count"/> specify a position that
        /// is not within <paramref name="buffer"/>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void Write(char[] buffer, int index, int count)
        {
            SysConsole.Write(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output
        /// stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void Write(string format, object arg0, object arg1)
        {
            SysConsole.Write(format, arg0, arg1);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output
        /// stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <param name="arg2">
        /// The third object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void Write(string format, object arg0, object arg1, object arg2)
        {
            SysConsole.Write(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes the text representation of the specified objects and variable-length
        /// parameter list to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <param name="arg2">
        /// The third object to write using format.
        /// </param>
        /// <param name="arg3">
        /// The fourth object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        [CLSCompliant(false)]
        public  void Write(string format, object arg0, object arg1, object arg2, object arg3)
        {
            SysConsole.Write(format, arg0, arg1, arg2, arg3);
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine()
        {
            SysConsole.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified Boolean value, followed by
        /// the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(bool value)
        {
            SysConsole.WriteLine();
        }

        /// <summary>
        /// Writes the specified Unicode character, followed by the current line terminator,
        /// value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(char value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the specified array of Unicode characters, followed by the current
        /// line terminator, to the standard output stream.
        /// </summary>
        /// <param name="buffer">
        /// A Unicode character array.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(char[] buffer)
        {
            SysConsole.WriteLine(buffer);
        }

        /// <summary>
        /// Writes the text representation of the specified <c>System.Decimal value,</c> 
        /// followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(decimal value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified double-precision floating-point
        /// value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(double value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified single-precision floating-point
        /// value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(float value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit signed integer value,
        /// followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(int value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit signed integer value,
        /// followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(long value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current
        /// line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(object value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator,
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(string value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit unsigned integer value,
        /// followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [CLSCompliant(false)]
        public  void WriteLine(uint value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit unsigned integer value,
        /// followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        [CLSCompliant(false)]
        public  void WriteLine(ulong value)
        {
            SysConsole.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current
        /// line terminator, to the standard output stream using the specified format
        /// information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// An object to write using <paramref name="format"/>.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void WriteLine(string format, object arg0)
        {
            SysConsole.WriteLine(format, arg0);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed
        /// by the current line terminator, to the standard output stream using the specified
        /// format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg">
        /// An array of objects to write using <paramref name="format"/>.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> or <paramref name="arg"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void WriteLine(string format, params object[] arg)
        {
            SysConsole.WriteLine(format, arg);
        }

        /// <summary>
        /// Writes the specified subarray of Unicode characters, followed by the current
        /// line terminator, to the standard output stream.
        /// </summary>
        /// <param name="buffer">
        /// An array of Unicode characters.
        /// </param>
        /// <param name="index">
        /// The starting position in buffer.
        /// </param>
        /// <param name="count">
        /// The number of characters to write.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="buffer"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is less than <c>zero</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="index"/> plus <paramref name="count"/> specify a position that
        /// is not within <paramref name="buffer"/>.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        public  void WriteLine(char[] buffer, int index, int count)
        {
            SysConsole.WriteLine(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of the specified objects, followed by the
        /// current line terminator, to the standard output stream using the specified
        /// format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void WriteLine(string format, object arg0, object arg1)
        {
            SysConsole.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        /// Writes the text representation of the specified objects, followed by the
        /// current line terminator, to the standard output stream using the specified
        /// format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <param name="arg2">
        /// The third object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        public  void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            SysConsole.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes the text representation of the specified objects and variable-length
        /// parameter list, followed by the current line terminator, to the standard
        /// output stream using the specified format information.
        /// </summary>
        /// <param name="format">
        /// A composite format string (see Remarks).
        /// </param>
        /// <param name="arg0">
        /// The first object to write using format.
        /// </param>
        /// <param name="arg1">
        /// The second object to write using format.
        /// </param>
        /// <param name="arg2">
        /// The third object to write using format.
        /// </param>
        /// <param name="arg3">
        /// The fourth object to write using format.
        /// </param>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="format"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// The format specification in <paramref name="format"/> is invalid.
        /// </exception>
        [CLSCompliant(false)]
        public  void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
        {
            SysConsole.WriteLine(format);
        }

        #endregion System Console Methods Wrapper

    }
}