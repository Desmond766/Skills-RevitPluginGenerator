---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.RemoveEndReference(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/3f6f9b7f-9227-9be5-eaad-fd8e0ce803ea.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.RemoveEndReference Method

Resets the end reference of the structural framing element.

## Syntax (C#)
```csharp
public static void RemoveEndReference(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete and joined.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Remarks
The setback value will be changed as a result of the removal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category or is concrete or is not joined at given end and cannot have an end reference set.

