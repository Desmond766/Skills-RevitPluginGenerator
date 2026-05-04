---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCImportOptions.SetExtraOptions(System.Collections.Generic.IDictionary{System.String,System.String})
source: html/a2800b08-bb26-a9c7-0cdf-c995c9e2be63.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.SetExtraOptions Method

Set the list of extra options to be passed into the importer. Each entry in the map is a pair of option name and value.
 Note that any value here will overwrite the other values in the IFCImportOptions, if it has the same name.

## Syntax (C#)
```csharp
public void SetExtraOptions(
	IDictionary<string, string> options
)
```

## Parameters
- **options** (`System.Collections.Generic.IDictionary < String , String >`) - The list of options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

