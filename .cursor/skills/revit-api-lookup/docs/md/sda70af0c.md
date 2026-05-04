---
kind: method
id: M:Autodesk.Revit.DB.FamilySizeTableManager.ExportSizeTable(System.String,System.String)
source: html/40539d6c-8288-94cb-0052-2e8203d15e43.htm
---
# Autodesk.Revit.DB.FamilySizeTableManager.ExportSizeTable Method

Exports the size table to aCSV file.

## Syntax (C#)
```csharp
public bool ExportSizeTable(
	string tableName,
	string filePath
)
```

## Parameters
- **tableName** (`System.String`) - The bool name to export.
- **filePath** (`System.String`) - The CSV file to export to.

## Returns
True if successful, false otherwise..

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

