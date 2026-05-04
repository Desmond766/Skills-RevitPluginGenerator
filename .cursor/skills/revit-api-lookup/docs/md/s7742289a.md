---
kind: property
id: P:Autodesk.Revit.DB.HermiteSplineTangents.EndTangent
source: html/7bf74e3d-bd54-c348-2bda-b3ebf8d9e4ce.htm
---
# Autodesk.Revit.DB.HermiteSplineTangents.EndTangent Property

The tangent vector at the end of the curve.

## Syntax (C#)
```csharp
public XYZ EndTangent { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: endTangent has zero length.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The end tangent value is not set.

