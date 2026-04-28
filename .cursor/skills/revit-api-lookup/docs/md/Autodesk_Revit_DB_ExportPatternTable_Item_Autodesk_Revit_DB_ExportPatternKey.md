---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternTable.Item(Autodesk.Revit.DB.ExportPatternKey)
source: html/02045e44-0878-ade7-08b8-3746f1e3f9d2.htm
---
# Autodesk.Revit.DB.ExportPatternTable.Item Property

A copy of the ExportPatternInfo for the pattern's ExportPatternKey .

## Syntax (C#)
```csharp
public ExportPatternInfo this[
	ExportPatternKey patternKey
] { get; set; }
```

## Parameters
- **patternKey** (`Autodesk.Revit.DB.ExportPatternKey`)

## Returns
A copy of the ExportPatternInfo .

## Remarks
When getting this property, it returns a copy of the ExportPatternInfo from the table. In order to
 make changes to the ExportPatternInfo and use those settings during export, set the modified
 ExportPatternInfo back into the table using the same key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When getting this property:
 An entry with the given key is not present in the table.

