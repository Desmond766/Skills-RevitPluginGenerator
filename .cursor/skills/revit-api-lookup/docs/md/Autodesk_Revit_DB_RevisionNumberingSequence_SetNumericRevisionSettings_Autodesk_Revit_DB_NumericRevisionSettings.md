---
kind: method
id: M:Autodesk.Revit.DB.RevisionNumberingSequence.SetNumericRevisionSettings(Autodesk.Revit.DB.NumericRevisionSettings)
source: html/70bd6afe-8775-cf7d-6f8e-3198f988ae71.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.SetNumericRevisionSettings Method

Replaces the current numeric revision numbering settings with the provided settings.

## Syntax (C#)
```csharp
public void SetNumericRevisionSettings(
	NumericRevisionSettings settings
)
```

## Parameters
- **settings** (`Autodesk.Revit.DB.NumericRevisionSettings`) - The NumericRevisionSettings to be applied to numeric revision numbering.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - settings is not a valid NumericRevisionSettings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

