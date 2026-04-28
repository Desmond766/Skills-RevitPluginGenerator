---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.HasPathOffset
source: html/7359d833-b9e9-babd-3956-cdd772248303.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.HasPathOffset Property

Whether the circuit path has a valid offset.

## Syntax (C#)
```csharp
public bool HasPathOffset { get; }
```

## Remarks
Circuit path of AllDevices and Custom mode may not have valid offset if the horizontal segments of the path are not at the same height.

