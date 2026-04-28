---
kind: method
id: M:Autodesk.Revit.DB.RevisionNumberingSequence.SetAlphanumericRevisionSettings(Autodesk.Revit.DB.AlphanumericRevisionSettings)
source: html/e0c9a915-c30d-ed9c-eb5e-65a7e1f73e91.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.SetAlphanumericRevisionSettings Method

Replaces the current alphanumeric revision numbering settings with the provided settings.

## Syntax (C#)
```csharp
public void SetAlphanumericRevisionSettings(
	AlphanumericRevisionSettings settings
)
```

## Parameters
- **settings** (`Autodesk.Revit.DB.AlphanumericRevisionSettings`) - The AlphanumericRevisionSettings to be applied to alphanumeric revision numbering.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - settings is not a valid AlphanumericRevisionSettings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

