---
kind: method
id: M:Autodesk.Revit.DB.OptionalFunctionalityUtils.IsPDFImportAvailable
source: html/0807c7de-118e-c54c-a39e-9c2c78962add.htm
---
# Autodesk.Revit.DB.OptionalFunctionalityUtils.IsPDFImportAvailable Method

Checks whether PDF import is available in the installed Revit.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 because it will always return true. It will be removed in a future version of Revit")]
public static bool IsPDFImportAvailable()
```

## Returns
True if a PDF import is available in the installed Revit.

## Remarks
PDF Import requires the presence of certain modules that are optional and may not be part of the installed Revit.

