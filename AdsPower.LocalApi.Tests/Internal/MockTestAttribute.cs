namespace AdsPower.LocalApi.Tests.Internal;

using NUnit.Framework;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal class MockTestAttribute : CategoryAttribute;