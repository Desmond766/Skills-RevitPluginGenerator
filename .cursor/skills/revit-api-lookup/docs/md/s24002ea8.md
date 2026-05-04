---
kind: type
id: T:Autodesk.Revit.DB.IFC.ImporterIFC
source: html/87327a4b-94fd-5a21-df33-9beb1921cb4d.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFC

The main class provided by Revit to allow implementation of IFC import.

## Syntax (C#)
```csharp
public class ImporterIFC : IDisposable
```

## Remarks
An instance of this class is provided to clients which implement IImporterIFC
 in order to provide an implementation for IFC import. It contains information
 on the options selected by the user for the import operation, as well as
 members used to access specific types of data needed to implement the import
 properly.

