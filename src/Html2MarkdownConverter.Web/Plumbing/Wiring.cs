﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Html2MarkdownConverter.Web.Models.Converter;
using Html2MarkdownConverter.Web.Models.MetaData;

namespace Html2MarkdownConverter.Web.Plumbing
{
	public class Wiring : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IConverter>()
				.ImplementedBy<MarkdownConverter>()
				.LifeStyle.Transient,
				Component.For<IMeta>()
				.ImplementedBy<Meta>()
				.LifeStyle.Transient
				);
		}
	}
}