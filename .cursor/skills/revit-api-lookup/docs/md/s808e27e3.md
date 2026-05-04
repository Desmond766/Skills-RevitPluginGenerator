---
kind: property
id: P:Autodesk.Revit.DB.ViewShapeBuilder.ViewNormal
source: html/a58d3c20-3181-899b-c583-98f2f9c94713.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.ViewNormal Property

Normal of the view that will display the shape being built. Must be set explicitly before adding any geometry. Must be a unit vector.
 This is used to validate incoming geometry - it must be orthogonal to the viewNormal.

## Syntax (C#)
```csharp
public XYZ ViewNormal { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: viewNormal is not length 1.0.

