---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.FindByName(Autodesk.Revit.DB.Document,System.String)
source: html/8c4fd57e-67b9-92d5-6bbe-88be485f25dd.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.FindByName Method

Returns the pre-defined non-in-session exporting settings for DWG in the given document with the specified name.

## Syntax (C#)
```csharp
public static ExportDWGSettings FindByName(
	Document aDoc,
	string name
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve the specified pre-defined exporting settings for DWG.
- **name** (`System.String`) - The name of the settings to retrieve.

## Returns
The pre-defined DWG exporting settings, or null if nothing found that has the corresponding name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

