---
kind: type
id: T:Autodesk.Revit.DB.IFC.ExporterIFC
source: html/c8697b81-e080-9202-14d3-ec883f951521.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC

The main class provided by Revit to allow implementation of IFC export.

## Syntax (C#)
```csharp
public class ExporterIFC : IDisposable
```

## Remarks
An instance of this class is provided to clients which implement IExporterIFC
 in order to provide an implementation for IFC export. It contains information
 on the options selected by the user for the export operation, as well as
 members used to access specific types of data needed to implement the export
 properly.

