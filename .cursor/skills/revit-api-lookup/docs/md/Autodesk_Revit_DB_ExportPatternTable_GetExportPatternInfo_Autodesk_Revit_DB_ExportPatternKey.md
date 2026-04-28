---
kind: method
id: M:Autodesk.Revit.DB.ExportPatternTable.GetExportPatternInfo(Autodesk.Revit.DB.ExportPatternKey)
source: html/8924d166-56f7-72a0-b4f7-ccd7aa6dc172.htm
---
# Autodesk.Revit.DB.ExportPatternTable.GetExportPatternInfo Method

Gets a copy of the pattern info associated to the input pattern key.

## Syntax (C#)
```csharp
public ExportPatternInfo GetExportPatternInfo(
	ExportPatternKey exportPatternKey
)
```

## Parameters
- **exportPatternKey** (`Autodesk.Revit.DB.ExportPatternKey`) - The export pattern Key.

## Returns
Return the patternInfo for this key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An entry with the given key is not present in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

