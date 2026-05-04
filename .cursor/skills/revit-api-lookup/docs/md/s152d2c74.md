---
kind: method
id: M:Autodesk.Revit.DB.ScheduleField.SetCombinedParameters(System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/b216f232-52b8-fbff-a0f7-649834dd213e.htm
---
# Autodesk.Revit.DB.ScheduleField.SetCombinedParameters Method

Sets this field's combine parameter array if applicable

## Syntax (C#)
```csharp
public void SetCombinedParameters(
	IList<TableCellCombinedParameterData> data
)
```

## Parameters
- **data** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - data is array of TableCellCombinedParameterData to be set as combined parameters

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

