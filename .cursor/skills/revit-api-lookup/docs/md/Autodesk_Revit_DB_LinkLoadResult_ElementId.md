---
kind: property
id: P:Autodesk.Revit.DB.LinkLoadResult.ElementId
source: html/fbbd2c3a-435f-faa2-4284-4cf29b6fb1a2.htm
---
# Autodesk.Revit.DB.LinkLoadResult.ElementId Property

The id of the created or loaded linked model.

## Syntax (C#)
```csharp
public ElementId ElementId { get; }
```

## Remarks
This may be invalidElementId if there were errors
 (for example, LinkLoadResultType.SameModelAsHost
 causes no link to be created).

