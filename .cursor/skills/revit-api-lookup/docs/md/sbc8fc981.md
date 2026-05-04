---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.Read(Autodesk.Revit.DB.IFC.IFCFileReadOptions)
source: html/df7acfe7-6245-fd72-47d1-37c3081c4b19.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.Read Method

Reads content from a file of IFC format.

## Syntax (C#)
```csharp
public void Read(
	IFCFileReadOptions readOptions
)
```

## Parameters
- **readOptions** (`Autodesk.Revit.DB.IFC.IFCFileReadOptions`) - The IFC file read options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Error reading opening model for unzipping.
 Error reading IFC file.

