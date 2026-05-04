---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.CanSetEndReference(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/9f9ebfc9-9ded-ce00-41ba-93e6d7a07265.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.CanSetEndReference Method

Determines if a reference can be set for the given end of the framing element.

## Syntax (C#)
```csharp
public static bool CanSetEndReference(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete and joined at the given end.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Returns
True if reference can be set for the given end of the framing element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

