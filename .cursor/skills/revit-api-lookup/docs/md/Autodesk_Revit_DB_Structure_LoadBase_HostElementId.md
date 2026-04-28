---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadBase.HostElementId
source: html/c0fc581d-431e-0749-e7d9-7218e9b426c8.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.HostElementId Property

The host element ID for the load.

## Syntax (C#)
```csharp
public ElementId HostElementId { get; }
```

## Remarks
If the load is hosted this is the id of the Analytical Element that hosts the load. If the load is not hosted, InvalidElementId is returned.

