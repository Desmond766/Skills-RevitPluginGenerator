---
kind: method
id: M:Autodesk.Revit.DB.ExportLinetypeTable.Add(Autodesk.Revit.DB.ExportLinetypeKey,Autodesk.Revit.DB.ExportLinetypeInfo)
source: html/5c42f213-1bd5-bcb0-acbe-0997d0609574.htm
---
# Autodesk.Revit.DB.ExportLinetypeTable.Add Method

Inserts a (key, info) pair into Export line type table.

## Syntax (C#)
```csharp
public void Add(
	ExportLinetypeKey exportLinetypeKey,
	ExportLinetypeInfo exportLinetypeInfo
)
```

## Parameters
- **exportLinetypeKey** (`Autodesk.Revit.DB.ExportLinetypeKey`) - The export line type Key to be added.
- **exportLinetypeInfo** (`Autodesk.Revit.DB.ExportLinetypeInfo`) - The export line type info to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The key already exists in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

