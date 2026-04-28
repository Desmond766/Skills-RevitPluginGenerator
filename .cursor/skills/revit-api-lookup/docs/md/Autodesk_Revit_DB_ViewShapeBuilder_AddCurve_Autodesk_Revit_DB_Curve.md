---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.AddCurve(Autodesk.Revit.DB.Curve)
source: html/f58d323e-97a7-6bae-5bbe-ef3af1213dcd.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.AddCurve Method

Add a curve to the GRep associated to this ViewShapeBuilder.

## Syntax (C#)
```csharp
public void AddCurve(
	Curve GCurve
)
```

## Parameters
- **GCurve** (`Autodesk.Revit.DB.Curve`) - The curve to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - GCurve is not acceptable for view-specific shape representation that is currently being built.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

