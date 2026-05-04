---
kind: method
id: M:Autodesk.Revit.DB.ModelText.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/e7135d6f-f069-7c02-e419-69894d9a30d7.htm
---
# Autodesk.Revit.DB.ModelText.SetVisibility Method

Sets the visibility for the model text in a family document.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the model text geometry can be changed for different 
types of views and detail levels in the family document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed, or the model curve is in a project document.

