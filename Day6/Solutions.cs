namespace Day6;
using Common;

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

        for (int phase = 0; phase < default(TDuration).Value; phase++)
            population += Advance(phase, ref adult_phase_counts, ref juvenile_phase_counts);

        return population;
    }

    public static ulong Advance(int phase, ref Span<ulong> adultPhaseCounts, ref Span<ulong> juvenilePhaseCounts)
    {
        var (adult_phase, juvenile_phase) = (phase % ADULT_WAVELENGTH, phase % JUVENILE_WAVELENGTH);
        var (born, become_adults) = (adultPhaseCounts[adult_phase], juvenilePhaseCounts[juvenile_phase]);
        adultPhaseCounts[adult_phase] += become_adults;
        born += become_adults;
        juvenilePhaseCounts[juvenile_phase] = born;
        return born;
    }
}
