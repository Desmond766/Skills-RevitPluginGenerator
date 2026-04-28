---
kind: method
id: M:Autodesk.Revit.DB.RevisionNumberingSequence.GetNumericRevisionSettings
source: html/63cbff5e-855c-9237-a160-e90f7e1f7a17.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.GetNumericRevisionSettings Method

Returns a copy of the NumericRevisionSettings owned by this revision numbering sequence.

## Syntax (C#)
```csharp
public NumericRevisionSettings GetNumericRevisionSettings()
```

## Returns
The copy of the NumericRevisionSettings owned by this revision numbering sequence.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevisionNumberingSequence doesn't own a valid numeric revision settings.

