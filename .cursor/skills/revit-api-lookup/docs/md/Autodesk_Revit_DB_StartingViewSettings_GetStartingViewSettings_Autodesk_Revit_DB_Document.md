---
kind: method
id: M:Autodesk.Revit.DB.StartingViewSettings.GetStartingViewSettings(Autodesk.Revit.DB.Document)
source: html/84788ba0-4edd-5483-eb22-898dbc21520b.htm
---
# Autodesk.Revit.DB.StartingViewSettings.GetStartingViewSettings Method

Returns the starting view settings for the specified document.

## Syntax (C#)
```csharp
public static StartingViewSettings GetStartingViewSettings(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document to get the settings from, which must be a project document.

## Returns
The starting view settings for the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - doc is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

