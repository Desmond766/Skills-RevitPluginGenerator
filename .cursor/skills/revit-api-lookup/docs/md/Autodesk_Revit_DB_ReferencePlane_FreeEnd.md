---
kind: property
id: P:Autodesk.Revit.DB.ReferencePlane.FreeEnd
source: html/5e62a93d-fc60-35fa-ea6a-007f57cde1b2.htm
---
# Autodesk.Revit.DB.ReferencePlane.FreeEnd Property

The free end of the reference plane.

## Syntax (C#)
```csharp
public XYZ FreeEnd { get; set; }
```

## Remarks
When setting this property, an exception will be thrown if the free end is set to
 almost the same point as bubble end or if the vector from BubbleEnd -> FreeEnd is not perpendicular
 to the normal vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

