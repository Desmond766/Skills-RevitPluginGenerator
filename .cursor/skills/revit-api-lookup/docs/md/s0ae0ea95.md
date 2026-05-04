---
kind: method
id: M:Autodesk.Revit.DB.ExportLineweightTable.Add(Autodesk.Revit.DB.ExportLineweightKey,Autodesk.Revit.DB.ExportLineweightInfo)
source: html/be132c11-b6d2-7204-e54e-360cb612adaf.htm
---
# Autodesk.Revit.DB.ExportLineweightTable.Add Method

Inserts a (key, info) pair into Export line weight table.

## Syntax (C#)
```csharp
public void Add(
	ExportLineweightKey exportLineweightKey,
	ExportLineweightInfo exportLineweightInfo
)
```

## Parameters
- **exportLineweightKey** (`Autodesk.Revit.DB.ExportLineweightKey`) - The export line weight Key to be added.
- **exportLineweightInfo** (`Autodesk.Revit.DB.ExportLineweightInfo`) - The export line weight info to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The key already exists in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

