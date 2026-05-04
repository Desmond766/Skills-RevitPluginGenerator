---
kind: method
id: M:Autodesk.Revit.DB.ImageExportOptions.IsValidForSaveToProjectAsImage(Autodesk.Revit.DB.ImageExportOptions,Autodesk.Revit.DB.Document)
source: html/5c064e7c-4fc6-035f-7c35-3e6a735e552f.htm
---
# Autodesk.Revit.DB.ImageExportOptions.IsValidForSaveToProjectAsImage Method

Verify if ImageExportOptions object is valid for calling saveToProjectAsImage

## Syntax (C#)
```csharp
public static bool IsValidForSaveToProjectAsImage(
	ImageExportOptions options,
	Document doc
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.ImageExportOptions`) - ImageExportOptions object to be validated
- **doc** (`Autodesk.Revit.DB.Document`) - Document for view name verification

## Returns
True if ImageExportOptions object is valid for calling saveToProjectAsImage; false otherwise

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

