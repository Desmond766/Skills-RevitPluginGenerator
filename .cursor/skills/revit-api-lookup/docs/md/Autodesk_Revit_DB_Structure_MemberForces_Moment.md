---
kind: property
id: P:Autodesk.Revit.DB.Structure.MemberForces.Moment
source: html/f9241cfe-ddf5-26d0-a72c-cc8458a53249.htm
---
# Autodesk.Revit.DB.Structure.MemberForces.Moment Property

The rotational forces at relative point position of the element.

## Syntax (C#)
```csharp
public XYZ Moment { get; set; }
```

## Remarks
The x value of XYZ object represents moment about x-axis of the analytical element coordinate system, y about y-axis, z about z-axis respectively.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

