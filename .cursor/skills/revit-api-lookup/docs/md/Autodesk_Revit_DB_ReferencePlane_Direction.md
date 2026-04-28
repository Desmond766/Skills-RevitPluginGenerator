---
kind: property
id: P:Autodesk.Revit.DB.ReferencePlane.Direction
source: html/8cccbf85-b619-1ded-633d-b75ca403b48a.htm
---
# Autodesk.Revit.DB.ReferencePlane.Direction Property

The direction of the reference plane.

## Syntax (C#)
```csharp
public XYZ Direction { get; set; }
```

## Remarks
When setting this property, an exception will be thrown if the direction vector is not perpendicular to the normal vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: newDir has zero length.

