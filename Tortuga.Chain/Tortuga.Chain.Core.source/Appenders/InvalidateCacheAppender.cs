#if !WINDOWS_UWP
using System;
using System.Threading;
using System.Threading.Tasks;
using Tortuga.Chain.DataSources;

namespace Tortuga.Chain.Appenders
{
    /// <summary>
    /// Causes the cache to be invalidated when this operation is executed.
    /// </summary>
    internal sealed class InvalidateCacheAppender : Appender
    {
        private readonly string m_CacheKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidateCacheAppender{TResult}"/> class.
        /// </summary>
        /// <param name="previousLink">The previous link.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <exception cref="ArgumentNullException">previousLink;previousLink is null.</exception>
        /// <exception cref="ArgumentException">cacheKey is null or empty.;cacheKey</exception>
        public InvalidateCacheAppender(ILink previousLink, string cacheKey) : base(previousLink)
        {
            if (string.IsNullOrEmpty(cacheKey))
                throw new ArgumentException("cacheKey is null or empty.", "cacheKey");

            m_CacheKey = cacheKey;
        }

        /// <summary>
        /// Execute the operation synchronously.
        /// </summary>
        /// <param name="state">User defined state, usually used for logging.</param>
        public override void Execute(object state = null)
        {
            ((DataSource)DataSource).InvalidateCache(m_CacheKey);

            PreviousLink.Execute(state);
        }

        /// <summary>
        /// Execute the operation asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="state">User defined state, usually used for logging.</param>
        /// <returns></returns>
        public override async Task ExecuteAsync(CancellationToken cancellationToken, object state = null)
        {
            ((DataSource)DataSource).InvalidateCache(m_CacheKey);

            await PreviousLink.ExecuteAsync(state).ConfigureAwait(false);
        }
    }
}
#endif