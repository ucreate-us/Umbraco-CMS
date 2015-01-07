﻿using System;
using System.Text;
using System.Xml.XPath;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Security;
using Umbraco.Core.Services;
using Umbraco.Web.Security;

namespace Umbraco.Web.PublishedCache.PublishedNoCache
{
    class PublishedMemberCache : IPublishedMemberCache
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IMemberService _memberService;

        public PublishedMemberCache(IDataTypeService dataTypeService, IMemberService memberService)
        {
            _dataTypeService = dataTypeService;
            _memberService = memberService;
        }

        public IPublishedContent GetByProviderKey(object key)
        {
            var provider = Core.Security.MembershipProviderExtensions.GetMembersMembershipProvider();
            if (provider.IsUmbracoMembershipProvider() == false)
            {
                throw new NotSupportedException("Cannot access this method unless the Umbraco membership provider is active");
            }

            var result = _memberService.GetByProviderKey(key);
            return result == null ? null : new PublishedMember(result).CreateModel();
        }

        public IPublishedContent GetById(int memberId)
        {
            var provider = Core.Security.MembershipProviderExtensions.GetMembersMembershipProvider();
            if (provider.IsUmbracoMembershipProvider() == false)
            {
                throw new NotSupportedException("Cannot access this method unless the Umbraco membership provider is active");
            }

            var result = _memberService.GetById(memberId);
            return result == null ? null : new PublishedMember(result).CreateModel();
        }

        public IPublishedContent GetByUsername(string username)
        {
            var provider = Core.Security.MembershipProviderExtensions.GetMembersMembershipProvider();
            if (provider.IsUmbracoMembershipProvider() == false)
            {
                throw new NotSupportedException("Cannot access this method unless the Umbraco membership provider is active");
            }

            var result = _memberService.GetByUsername(username);
            return result == null ? null : new PublishedMember(result).CreateModel();
        }

        public IPublishedContent GetByEmail(string email)
        {
            var provider = Core.Security.MembershipProviderExtensions.GetMembersMembershipProvider();
            if (provider.IsUmbracoMembershipProvider() == false)
            {
                throw new NotSupportedException("Cannot access this method unless the Umbraco membership provider is active");
            }

            var result = _memberService.GetByEmail(email);
            return result == null ? null : new PublishedMember(result).CreateModel();
        }

        public IPublishedContent GetByMember(IMember member)
        {
            return new PublishedMember(member).CreateModel();
        }

        public XPathNavigator CreateNodeNavigator(int id, bool preview)
        {
            var provider = Core.Security.MembershipProviderExtensions.GetMembersMembershipProvider();
            if (provider.IsUmbracoMembershipProvider() == false)
            {
                throw new NotSupportedException("Cannot access this method unless the Umbraco membership provider is active");
            }

            var result = _memberService.GetById(id);
            if (result == null) return null;

            var exs = new EntityXmlSerializer();
            var s = exs.Serialize(_dataTypeService, result);
            var n = s.GetXmlNode();
            return n.CreateNavigator();
        }
    }
}
