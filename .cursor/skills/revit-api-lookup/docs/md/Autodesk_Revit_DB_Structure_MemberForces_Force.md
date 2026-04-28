---
kind: property
id: P:Autodesk.Revit.DB.Structure.MemberForces.Force
source: html/01666445-f181-4fc1-2f93-1ae13acbc1c6.htm
---
# Autodesk.Revit.DB.Structure.MemberForces.Force Property

The translational forces at relative point position of the element.

## Syntax (C#)
```csharp
public XYZ Force { get; set; }
```

## Remarks
The x value of XYZ object represents moment about x-axis of the analytical element coordinate system, y about y-axis, z about z-axis respectively.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

