---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.GetEndReference(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/0d5d008a-5317-357f-e4d4-46d8a745a494.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.GetEndReference Method

Returns a reference to the end of a framing element according to the setback settings.

## Syntax (C#)
```csharp
public static Reference GetEndReference(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete and joined.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Returns
The end reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category or is concrete or is not joined at given end and cannot have an end reference set.

