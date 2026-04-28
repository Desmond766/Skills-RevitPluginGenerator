---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.IsJoinAllowedAtEnd(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/90e1b29d-7e8f-428d-3d88-4a80560b455a.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.IsJoinAllowedAtEnd Method

Identifies if the indicated end of the framing element is allowed to join to others.

## Syntax (C#)
```csharp
public static bool IsJoinAllowedAtEnd(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Returns
True if it is allowed to join. False if it is disallowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category.

