interface IProgression<T> : IEnumerable<int> where T : IPivot, new() {
    int Limit {get; }
}