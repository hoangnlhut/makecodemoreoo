using System.Reflection.Metadata.Ecma335;

namespace FocusDomainLogicSequences
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }

    public class PainterA : IPainter
    {
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters)
        {
            return sqMeters * 2;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return new TimeSpan(1, 1, 1);
        }
    }

    public class PainterB : IPainter
    {
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters)
        {
            return sqMeters * 3;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return new TimeSpan(1, 1, 1);
        }
    }

    public class PainterC : IPainter
    {
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters)
        {
            return sqMeters * 4;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return new TimeSpan(1, 1, 1);
        }
    }
}