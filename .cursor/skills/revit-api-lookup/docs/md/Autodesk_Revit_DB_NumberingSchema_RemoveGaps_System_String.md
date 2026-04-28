---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.RemoveGaps(System.String)
source: html/a97a1aff-4afe-7aa7-098a-f71229efdccd.htm
---
# Autodesk.Revit.DB.NumberingSchema.RemoveGaps Method

Removes gaps, if any, in a numbering sequence

## Syntax (C#)
```csharp
public void RemoveGaps(
	string partition
)
```

## Parameters
- **partition** (`System.String`) - Name of the partition that identifies the sequence. The sequence must exist.

## Remarks
Gaps are removed by shifting numbers above each gap down by the amount of
 numbers skipped in the gap. The lowest number in the sequence will remain unchanged.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence partition does not exist in the schema.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.

