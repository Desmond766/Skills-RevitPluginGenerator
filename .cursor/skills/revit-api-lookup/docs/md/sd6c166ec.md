---
kind: property
id: P:Autodesk.Revit.DB.BasicFileInfo.IsCreatedLocal
source: html/edb87333-ccef-5cc3-9965-074b69722203.htm
---
# Autodesk.Revit.DB.BasicFileInfo.IsCreatedLocal Property

Checks if the file is local and created by RevitServerTool.exe.

## Syntax (C#)
```csharp
public bool IsCreatedLocal { get; }
```

## Remarks
The value will be set to false after the file is saved and IsLocal will become true.

