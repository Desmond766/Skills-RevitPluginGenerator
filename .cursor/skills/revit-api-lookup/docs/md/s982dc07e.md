---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.SingleServerService.UnsetActiveServer(Autodesk.Revit.DB.Document)
source: html/58a704c0-d372-3ab1-60af-041575e8ddd4.htm
---
# Autodesk.Revit.DB.ExternalService.SingleServerService.UnsetActiveServer Method

Unset the active server for the particular document.

## Syntax (C#)
```csharp
public void UnsetActiveServer(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`)

## Remarks
After unsetting the active server, the document will be using the
 application-wide active server, if one was already set.
Note it is not possible to unset a server that acts as an application-wide
 active server for a service. On the other hand, there should be no reason
 to ever do so, for each and every registered service should have (ideally)
 an active server set applicatiton-wide.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to false
 calling this method will throw exception. For this kind of service only one server can be added,
 and it will be marked by default as an application-wide active server.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 For a service that doesn't support activation, the servers can't be activated/deactivated.

