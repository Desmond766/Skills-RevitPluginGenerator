---
kind: method
id: M:Autodesk.Revit.DB.ExportDGNSettings.FindByName(Autodesk.Revit.DB.Document,System.String)
source: html/ca567957-39e9-3750-b515-c91bf67186d6.htm
---
# Autodesk.Revit.DB.ExportDGNSettings.FindByName Method

Returns the pre-defined non-in-session exporting settings for DGN in the given document with the specified name.

## Syntax (C#)
```csharp
public static ExportDGNSettings FindByName(
	Document aDoc,
	string name
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve the specified pre-defined exporting settings for DGN.
- **name** (`System.String`) - The name of the settings to retrieve.

## Returns
The pre-defined DGN exporting settings, or null if nothing found that has the corresponding name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

