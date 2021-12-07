namespace Day6;
using Common;
using System.Diagnostics;

public readonly struct LampfishSim<TDuration> : ISolution<ushort, ulong> where TDuration : struct, IValue<TDuration, int>
{
    public int InputDay => 6;

    const int ADULT_WAVELENGTH = 7;
    const int JUVENILE_WAVELENGTH = 9;

    public ulong Evaluate(IEnumerable<ushort> inputs)
    {
        Span<ulong> adult_phase_counts = stackalloc ulong[ADULT_WAVELENGTH];
        Span<ulong> juvenile_phase_counts = stackalloc ulong[JUVENILE_WAVELENGTH];
        ulong population = 0;
        foreach (var item in inputs)
        {
            adult_phase_counts[item]++;
            population++;
        }

        return Simulate(default(TDuration).Value, population, adult_phase_counts, juvenile_phase_counts);        
    }

    public static ulong Simulate(int count, ulong population, Span<ulong> adultPhaseCounts, Span<ulong> juvenilePhaseCounts)
    {
        static ulong Advance(int phase, Span<ulong> adultPhaseCounts, Span<ulong> juvenilePhaseCounts)
        {
            var (adult_phase, juvenile_phase) = (phase % ADULT_WAVELENGTH, phase % JUVENILE_WAVELENGTH);
            var (born, become_adults) = (adultPhaseCounts[adult_phase], juvenilePhaseCounts[juvenile_phase]);
            adultPhaseCounts[adult_phase] += become_adults;
            born += become_adults;
            juvenilePhaseCounts[juvenile_phase] = born;
            return born;
        }

        for (int phase = 0; phase < count; phase++)
            population += Advance(phase, adultPhaseCounts, juvenilePhaseCounts);
        return population;
    }
}
