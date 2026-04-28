---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionType.ValidFamilySymbolId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.StructuralConnectionApplyTo,Autodesk.Revit.DB.ElementId)
source: html/16dedf76-e1c9-556a-17d7-8ecdf0385cef.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionType.ValidFamilySymbolId Method

Checks whether the family symbol id is allowed for
 StructuralConnectionTypes with the given value for the applyTo
 property.

## Syntax (C#)
```csharp
public static bool ValidFamilySymbolId(
	Document doc,
	StructuralConnectionApplyTo applyTo,
	ElementId familySymbolId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **applyTo** (`Autodesk.Revit.DB.Structure.StructuralConnectionApplyTo`)
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`)

## Returns
True if %familySymbolId% is invalidElementId; or if it is
 the id of a FamilySymbol of category "Connection
 Symbols" (OST_StructConnectionSymbols) with its "Apply
 To" parameter set to match the applyTo property.
 Returns false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

