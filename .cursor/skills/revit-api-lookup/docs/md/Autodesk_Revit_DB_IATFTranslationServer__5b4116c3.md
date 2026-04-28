---
kind: type
id: T:Autodesk.Revit.DB.IATFTranslationServer
source: html/f76b11ae-7465-adca-48f5-1100767becbf.htm
---
# Autodesk.Revit.DB.IATFTranslationServer

Interface class for external servers implementing ATF translation.

## Syntax (C#)
```csharp
public interface IATFTranslationServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry .

