---
kind: method
id: M:Autodesk.Revit.DB.GeometryElement.GetTransformed(Autodesk.Revit.DB.Transform)
source: html/549182ac-29d1-1482-efff-6ab0a8525227.htm
---
# Autodesk.Revit.DB.GeometryElement.GetTransformed Method

Returns a transformed copy of the geometry in this element.

## Syntax (C#)
```csharp
public GeometryElement GetTransformed(
	Transform transform
)
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation to apply to the geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Transform is not conformal

