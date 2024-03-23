using System.Collections.Generic;

[System.Serializable]
public class Data
{
    public int minutes;
    public int seconds;
    public int fillerCount;
    public int notesCount;
    public int averagePulse;
    public int maxPulse;
    public int minPulse;

    public Data(int minutes, int seconds, int averagePulse, int maxPulse, int minPulse, int fillerCount, int notesCount)
    {
        this.minutes = minutes;
        this.seconds = seconds;
        this.averagePulse = averagePulse;
        this.maxPulse = maxPulse;
        this.minPulse = minPulse;
        this.fillerCount = fillerCount;
        this.notesCount = notesCount;
    }
}