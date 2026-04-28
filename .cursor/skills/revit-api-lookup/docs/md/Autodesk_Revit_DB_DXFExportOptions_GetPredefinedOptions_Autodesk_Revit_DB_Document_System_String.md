---
kind: method
id: M:Autodesk.Revit.DB.DXFExportOptions.GetPredefinedOptions(Autodesk.Revit.DB.Document,System.String)
source: html/620109f4-db30-4b79-57be-49adcebda4bf.htm
---
# Autodesk.Revit.DB.DXFExportOptions.GetPredefinedOptions Method

Returns an instance DXFExportOptions containing settings from a predefined export setup.

## Syntax (C#)
```csharp
public static DXFExportOptions GetPredefinedOptions(
	Document document,
	string setup
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A Revit project document to retrieve the setup from.
- **setup** (`System.String`) - The name of a predefined export setup from the specified document.

## Returns
An instance of predefined DXFExportOptions, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the name was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

