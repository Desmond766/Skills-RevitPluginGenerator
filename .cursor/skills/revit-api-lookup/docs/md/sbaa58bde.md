---
kind: method
id: M:Autodesk.Revit.DB.ModelCurve.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/c723a83a-f97c-0fe3-43e2-d19b29177c62.htm
---
# Autodesk.Revit.DB.ModelCurve.SetVisibility Method

Sets the visibility for the model curve in a family document.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the model curve geometry can be changed for different 
types of views and detail levels in the family document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed, or the model curve is in a project document.

