namespace Read.Domain
{
    public struct PathResult<T>
    {
        public string Path { get; set; }
        public T Result { get; set; }
    }
}
