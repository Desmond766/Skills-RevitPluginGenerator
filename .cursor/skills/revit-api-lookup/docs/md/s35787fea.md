---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.SetEndReference(Autodesk.Revit.DB.FamilyInstance,System.Int32,Autodesk.Revit.DB.Reference)
source: html/a694033f-eb4f-45bb-d989-8bc95780e574.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.SetEndReference Method

Sets the end reference of a framing element.

## Syntax (C#)
```csharp
public static void SetEndReference(
	FamilyInstance familyInstance,
	int end,
	Reference pick
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete and joined.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).
- **pick** (`Autodesk.Revit.DB.Reference`) - The reference to set to the given end.

## Remarks
The setback value will be changed as a result of the removal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category or is concrete or is not joined at given end and cannot have an end reference set.
 -or-
 The input pick cannot be set as the end reference for the given end of the structural framing element.

