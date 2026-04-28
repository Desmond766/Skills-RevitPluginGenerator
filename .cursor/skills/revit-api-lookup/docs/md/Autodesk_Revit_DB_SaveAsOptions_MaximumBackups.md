---
kind: property
id: P:Autodesk.Revit.DB.SaveAsOptions.MaximumBackups
source: html/6583d3ce-1cb4-ec6e-7a5f-94c1e2346b3a.htm
---
# Autodesk.Revit.DB.SaveAsOptions.MaximumBackups Property

The maximum number of backups to keep on disk.

## Syntax (C#)
```csharp
public int MaximumBackups { get; set; }
```

## Remarks
Non-workshared models have whole-file backups, sequentially numbered. File-based workshared models have eager, incremental backups
 in a backup folder adjacent to the model itself:
 Every save backs up all changed data and avoids recopying unchanged elements,
 so the latest backup is equivalent to the main copy on disk and
 the backup folder does not have huge amounts of redundant data.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The requested number of backups is out of range.

