---
kind: method
id: M:Autodesk.Revit.DB.ConfigurationReloadInfo.GetOutOfDatePartStatus(System.Int32)
source: html/7281d696-b9c8-130e-a165-9906dd5aad29.htm
---
# Autodesk.Revit.DB.ConfigurationReloadInfo.GetOutOfDatePartStatus Method

Access reload information for out of date part.

## Syntax (C#)
```csharp
public ReloadSwapOutInfo GetOutOfDatePartStatus(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the information about the part being reloaded. Must be between 0 and OutOfDatePartCount.

## Returns
Information about the part being reloaded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is out of range.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

