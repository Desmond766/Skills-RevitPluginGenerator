---
kind: property
id: P:Autodesk.Revit.DB.IFCExportOptions.FamilyMappingFile
source: html/d9696d40-cf97-5d24-8151-662e35e7d616.htm
---
# Autodesk.Revit.DB.IFCExportOptions.FamilyMappingFile Property

Path to a file containing family mapping.

## Syntax (C#)
```csharp
public string FamilyMappingFile { get; set; }
```

## Remarks
The file, if specified, contains data describing how to map
 generic family instances to IFC containers (element types). This property
 may be empty, in which case the current mapping will be used.
 The default is an empty string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

