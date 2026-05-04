---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewSymbolicCurve(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.SketchPlane)
source: html/8f00f2e1-3da8-2fdb-aacf-c5fe703d41a5.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewSymbolicCurve Method

Create a symbolic curve in an Autodesk Revit family document.

## Syntax (C#)
```csharp
public SymbolicCurve NewSymbolicCurve(
	Curve curve,
	SketchPlane sketchPlane
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The geometry curve of the newly created symbolic curve.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the symbolic curve.

## Returns
The newly created symbolic curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed.
Thrown when symbolic curve creation failed.

