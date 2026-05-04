---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.IsWorksetNameUnique(Autodesk.Revit.DB.Document,System.String)
source: html/6728440e-41db-179d-2b5c-1184f8decf8d.htm
---
# Autodesk.Revit.DB.WorksetTable.IsWorksetNameUnique Method

Checks if the given workset name is unique in the document.

## Syntax (C#)
```csharp
public static bool IsWorksetNameUnique(
	Document aDoc,
	string name
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document in which the workset is accessed.
- **name** (`System.String`) - The workset name.

## Returns
True if this given workset name is unique in the document, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

