---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionType.SetFamilySymbolId(Autodesk.Revit.DB.ElementId)
source: html/991f72fc-ef87-281a-4110-a9964d146c35.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionType.SetFamilySymbolId Method

FamilySymbol of the annotation to use for this connection type.

## Syntax (C#)
```csharp
public void SetFamilySymbolId(
	ElementId familySymbolId
)
```

## Parameters
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`)

## Remarks
The FamilySymbol must be of category "Connection Symbols"
 (OST_StructConnectionSymbols) and have its "Apply
 To" parameter set to match the applyTo property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when familySymbolId is the id of some element that is not a
 FamilySymbol, is not of the category "Connection
 Symbols" (OST_StructConnectionSymbols), or has its "Apply
 To" parameter not equal to this type's applyTo property.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

