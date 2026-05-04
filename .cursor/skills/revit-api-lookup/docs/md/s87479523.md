---
kind: property
id: P:Autodesk.Revit.DB.PointCloudType.Offset
zh: 偏移、偏移量
source: html/e6e7fa66-77d5-9bd4-e79f-6116494733c7.htm
---
# Autodesk.Revit.DB.PointCloudType.Offset Property

**中文**: 偏移、偏移量

Returns the offset stored in the point cloud.

## Syntax (C#)
```csharp
public XYZ Offset { get; }
```

## Remarks
All points are assumed to be offset by the same offset vector.
 The offset will be used by Revit if the user chooses to place an instance
 relative to another point cloud (the "Auto - Origin To Last Placed" placement option).

