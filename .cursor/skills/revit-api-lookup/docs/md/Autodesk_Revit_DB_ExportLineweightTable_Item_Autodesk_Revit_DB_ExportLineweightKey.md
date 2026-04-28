---
kind: property
id: P:Autodesk.Revit.DB.ExportLineweightTable.Item(Autodesk.Revit.DB.ExportLineweightKey)
source: html/f2edc48d-9a82-0f64-0d15-9a6acac81e53.htm
---
# Autodesk.Revit.DB.ExportLineweightTable.Item Property

A copy of the ExportLineweightInfo for the line weight's ExportLineweightKey .

## Syntax (C#)
```csharp
public ExportLineweightInfo this[
	ExportLineweightKey lineweightKey
] { get; set; }
```

## Parameters
- **lineweightKey** (`Autodesk.Revit.DB.ExportLineweightKey`)

## Returns
A copy of the ExportLineweightInfo .

## Remarks
When getting this property, it returns a copy of the ExportLineweightInfo from the table. In order to
 make changes to the ExportLineweightInfo and use those settings during export, set the modified
 ExportLineweightInfo back into the table using the same key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When getting this property:
 An entry with the given key is not present in the table.

