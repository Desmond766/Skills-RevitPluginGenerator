---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.GetOffset
source: html/2e4e45b2-b368-dad8-9dc4-dedb4cddbd0c.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.GetOffset Method

Implement this method to return the offset stored in the point cloud.

## Syntax (C#)
```csharp
XYZ GetOffset()
```

## Returns
The offset vector of this point cloud's coordinate system.

## Remarks
All points are assumed to be offset by the same offset vector. The offset should be
 expressed in the same units as used by the point coordinates (the scale conversion factor
 is not applied). The offset will be used by Revit if the user chooses to place an instance
 relative to another point cloud (the "Auto - Origin To Last Placed" placement option).

