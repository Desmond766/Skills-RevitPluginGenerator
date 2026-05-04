---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.IsEndReferenceValid(Autodesk.Revit.DB.FamilyInstance,System.Int32,Autodesk.Revit.DB.Reference)
source: html/6d311cdc-cb7d-92ba-f360-5e5c138efffc.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.IsEndReferenceValid Method

Determines if the given reference can be set for the given end of the framing element.

## Syntax (C#)
```csharp
public static bool IsEndReferenceValid(
	FamilyInstance familyInstance,
	int end,
	Reference pick
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete and joined at the given end.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).
- **pick** (`Autodesk.Revit.DB.Reference`) - The reference to be checked against the given end of the framing element.

## Returns
True if the given reference can be set for the given end of the framing element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

