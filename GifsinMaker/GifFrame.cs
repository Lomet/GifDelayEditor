﻿using System.Drawing;

namespace GifsineMaker;
public class GifFrame
{
    public GifFrame(Image frame, int delay)
    {
        if (frame == null) throw new NullReferenceException(nameof(frame));
        Frame = frame;
        Delay = delay;
    }
    public Image Frame { get; set; }
    public int Delay { get; set; }
}