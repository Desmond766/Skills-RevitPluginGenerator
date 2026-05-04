---
kind: method
id: M:Autodesk.Revit.DB.BaseExportOptions.GetPredefinedSetupNames(Autodesk.Revit.DB.Document)
source: html/815928cf-5c0e-ceda-c9ac-a3b1c992e27b.htm
---
# Autodesk.Revit.DB.BaseExportOptions.GetPredefinedSetupNames Method

Returns a list of names of predefined setups of export options.

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
The predefined setups may be used for export to both DWG and DXF formats.
 To get predefined options in the desired format use the static method
 getPredefinedOptions defined in DWGExportOptions or DXFExportOptions respectively.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

