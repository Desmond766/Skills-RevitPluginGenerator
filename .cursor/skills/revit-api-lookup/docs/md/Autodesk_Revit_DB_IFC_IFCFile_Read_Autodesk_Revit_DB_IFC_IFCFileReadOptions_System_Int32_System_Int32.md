---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.Read(Autodesk.Revit.DB.IFC.IFCFileReadOptions,System.Int32@,System.Int32@)
source: html/bb561799-a239-6205-c0a5-250c31200472.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.Read Method

Reads content from a file of IFC format.

## Syntax (C#)
```csharp
public void Read(
	IFCFileReadOptions readOptions,
	out int pNumErrors,
	out int pNumWarnings
)
```

## Parameters
- **readOptions** (`Autodesk.Revit.DB.IFC.IFCFileReadOptions`) - The IFC file read options.
- **pNumErrors** (`System.Int32 %`) - The number of errors reported during the read process. The actual messages will be in the log file.
- **pNumWarnings** (`System.Int32 %`) - The number of warnings reported during the read process. The actual messages will be in the log file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Error reading opening model for unzipping.
 Error reading IFC file.

