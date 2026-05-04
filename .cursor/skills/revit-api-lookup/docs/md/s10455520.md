---
kind: method
id: M:Autodesk.Revit.DB.ExportPatternTable.Add(Autodesk.Revit.DB.ExportPatternKey,Autodesk.Revit.DB.ExportPatternInfo)
source: html/8a71a857-2cd3-cac3-40da-fbdca6e6bf27.htm
---
# Autodesk.Revit.DB.ExportPatternTable.Add Method

Inserts a (key,info) pair into Export pattern table.

## Syntax (C#)
```csharp
public void Add(
	ExportPatternKey exportPatternKey,
	ExportPatternInfo exportPatternInfo
)
```

## Parameters
- **exportPatternKey** (`Autodesk.Revit.DB.ExportPatternKey`) - The export pattern key to be added.
- **exportPatternInfo** (`Autodesk.Revit.DB.ExportPatternInfo`) - The export pattern info to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The key already exists in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

