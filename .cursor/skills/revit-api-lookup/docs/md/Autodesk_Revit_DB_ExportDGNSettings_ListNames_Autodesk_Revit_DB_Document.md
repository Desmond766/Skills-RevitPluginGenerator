---
kind: method
id: M:Autodesk.Revit.DB.ExportDGNSettings.ListNames(Autodesk.Revit.DB.Document)
source: html/1a7d76ec-3042-cb83-cb8f-8c521398c843.htm
---
# Autodesk.Revit.DB.ExportDGNSettings.ListNames Method

Returns a list of names of dgn export settings.

## Syntax (C#)
```csharp
public static IList<string> ListNames(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve names from

## Returns
An array of strings representing names of predefined setups.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

