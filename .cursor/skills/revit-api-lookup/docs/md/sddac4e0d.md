---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCase.IsLoadCaseSubcategoryId(Autodesk.Revit.DB.ElementId)
source: html/734e2dd6-2686-2ec5-2b5c-ed0566f97630.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.IsLoadCaseSubcategoryId Method

Checks whether provided element ID refer to subcategory of Structural Load Cases ( OST_LoadCases ) category - one of built-in or user defined.

## Syntax (C#)
```csharp
public bool IsLoadCaseSubcategoryId(
	ElementId loadCaseSubcategoryId
)
```

## Parameters
- **loadCaseSubcategoryId** (`Autodesk.Revit.DB.ElementId`) - The ID to check.

## Returns
True if the ID refers to load case category element, false otherwise.

## Remarks
Built-in structural Load Cases ( OST_LoadCases ) subcategories are:
 OST_LoadCasesDead OST_LoadCasesLive OST_LoadCasesWind OST_LoadCasesSnow OST_LoadCasesRoofLive OST_LoadCasesAccidental OST_LoadCasesTemperature OST_LoadCasesSeismic

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

