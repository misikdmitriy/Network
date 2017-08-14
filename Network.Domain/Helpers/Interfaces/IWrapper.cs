namespace Network.Domain.Helpers.Interfaces
{
    /// <summary>
    /// Object wrapper
    /// </summary>
    /// <typeparam name="T">Type name</typeparam>
    public interface IWrapper<T>
    {
        /// <summary>
        /// Unwrap object
        /// </summary>
        /// <returns>Wrapped object</returns>
        T Unwrap();
        /// <summary>
        /// Wrap object
        /// </summary>
        /// <param name="wrapped">Wrapped object</param>
        void Wrap(T wrapped);
    }
}
