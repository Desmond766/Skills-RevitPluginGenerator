---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.IsValidColumnNumber(System.Int32)
source: html/76758f6a-d3c4-5280-5ba9-7fe2df85c3c5.htm
---
# Autodesk.Revit.DB.TableSectionData.IsValidColumnNumber Method

Verifies if the column number is valid.

## Syntax (C#)
```csharp
public bool IsValidColumnNumber(
	int nCol
)
```

## Parameters
- **nCol** (`System.Int32`) - The column number.

## Returns
True if the column number is between FirstColumnNumber and LastColumnNumber, false otherwise.

