---
kind: method
id: M:Autodesk.Revit.DB.DGNExportOptions.GetPredefinedOptions(Autodesk.Revit.DB.Document,System.String)
source: html/3befd44a-4aee-e83c-369c-4beeebebaef5.htm
---
# Autodesk.Revit.DB.DGNExportOptions.GetPredefinedOptions Method

Returns an instance DGNExportOptions containing settings from a predefined export setup.

## Syntax (C#)
```csharp
public static DGNExportOptions GetPredefinedOptions(
	Document document,
	string setup
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A Revit project document to retrieve the setup from.
- **setup** (`System.String`) - The name of a predefined export setup from the specified document.

## Returns
An instance of predefined DGNExportOptions, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the name was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

