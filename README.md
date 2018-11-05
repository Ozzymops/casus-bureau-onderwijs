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

### Database
1. Download het .bak bestand - https://drive.google.com/open?id=1Y6YrYevyeV7TnCaLGK5tHP5JIRjjA_xt
2. Open SQL Server Management Studio.
3. Klik met de rechtermuisknop op het foldertje 'Databases' in je huidige sessie.
4. Selecteer 'Restore Database'.
5. Kies bij Source het bolletje 'Device:' en druk op de drie puntjes [...]
6. Klik op 'Add' en blader naar uw Downloads folder of waar het .bak bestand ook staat.
7. Selecteer het .bak bestand en druk op 'Ok'. Klik nog eens op 'Ok' en wacht tot de database klaar staat.
