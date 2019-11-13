***REMOVED***
using System.Windows;
using System.Windows.Interop;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace TypTop.Game.MonoGameControls
***REMOVED***
    public class MonoGameGraphicsDeviceService : IGraphicsDeviceService, IDisposable
    ***REMOVED***
        public MonoGameGraphicsDeviceService()
        ***REMOVED***
    ***REMOVED***
        
        public void Dispose()
        ***REMOVED***
            DeviceDisposing?.Invoke(this, EventArgs.Empty);
            GraphicsDevice.Dispose();
            Direct3DDevice?.Dispose();
            Direct3DContext?.Dispose();
    ***REMOVED***

        public Direct3DEx Direct3DContext ***REMOVED*** get; private set; ***REMOVED***
        public DeviceEx Direct3DDevice ***REMOVED*** get; private set; ***REMOVED***

        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;

        public void StartDirect3D(Window window)
        ***REMOVED***
            Direct3DContext = new Direct3DEx();

            var presentParameters = new PresentParameters
            ***REMOVED***
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                DeviceWindowHandle = new WindowInteropHelper(window).Handle,
                PresentationInterval = SharpDX.Direct3D9.PresentInterval.Default
        ***REMOVED***;

            Direct3DDevice = new DeviceEx(Direct3DContext, 0, DeviceType.Hardware, IntPtr.Zero,
                CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded | CreateFlags.FpuPreserve,
                presentParameters);

            // Create the device using the main window handle, and a placeholder size (1,1).
            // The actual size doesn't matter because whenever we render using this GraphicsDevice,
            // we will make sure the back buffer is large enough for the window we're rendering into.
            // Also, the handle doesn't matter because we call GraphicsDevice.Present(...) with the
            // actual window handle to render into.
            GraphicsDevice = CreateGraphicsDevice(new WindowInteropHelper(window).Handle, 1, 1);
            DeviceCreated?.Invoke(this, EventArgs.Empty);
    ***REMOVED***
        
        // Store the current device settings.
        private PresentationParameters _parameters;

        public GraphicsDevice GraphicsDevice ***REMOVED*** get; private set; ***REMOVED***

        public GraphicsDevice CreateGraphicsDevice(IntPtr windowHandle, int width, int height)
        ***REMOVED***
            _parameters = new PresentationParameters
            ***REMOVED***
                BackBufferWidth = Math.Max(width, 1),
                BackBufferHeight = Math.Max(height, 1),
                BackBufferFormat = SurfaceFormat.Color,
                DepthStencilFormat = DepthFormat.Depth24,
                DeviceWindowHandle = windowHandle,
                PresentationInterval = Microsoft.Xna.Framework.Graphics.PresentInterval.Immediate,
                IsFullScreen = false
        ***REMOVED***;

            return new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, _parameters);
    ***REMOVED***

        /// <summary>
        /// Resets the graphics device to whichever is bigger out of the specified
        /// resolution or its current size. This behavior means the device will
        /// demand-grow to the largest of all its GraphicsDeviceControl clients.
        /// </summary>
        public void ResetDevice(int width, int height)
        ***REMOVED***
            var newWidth = Math.Max(_parameters.BackBufferWidth, width);
            var newHeight = Math.Max(_parameters.BackBufferHeight, height);

            if (newWidth != _parameters.BackBufferWidth || newHeight != _parameters.BackBufferHeight)
            ***REMOVED***
                DeviceResetting?.Invoke(this, EventArgs.Empty);

                _parameters.BackBufferWidth = newWidth;
                _parameters.BackBufferHeight = newHeight;

                GraphicsDevice.Reset(_parameters);

                DeviceReset?.Invoke(this, EventArgs.Empty);
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***