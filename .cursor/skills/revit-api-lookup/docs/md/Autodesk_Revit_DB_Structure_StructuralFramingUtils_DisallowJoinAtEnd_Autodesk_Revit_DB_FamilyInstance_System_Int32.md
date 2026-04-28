---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.DisallowJoinAtEnd(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/6ea65e8b-45f6-afc6-ec04-de60fc248f17.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.DisallowJoinAtEnd Method

Sets the indicated end of the framing element to not be allowed to join to others.

## Syntax (C#)
```csharp
public static void DisallowJoinAtEnd(
	FamilyInstance familyInstance,
	int end
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category.
- **end** (`System.Int32`) - The index of the end (0 for the start, 1 for the end).

## Remarks
If this framing element is already joined at this end, it will become disconnected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category.

