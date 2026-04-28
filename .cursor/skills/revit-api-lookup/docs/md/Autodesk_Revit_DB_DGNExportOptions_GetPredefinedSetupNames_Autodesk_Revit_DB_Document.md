---
kind: method
id: M:Autodesk.Revit.DB.DGNExportOptions.GetPredefinedSetupNames(Autodesk.Revit.DB.Document)
source: html/bb5a7586-7d82-6a29-4fad-61ff0ae07ecf.htm
---
# Autodesk.Revit.DB.DGNExportOptions.GetPredefinedSetupNames Method

Returns a list of names of predefined setups of DGN export options.

## Syntax (C#)
```csharp
public static IList<string> GetPredefinedSetupNames(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve names from.

## Returns
An array of strings representing names of predefined setups.

## Remarks
To get predefined options in the desired format use the static method
 getPredefinedOptions defined in DGNExportOptions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

