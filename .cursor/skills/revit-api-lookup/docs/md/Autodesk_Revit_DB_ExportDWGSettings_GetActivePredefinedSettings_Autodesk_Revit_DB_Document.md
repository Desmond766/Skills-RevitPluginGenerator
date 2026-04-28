---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.GetActivePredefinedSettings(Autodesk.Revit.DB.Document)
source: html/94addb49-9531-141c-bfca-20377e135fa9.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.GetActivePredefinedSettings Method

Returns the active pre-defined non-in-session exporting settings for DWG in the given document.

## Syntax (C#)
```csharp
public static ExportDWGSettings GetActivePredefinedSettings(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve the active pre-defined exporting settings for DWG.

## Returns
The active pre-defined exporting settings for DWG, or null if nothing pre-defined exists or the in-session settings is selected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

