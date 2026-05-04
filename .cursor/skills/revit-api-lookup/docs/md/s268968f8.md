---
kind: method
id: M:Autodesk.Revit.DB.IFCExportOptions.AddOption(System.String,System.String)
source: html/74b280e6-bccb-703b-e63d-341bc64ed729.htm
---
# Autodesk.Revit.DB.IFCExportOptions.AddOption Method

Adds a new named option to the options structure.

## Syntax (C#)
```csharp
public void AddOption(
	string name,
	string value
)
```

## Parameters
- **name** (`System.String`) - The option name.
- **value** (`System.String`) - The option value.

## Remarks
Named options can be used to set options not accessible through the standard IFC export user interface.
 It is up to the implementation of the IExporterIFC interface to customize export behavior based on these options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

