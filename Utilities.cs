namespace Structure
{
    public struct Resources
    {
        public int stone;
        public int wood;
        public int food;
    }

    public enum FieldState
    {
        emptyDesert,
        empty,
        hasBuilding
    }

    public struct Goal
    {
        public WinningCondition winCondition;
        public Resources startingResources;

        public int goalTimeLimit;
        public int goalTimeInterval;
    }

    public enum WinningCondition
    {
        BuildPyramid,
        Gather200Wood,
        Gather100Stone
    }
}

