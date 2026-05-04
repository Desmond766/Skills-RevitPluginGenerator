---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalService.SupportActivation
source: html/28169f98-6599-d6f1-a4cb-8a3bd69a3ecc.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.SupportActivation Property

Indicates if the service supports activation/deactivation of the servers.

## Syntax (C#)
```csharp
public bool SupportActivation { get; }
```

## Remarks
If this option is set to false, for a single-server only one added(registered)
 will be considered active.
 In case of a multi-server service multiple servers cand be added(registered) and
 all of them will be considered to be active. An attempt to change the activation state of the servers will lead to an exception.

