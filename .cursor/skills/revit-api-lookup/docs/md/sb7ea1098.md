---
kind: property
id: P:Autodesk.Revit.DB.SolidOrShellTessellationControls.MinAngleInTriangle
source: html/720f75c5-8a11-bfc6-d698-a200ffc28be9.htm
---
# Autodesk.Revit.DB.SolidOrShellTessellationControls.MinAngleInTriangle Property

A non-negative real number specifying the minimum allowed angle for any triangle in the triangulation, in radians.

## Syntax (C#)
```csharp
public double MinAngleInTriangle { get; set; }
```

## Remarks
A small value can be useful when triangulating long, thin objects, in order to keep the number of triangles
 small, but it can result in long, thin triangles, which are not acceptable for all applications. If the value
 is too large, this constraint may not be satisfiable, causing the triangulation to fail. This constraint may be
 approximately enforced. A value of 0 means to ignore the minimum angle constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for minAngleInTriangle must be at least 0 and less than 60 degrees, expressed in radians. The value 0 means to ignore the minimum angle constraint.

