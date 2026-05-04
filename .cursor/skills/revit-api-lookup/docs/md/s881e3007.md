---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.FlipEnds(Autodesk.Revit.DB.FamilyInstance)
source: html/014b2cf0-ac59-a087-52e4-efc9cf3062a6.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.FlipEnds Method

Flips the ends of the structural framing element.

## Syntax (C#)
```csharp
public static void FlipEnds(
	FamilyInstance familyInstance
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete.

## Remarks
Only ends of non-concrete structural framing element like beam and brace can be flipped and only in case if it is a line, arc or ellipse element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input familyInstance is concrete or is not a line, arc or ellipse element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input familyInstance is not of a structural framing category.

