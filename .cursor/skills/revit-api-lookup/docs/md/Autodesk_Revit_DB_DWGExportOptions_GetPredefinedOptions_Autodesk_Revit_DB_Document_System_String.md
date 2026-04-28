---
kind: method
id: M:Autodesk.Revit.DB.DWGExportOptions.GetPredefinedOptions(Autodesk.Revit.DB.Document,System.String)
source: html/0ae4a6f6-6a0a-8363-b580-7b61b61bca6d.htm
---
# Autodesk.Revit.DB.DWGExportOptions.GetPredefinedOptions Method

Returns an instance DWGExportOptions containing settings from a predefined export setup.

## Syntax (C#)
```csharp
public static DWGExportOptions GetPredefinedOptions(
	Document document,
	string setup
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A Revit project document to retrieve the setup from.
- **setup** (`System.String`) - The name of a predefined export setup from the specified document.

## Returns
An instance of predefined DWGExportOptions, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the name was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

