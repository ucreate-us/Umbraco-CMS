﻿using Umbraco.Web.PublishedCache.XmlPublishedCache;

namespace Umbraco.Web.PublishedCache.PublishedNoCache
{
    /// <summary>
    /// Provides caches (content and media).
    /// </summary>
    class PublishedCaches : IPublishedCaches
    {
        private readonly PublishedContentCache _contentCache;
        private readonly PublishedMediaCache _mediaCache;
        private readonly PublishedMemberCache _memberCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishedCaches"/> class with a content cache
        /// and a media cache.
        /// </summary>
        public PublishedCaches(PublishedContentCache contentCache, PublishedMediaCache mediaCache, PublishedMemberCache memberCache)
        {
            _contentCache = contentCache;
            _mediaCache = mediaCache;
            _memberCache = memberCache;
        }

        /// <summary>
        /// Gets the <see cref="IPublishedContentCache"/>.
        /// </summary>
        public IPublishedContentCache ContentCache
        {
            get { return _contentCache; }
        }

        /// <summary>
        /// Gets the <see cref="IPublishedMediaCache"/>.
        /// </summary>
        public IPublishedMediaCache MediaCache
        {
            get { return _mediaCache; }
        }

        /// <summary>
        /// Gets the <see cref="IPublishedMemberCache"/>.
        /// </summary>
        public IPublishedMemberCache MemberCache
        {
            get { return _memberCache; }
        }

        /// <summary>
        /// Resynchronizes caches with their corresponding repositories.
        /// </summary>
        public void Resync()
        {
            // NoCache is fully sync, nothing to resync
        }
    }
}
