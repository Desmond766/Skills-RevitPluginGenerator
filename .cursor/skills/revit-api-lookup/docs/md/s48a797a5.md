---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.ListNames(Autodesk.Revit.DB.Document)
source: html/7ad9e021-bd2f-5b85-2138-b7698e41b71a.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.ListNames Method

Returns all the names of the settings instances in the document.

## Syntax (C#)
```csharp
public static IList<string> ListNames(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where the settings to be found.

## Returns
List of names.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

