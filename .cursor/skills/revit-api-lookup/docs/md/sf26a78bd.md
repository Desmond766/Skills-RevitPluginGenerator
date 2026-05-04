---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.SelectFaces
source: html/8f1a01ab-04c7-3a60-2055-5e0d8305255d.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.SelectFaces Property

Indicates whether elements can be selected by clicking on the interior of a face.

## Syntax (C#)
```csharp
public bool SelectFaces { get; set; }
```

## Remarks
When this setting is false, users must click on an edge or vertex of an element
 in order to select the corresponding element. When it is true, users may also select elements by clicking
 on the interior of a face of an element.

