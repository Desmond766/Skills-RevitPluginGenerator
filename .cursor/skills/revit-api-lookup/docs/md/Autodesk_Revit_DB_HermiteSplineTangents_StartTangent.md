---
kind: property
id: P:Autodesk.Revit.DB.HermiteSplineTangents.StartTangent
source: html/efb65141-528e-73b4-57a9-e4ed1700236f.htm
---
# Autodesk.Revit.DB.HermiteSplineTangents.StartTangent Property

The tangent vector at the start of the curve.

## Syntax (C#)
```csharp
public XYZ StartTangent { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: startTangent is not length 1.0.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The start tangent value is not set.

