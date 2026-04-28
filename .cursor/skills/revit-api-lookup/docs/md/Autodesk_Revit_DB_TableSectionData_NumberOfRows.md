---
kind: property
id: P:Autodesk.Revit.DB.TableSectionData.NumberOfRows
source: html/9f375c42-8018-a7ad-4d43-7c7c6cb1476b.htm
---
# Autodesk.Revit.DB.TableSectionData.NumberOfRows Property

Gets or sets the number of items in row data array.

## Syntax (C#)
```csharp
public int NumberOfRows { get; set; }
```

## Remarks
Note that TableSections may use either 0 or 1 as the first row and column indices. To access the rows and columns:
 Use FirstRowNumber and LastRowNumber to get the valid range of row indices. Use FirstColumnNumber and LastColumnNumber to get the valid range of column indices.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation is forbidden for cells in standard schedule body sections.

