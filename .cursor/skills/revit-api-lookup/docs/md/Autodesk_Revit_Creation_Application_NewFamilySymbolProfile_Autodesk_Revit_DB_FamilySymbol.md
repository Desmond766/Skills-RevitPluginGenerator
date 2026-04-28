---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilySymbolProfile(Autodesk.Revit.DB.FamilySymbol)
source: html/0fd22223-8ca8-2955-e2ee-7d83d853ee8f.htm
---
# Autodesk.Revit.Creation.Application.NewFamilySymbolProfile Method

Creates a new FamilySymbolProfile object.

## Syntax (C#)
```csharp
public FamilySymbolProfile NewFamilySymbolProfile(
	FamilySymbol familySymbol
)
```

## Parameters
- **familySymbol** (`Autodesk.Revit.DB.FamilySymbol`) - The family symbol of the Profile.

## Returns
The new FamilySymbolProfile object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument familySymbol is Nothing nullptr a null reference ( Nothing in Visual Basic) .

