---
kind: property
id: P:Autodesk.Revit.DB.TableSectionData.NumberOfColumns
source: html/e0f2e8a7-6992-d7a6-bbe9-a1ac5d678e1a.htm
---
# Autodesk.Revit.DB.TableSectionData.NumberOfColumns Property

Gets or sets the number of items in column data array.

## Syntax (C#)
```csharp
public int NumberOfColumns { get; set; }
```

## Remarks
Note that TableSections may use either 0 or 1 as the first row and column indices. To access the rows and columns:
 Use FirstRowNumber and LastRowNumber to get the valid range of row indices. Use FirstColumnNumber and LastColumnNumber to get the valid range of column indices.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation is forbidden for cells in standard schedule body sections.

