---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.IExternalService
source: html/37fe86a0-0668-5908-9966-dfac0e0c1fe3.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService

The base interface class for all external services.

## Syntax (C#)
```csharp
public interface IExternalService
```

## Remarks
Both supported kinds of services - single-server and multi-server - will derive their classes
 from this interface, albeit indirectly through an interface specific to the particular kind.
 External services never derive directly from this class - they always have to derive from
 either ISingleServerService or IMultiServerService, respectivelly.

