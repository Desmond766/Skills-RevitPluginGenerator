---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralFramingUtils.CanFlipEnds(Autodesk.Revit.DB.FamilyInstance)
source: html/4c693589-fefa-3f9d-51dd-69a29623def0.htm
---
# Autodesk.Revit.DB.Structure.StructuralFramingUtils.CanFlipEnds Method

Determines if the ends of the given framing element can be flipped.

## Syntax (C#)
```csharp
public static bool CanFlipEnds(
	FamilyInstance familyInstance
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance, which must be of a structural framing category, non-concrete.

## Returns
True for non-concrete line, arc or ellipse framing element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

