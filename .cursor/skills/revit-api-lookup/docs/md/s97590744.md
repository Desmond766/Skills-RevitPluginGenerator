---
kind: property
id: P:Autodesk.Revit.DB.LocationPoint.Rotation
source: html/43aea45e-dd1c-6a35-2fd5-1f99356708df.htm
---
# Autodesk.Revit.DB.LocationPoint.Rotation Property

The angle of rotation around the insertion point, in radians.

## Syntax (C#)
```csharp
public double Rotation { get; }
```

## Remarks
For view-based elements, the rotation angle is in the plane of the associated view. For model elements, 
the rotation angle is measured relative to the default coordinate system. This property is not supported for
some elements supporting LocationPoints, such as AssemblyInstances, Groups, ModelText, Room, and SpotDimensions.

