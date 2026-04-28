---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.AllowJoinAtEnd(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/dab802b2-9731-94b6-3e56-f584d6f19676.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.AllowJoinAtEnd Method

Sets the indicated end of the framing element to be allowed to join to others.

## Syntax (C#)
```csharp
public static void AllowJoinAtEnd(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Remarks
If that end is near other elements it will become joined as a result.
 By default all framing elements are allowed to join at ends, so this function is only needed if this element end is already disallowed to join.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category.

