﻿using Atomia.Store.PublicBillingApi.Handlers;
using System.Collections.Generic;

namespace Atomia.Store.PublicOrderHandlers.CartItemHandlers
{
    /// <summary>
    /// Amend order with items in cart that have category "OwnDomain"
    /// </summary>
    public class OwnDomainHandler : BaseDomainHandler
    {
        /// <summary>
        /// Handle items with category "OwnDomain"
        /// </summary>
        public override IEnumerable<string> HandledCategories
        {
            get { return new[] { "OwnDomain" }; }
        }

        /// <summary>
        /// Use "CsDomainParking" service by default for packages with same domain name as handled OwnDomain item.
        /// </summary>
        public override string DefaultAtomiaService
        {
            get { return "CsDomainParking"; }
        }

        /// <summary>
        /// Get domain name with any "www" prefix removed
        /// </summary>
        protected override string GetDomainName(ItemData domainItem)
        {
            var baseDomainName = base.GetDomainName(domainItem);
            var domainName = baseDomainName.StartsWith("www")
                ? baseDomainName.Remove(0, 4)
                : baseDomainName;

            return domainName;
        }

        /// <summary>
        /// Use "CsLinuxWebsite" for connected packages that are allowed to have website, otherwise the default "CsDomainParking"
        /// </summary>
        protected override string GetAtomiaService(ItemData connectedItem)
        {
            if (IsHostingPackageWithWebsitesAllowed(connectedItem))
            {
                return "CsLinuxWebsite";
            }

            return DefaultAtomiaService;
        }
    }
}
