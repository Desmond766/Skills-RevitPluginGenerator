---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPHiddenLineSettings.GetMEPHiddenLineSettings(Autodesk.Revit.DB.Document)
source: html/c4ab069a-1d78-5e72-d550-4d3da0139090.htm
---
# Autodesk.Revit.DB.Mechanical.MEPHiddenLineSettings.GetMEPHiddenLineSettings Method

Gets the MEP hidden line settings in the document.

## Syntax (C#)
```csharp
public static MEPHiddenLineSettings GetMEPHiddenLineSettings(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the settings element is found.

## Returns
The element which stores the MEP hidden line settings for the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

