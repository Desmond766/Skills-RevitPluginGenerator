---
kind: method
id: M:Autodesk.Revit.DB.INavisworksExporter.ValidateExportOptions(Autodesk.Revit.DB.Document,System.String,System.String,Autodesk.Revit.DB.NavisworksExportOptions,System.String@)
source: html/bfcbee8d-a3df-b9c2-b25d-ce83343fab14.htm
---
# Autodesk.Revit.DB.INavisworksExporter.ValidateExportOptions Method

Determines if the inputs are valid, and returns an error message if not.

## Syntax (C#)
```csharp
bool ValidateExportOptions(
	Document document,
	string folder,
	string name,
	NavisworksExportOptions options,
	out string exceptionMessage
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to export.
- **folder** (`System.String`) - The folder path.
- **name** (`System.String`) - The file name.
- **options** (`Autodesk.Revit.DB.NavisworksExportOptions`) - The export options.
- **exceptionMessage** (`System.String %`) - The message to show in the exception thrown. This is not an end-user visible message, it is a
 developer message, and does not have to be localized. Ignored if the function returns true.

## Returns
True if the options are valid, false otherwise.

