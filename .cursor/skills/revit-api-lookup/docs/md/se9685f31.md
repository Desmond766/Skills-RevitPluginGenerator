---
kind: method
id: M:Autodesk.Revit.DB.WireframeBuilder.AddCurve(Autodesk.Revit.DB.Curve)
source: html/79bc72c0-378a-d4a5-bcad-56dd30e4dd73.htm
---
# Autodesk.Revit.DB.WireframeBuilder.AddCurve Method

Add a curve to the shape representation stored in this WireframeBuilder.

## Syntax (C#)
```csharp
public void AddCurve(
	Curve GCurve
)
```

## Parameters
- **GCurve** (`Autodesk.Revit.DB.Curve`) - The curve to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - GCurve is not acceptable for a wireframe shape representation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

