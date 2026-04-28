---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.SupportActivation
source: html/fd61e375-683b-57e1-c902-29a5fe74e7d5.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.SupportActivation Property

Indicates if the service supports activation/deactivation of the servers.

## Syntax (C#)
```csharp
public bool SupportActivation { get; set; }
```

## Remarks
If this option is set to true servers can be activated/deactivated. If this option is set to false, for a single-server only one server
 can be added(registered) and will be considered active.
 In case of a multi-server service multiple servers cand be added(registered) and
 all of them will be considered active. An attempt to activate/deactivate the
 servers will lead to an exception. A service for which SupportActivation is set to false, can't be recordable and self-synchronizing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A service that doesn't support activation should not be recordable and/or self-syncronizing.

