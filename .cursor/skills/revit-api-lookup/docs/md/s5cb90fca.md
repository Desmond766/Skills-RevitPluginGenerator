---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckExportCategory(Autodesk.Revit.DB.ElementId)
source: html/a29a9a14-1b3f-c4ef-220e-011818b56e83.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckExportCategory Method

Checks whether the export category falls within the list:
 OST_Rooms OST_MEPSpaces

## Syntax (C#)
```csharp
public static bool CheckExportCategory(
	ElementId exportCategoryId
)
```

## Parameters
- **exportCategoryId** (`Autodesk.Revit.DB.ElementId`) - The export category to be checked.

## Returns
True if the export category falls within the list, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

