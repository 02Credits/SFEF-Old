﻿#region File Description
//-----------------------------------------------------------------------------
// Copyright 2011, Nick Gravelyn.
// Licensed under the terms of the Ms-PL: 
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
//-----------------------------------------------------------------------------
#endregion

using System;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Interop.Arguments
{
    /// <summary>
    /// Arguments used for Device related events.
    /// </summary>
    internal class GraphicsDeviceEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the GraphicsDevice.
        /// </summary>
        public GraphicsDevice GraphicsDevice { get; }

        /// <summary>
        /// Initializes a new GraphicsDeviceEventArgs.
        /// </summary>
        /// <param name="graphicsDevice">The GraphicsDevice associated with the event.</param>
        public GraphicsDeviceEventArgs(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }
    }
}
