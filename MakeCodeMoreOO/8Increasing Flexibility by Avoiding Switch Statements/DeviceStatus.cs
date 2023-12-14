namespace _8IncreasingFlexibilitybyAvoidingSwitchStatements
{

    //[Flags]  old way to using enum
    //public enum DeviceStatus
    //{
    //    AllFine = 0,
    //    NotOperational = 1,
    //    VisiblyDamaged = 2,
    //    CircuitryFailed = 4
    //}

    sealed class DeviceStatus : IEquatable<DeviceStatus>
    {
        [Flags]
        private enum StatusRepresentation
        {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitryFailed = 4
        }

        private StatusRepresentation Representation { get; }

        private DeviceStatus(StatusRepresentation representation)
        {
            Representation = representation;
        }

        public static DeviceStatus AllFine() => new DeviceStatus(StatusRepresentation.AllFine);

        public DeviceStatus WithVisibleDamage() => new DeviceStatus(StatusRepresentation.VisiblyDamaged | Representation);

        public DeviceStatus NotOperational() => new DeviceStatus(Representation | StatusRepresentation.NotOperational);

        public DeviceStatus Repaired() => new DeviceStatus(Representation & ~StatusRepresentation.NotOperational);

        public DeviceStatus CircuitryFailed() => new DeviceStatus(Representation | StatusRepresentation.CircuitryFailed);

        public DeviceStatus CircuitryReplaced() => new DeviceStatus(Representation & ~StatusRepresentation.CircuitryFailed);

        public bool Equals(DeviceStatus? other)
         => other != null && Representation == other.Representation;
        public override int GetHashCode() => (int)Representation;

        public override bool Equals(object? obj) => Equals(obj as DeviceStatus);
        public static bool operator ==(DeviceStatus? left, DeviceStatus? right)
            => (ReferenceEquals(left, null) && ReferenceEquals(right, null)) || (!ReferenceEquals(left, null) && left.Equals(right));

        public static bool operator !=(DeviceStatus? left, DeviceStatus? right) => !(left == right);    
    }
}