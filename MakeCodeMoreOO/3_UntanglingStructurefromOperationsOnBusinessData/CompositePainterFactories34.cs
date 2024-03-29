﻿namespace _3_UntanglingStructurefromOperationsOnBusinessData
{
    static class CompositePainterFactories34
    {
        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters)
         => new CompositePainter<IPainter>(painters,
             (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters)
        => new CompositePainter<IPainter>(painters,
            (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));


        public static IPainter CombineProportional(IEnumerable<ProportionalPainter> painters)
        => new CombiningPainter4<ProportionalPainter>(painters, new PropotionalPaitingSchedul4());
    }
}