# casus-bureau-onderwijs
Casus Bureau Onderwijs rooster- en planningsysteem.

## Externe bronnen:
1. MVC3 v. 5.2.6: https://www.nuget.org/packages/Microsoft.AspNet.Mvc/. Dit gebruiken wij voor website gerelateerde functies die niet standaard in Visual Studio beschikbaar zijn.
2. Microsoft .net Compilers (Roslyn): https://www.nuget.org/packages/Microsoft.Net.Compilers/. Dit moest opnieuw geinstalleerd worden om een irritante error tijdens compilatie te verhelpen.

### Hoe te installeren?
1. Open Visual Studio.
2. Open het project.
3. Klik bovenaan op Tools
4. Tools --> NuGet --> Package Manager
5. Typ in:
   Install-Package Microsoft.Aspnet.Mvc
   Install-Package Microsoft.Net.Compilers
