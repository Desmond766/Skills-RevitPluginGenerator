---
kind: method
id: M:Autodesk.Revit.DB.SymbolicCurve.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/d353f98b-b480-1157-07f8-125960aa29d0.htm
---
# Autodesk.Revit.DB.SymbolicCurve.SetVisibility Method

Sets the visibility for the symbolic curve.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the symbolic curve geometry can be changed for different detail levels.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when visibility is not valid for symbolic curves.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed.

