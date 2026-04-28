---
kind: property
id: P:Autodesk.Revit.DB.Events.FileExportedEventArgs.Path
source: html/1376a76c-5d92-5055-b9db-ec46bd5b4e46.htm
---
# Autodesk.Revit.DB.Events.FileExportedEventArgs.Path Property

Target path for the exported file (or files).

## Syntax (C#)
```csharp
public string Path { get; }
```

## Remarks
In some cases the path represents only the target directory or a template name.
 Such cases include batch export when more than one file is exported as one event.

