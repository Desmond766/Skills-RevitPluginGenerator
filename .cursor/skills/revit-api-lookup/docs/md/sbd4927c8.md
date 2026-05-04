---
kind: property
id: P:Autodesk.Revit.DB.AreaVolumeSettings.ComputeVolumes
source: html/254e3348-0153-b766-b45c-cfcbc9f52d72.htm
---
# Autodesk.Revit.DB.AreaVolumeSettings.ComputeVolumes Property

True to enable volume computation. False to disable it.

## Syntax (C#)
```csharp
public bool ComputeVolumes { get; set; }
```

## Remarks
When this setting is False, rooms and spaces will be treated as simple extrusions of their 2d boundaries.
 The volume parameter will report "not computed".
 When this setting is True, the geometry of rooms and spaces will be trimmed
 when it intersects elements such as ceilings, roofs, and floors.

