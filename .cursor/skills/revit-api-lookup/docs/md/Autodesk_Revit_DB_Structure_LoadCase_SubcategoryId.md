---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadCase.SubcategoryId
source: html/1497f43e-609a-7cbc-4a08-2cd4e8f14ec7.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.SubcategoryId Property

Build-in or user defined subcategory of Structural Load Cases ( OST_LoadCases ) category.

## Syntax (C#)
```csharp
public ElementId SubcategoryId { get; set; }
```

## Remarks
Build-in Structural Load Cases ( OST_LoadCases ) subcategories are:
 OST_LoadCasesDead OST_LoadCasesLive OST_LoadCasesWind OST_LoadCasesSnow OST_LoadCasesRoofLive OST_LoadCasesAccidental OST_LoadCasesTemperature OST_LoadCasesSeismic

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the subcategoryId does not refer to predefined nor user defined load case category element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

