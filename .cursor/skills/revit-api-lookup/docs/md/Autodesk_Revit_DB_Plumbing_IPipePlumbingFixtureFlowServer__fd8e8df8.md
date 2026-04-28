---
kind: type
id: T:Autodesk.Revit.DB.Plumbing.IPipePlumbingFixtureFlowServer
source: html/ef369072-84eb-cace-a564-335aed35626b.htm
---
# Autodesk.Revit.DB.Plumbing.IPipePlumbingFixtureFlowServer

Interface class for external servers implementing Pipe plumbing fixture flow calculation.

## Syntax (C#)
```csharp
public interface IPipePlumbingFixtureFlowServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server for the plumbing flow conversion in PipeSettings .

