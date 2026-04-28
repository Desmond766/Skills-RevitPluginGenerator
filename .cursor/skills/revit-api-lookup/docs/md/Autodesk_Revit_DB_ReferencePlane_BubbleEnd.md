---
kind: property
id: P:Autodesk.Revit.DB.ReferencePlane.BubbleEnd
source: html/893cba06-2611-bf41-5f59-f5f2959721c7.htm
---
# Autodesk.Revit.DB.ReferencePlane.BubbleEnd Property

The bubble end of the reference plane.

## Syntax (C#)
```csharp
public XYZ BubbleEnd { get; set; }
```

## Remarks
When setting this property, an exception will be thrown if the bubble end is set to almost
 the same point as free end or if the vector from BubbleEnd -> FreeEnd
 is not perpendicular to the normal vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

