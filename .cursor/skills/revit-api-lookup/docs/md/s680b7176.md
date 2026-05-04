---
kind: property
id: P:Autodesk.Revit.DB.TableData.ZoomLevel
source: html/ead726cc-7695-e71d-e4a6-919319bb58db.htm
---
# Autodesk.Revit.DB.TableData.ZoomLevel Property

The value of zoom level for corresponding TableView.

## Syntax (C#)
```csharp
public int ZoomLevel { get; set; }
```

## Remarks
This value is used to change the size of text fonts in tabular views, and then the size of rows, colums and cells
 will also be changed to satisfy the text. Note: This value is only used to improve the text readability in tabular view and will not change the size of texts, rows, columns and cells in sheet views. Note: This value is temporary setting just for this session. Note: This value is a percentage number which must be a multiple of 10 in the range of 10 to 400.
 A value of 400 indicates the maximum zoom permitted. The default value for new created tabular views is 100.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The value of zoom level must be a multiple of 10 in the range of 10 to 400.

