---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadBase.WorkPlaneId
source: html/19d3d2d4-82e9-465a-5cf4-d3e613ad238f.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.WorkPlaneId Property

Id of the work plane which may determine the orientation of the load.

## Syntax (C#)
```csharp
public ElementId WorkPlaneId { get; }
```

## Remarks
The load might be oriented to be perpendicular to this work plane. Determine how load is oriented by checking OrientTo .

