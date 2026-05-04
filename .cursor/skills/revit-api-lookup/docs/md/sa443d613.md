---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.IsValidSectionTypeId(Autodesk.Revit.DB.ElementId)
source: html/21bdce0b-2f56-3b30-6ce3-3702c9b0387e.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.IsValidSectionTypeId Method

Checks whether the family symbol id is allowed for
 Analytical Member as Section Type property.

## Syntax (C#)
```csharp
public bool IsValidSectionTypeId(
	ElementId familySymbolId
)
```

## Parameters
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`) - Family symbol id which has to be checked.

## Returns
True if %familySymbolId% is invalidElementId; or if it is
 the id of a FamilySymbol of category "Structural Framing"
 (OST_StructuralFraming) or "Structural Columns" (OST_StructuralColumns)
 Returns false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

