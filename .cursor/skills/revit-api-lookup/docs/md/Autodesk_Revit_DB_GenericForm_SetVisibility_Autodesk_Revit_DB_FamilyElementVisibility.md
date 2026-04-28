---
kind: method
id: M:Autodesk.Revit.DB.GenericForm.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/18f097f0-2f17-6140-834f-ec513867cab8.htm
---
# Autodesk.Revit.DB.GenericForm.SetVisibility Method

Sets the visibility for the generic form.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the generic form geometry can be changed for different 
types of views and detail levels in the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed.

