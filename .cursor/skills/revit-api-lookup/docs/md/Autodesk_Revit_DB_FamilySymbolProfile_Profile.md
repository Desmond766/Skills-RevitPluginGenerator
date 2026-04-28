---
kind: property
id: P:Autodesk.Revit.DB.FamilySymbolProfile.Profile
source: html/15a89854-bc42-7e79-097c-979220a3ad27.htm
---
# Autodesk.Revit.DB.FamilySymbolProfile.Profile Property

Returns the family symbol of the profile.

## Syntax (C#)
```csharp
public FamilySymbol Profile { get; set; }
```

## Remarks
The symbol must of the category BuiltInCategory.OST_ProfileFamilies.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the category of argument is not BuiltInCategory.OST_ProfileFamilies.

