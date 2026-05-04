---
kind: method
id: M:Autodesk.Revit.DB.ExportDGNSettings.GetActivePredefinedSettings(Autodesk.Revit.DB.Document)
source: html/36729722-5758-bb63-2645-8cadd3981b75.htm
---
# Autodesk.Revit.DB.ExportDGNSettings.GetActivePredefinedSettings Method

Returns the active pre-defined non-in-session exporting settings for DGN in the given document.

## Syntax (C#)
```csharp
public static ExportDGNSettings GetActivePredefinedSettings(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve the active pre-defined exporting settings for DGN.

## Returns
The active pre-defined exporting settings for DGN, or null if nothing pre-defined exists or the in-session settings is selected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

