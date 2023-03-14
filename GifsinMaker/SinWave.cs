﻿public class GifSineWave
{
    public List<int> Delays { get; set; } = new List<int>();
    public int Sum(int min, int value) => Absalute(min, value).Sum();
    public List<int> Absalute(int min,int value) => Delays.Select(delay => Math.Abs(delay) > min ? Math.Abs(delay) : value).ToList();
    public GifSineWave(int frameCount, double maxDelay = 150, double startAngle =  - 0.5 * Math.PI)
    {
        double period = 2 * Math.PI / frameCount;

        for (int i = 0; i < frameCount; i++)
        {
            double delay = maxDelay * Math.Sin(startAngle + i * period);
            Delays.Add((int)delay);
        }
    }
}