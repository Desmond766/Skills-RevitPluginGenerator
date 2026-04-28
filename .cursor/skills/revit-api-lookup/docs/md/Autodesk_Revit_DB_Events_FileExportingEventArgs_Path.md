---
kind: property
id: P:Autodesk.Revit.DB.Events.FileExportingEventArgs.Path
source: html/a3176eea-3c69-44d8-f0d0-678a642916c7.htm
---
# Autodesk.Revit.DB.Events.FileExportingEventArgs.Path Property

The target path for the export.

## Syntax (C#)
```csharp
public string Path { get; }
```

## Remarks
When several files are exported at the same time, 'Path' property will just report the directory instead of those full file names.

