using System;

namespace DvaAnalysis.Committees
{
    public enum Committee
    {
        MajorityCommittee,
        WeightedCommittee
    }

    public static class CommitteeExtension
    {
        public static string Prettify(this Committee c)
        {
            switch (c)
            {
                case Committee.MajorityCommittee: return "Majority committee";
                case Committee.WeightedCommittee: return "Weighted committee";
                default: return "No pretty string for committee";
            }
        }

        public static Committee Deprettify(string input)
        {
            switch (input)
            {
                case "Majority committee": return Committee.MajorityCommittee;
                case "Weighted committee": return Committee.WeightedCommittee;
                default: throw new ArgumentException(input + " is not a valid prettified Committee string.");
            }
        }
    }
}