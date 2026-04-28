---
kind: method
id: M:Autodesk.Revit.DB.FamilySizeTableManager.ImportSizeTable(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.FamilySizeTableErrorInfo)
source: html/17fc8c33-626c-f39d-48a9-94e307e742bb.htm
---
# Autodesk.Revit.DB.FamilySizeTableManager.ImportSizeTable Method

Imports a FamilySizeTable from a CSV file.

## Syntax (C#)
```csharp
public bool ImportSizeTable(
	Document document,
	string filePath,
	FamilySizeTableErrorInfo errorInfo
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Family owned document or project document.
- **filePath** (`System.String`) - The CSV file path.
- **errorInfo** (`Autodesk.Revit.DB.FamilySizeTableErrorInfo`) - An error object to be written to if errors occur.

## Returns
True if successful, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

