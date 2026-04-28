---
kind: method
id: M:Autodesk.Revit.DB.Architecture.BalusterPattern.DuplicateBaluster(System.Int32)
source: html/10f4c489-9d7e-5520-f8a0-b50a53d87dc5.htm
---
# Autodesk.Revit.DB.Architecture.BalusterPattern.DuplicateBaluster Method

Duplicates the baluster pointed by given index in the main baluster pattern.

## Syntax (C#)
```csharp
public BalusterInfo DuplicateBaluster(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Baluster index.

## Returns
The duplicated baluster.

## Remarks
The new baluster will be inserted just after the source baluster.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index index is out of range.

