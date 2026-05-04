---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertCombinedParameterField(System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData},System.String,System.Int32)
source: html/f33ac062-b861-dd2e-93b4-32f2124151ff.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertCombinedParameterField Method

Adds a combined parameter field at the specified position in the list.

## Syntax (C#)
```csharp
public ScheduleField InsertCombinedParameterField(
	IList<TableCellCombinedParameterData> data,
	string fieldName,
	int index
)
```

## Parameters
- **data** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The combined parameters array.
- **fieldName** (`System.String`) - The field name.
- **index** (`System.Int32`) - The index in the list of fields.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.

