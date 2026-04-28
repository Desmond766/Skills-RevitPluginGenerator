---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetRebarShapeId(Autodesk.Revit.DB.ElementId)
source: html/c4f1bdd6-8b80-28da-a88a-e8eb9139cdd8.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetRebarShapeId Method

Changes the RebarShape element that defines the shape of the rebar.
 Changing the value of this member causes the Rebar instance to choose values for its
 shape parameters to preserve its previous shape as closely as possible

## Syntax (C#)
```csharp
public void SetRebarShapeId(
	ElementId shapeId
)
```

## Parameters
- **shapeId** (`Autodesk.Revit.DB.ElementId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - shapeId is not the id of a RebarShape in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

