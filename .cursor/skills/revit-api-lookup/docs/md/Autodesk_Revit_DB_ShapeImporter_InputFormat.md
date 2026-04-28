---
kind: property
id: P:Autodesk.Revit.DB.ShapeImporter.InputFormat
source: html/ff8a86a4-620e-1077-426b-540bd27027e6.htm
---
# Autodesk.Revit.DB.ShapeImporter.InputFormat Property

The format of the incoming data.

## Syntax (C#)
```csharp
public ShapeImporterSourceFormat InputFormat { get; set; }
```

## Remarks
If this option is set to Auto (the default), the file name extension will be used to determine the input format. That covers most file-based data import workflows.
 Specify the input format explicitly to perform an additional sanity check or if you are using a non-standard file extension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

