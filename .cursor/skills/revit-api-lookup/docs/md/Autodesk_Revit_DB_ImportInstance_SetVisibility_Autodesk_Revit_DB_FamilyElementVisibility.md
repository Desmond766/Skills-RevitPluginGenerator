---
kind: method
id: M:Autodesk.Revit.DB.ImportInstance.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/70d39629-0341-d1bc-58ed-b0d37200f693.htm
---
# Autodesk.Revit.DB.ImportInstance.SetVisibility Method

Sets the visibility for the import instance in a family document.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the import instance geometry can be changed for different 
types of views and detail levels in the family document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed, or the import instance is in a project document.

