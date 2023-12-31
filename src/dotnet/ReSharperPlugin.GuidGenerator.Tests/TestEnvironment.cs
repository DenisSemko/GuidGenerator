﻿using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace ReSharperPlugin.GuidGenerator.Tests
{
    [ZoneDefinition]
    public class GuidGeneratorTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<IGuidGeneratorZone> { }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<GuidGeneratorTestEnvironmentZone> { }

    [SetUpFixture]
    public class GuidGeneratorTestsAssembly : ExtensionTestEnvironmentAssembly<GuidGeneratorTestEnvironmentZone> { }
}
