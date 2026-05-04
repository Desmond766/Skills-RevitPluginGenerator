---
kind: property
id: P:Autodesk.Revit.DB.ExportLinetypeTable.Item(Autodesk.Revit.DB.ExportLinetypeKey)
source: html/46730a76-f14e-8993-9c0f-0782933cc5ef.htm
---
# Autodesk.Revit.DB.ExportLinetypeTable.Item Property

A copy of the ExportLinetypeInfo for the linetype's ExportLinetypeKey .

## Syntax (C#)
```csharp
public ExportLinetypeInfo this[
	ExportLinetypeKey linetypeKey
] { get; set; }
```

## Parameters
- **linetypeKey** (`Autodesk.Revit.DB.ExportLinetypeKey`)

## Returns
A copy of the ExportLinetypeInfo .

## Remarks
When getting this property, it returns a copy of the ExportLinetypeInfo from the table. In order to
 make changes to the ExportLinetypeInfo and use those settings during export, set the modified
 ExportLinetypeInfo back into the table using the same key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When getting this property:
 An entry with the given key is not present in the table.

