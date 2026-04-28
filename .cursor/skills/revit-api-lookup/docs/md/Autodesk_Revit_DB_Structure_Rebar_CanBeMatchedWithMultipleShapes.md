---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CanBeMatchedWithMultipleShapes
zh: 钢筋、配筋
source: html/82bd14f6-8678-d37c-1848-54a97d2aa7d3.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CanBeMatchedWithMultipleShapes Method

**中文**: 钢筋、配筋

Checks if this Rebar can be matched with multiple Rebar Shapes.

## Syntax (C#)
```csharp
public bool CanBeMatchedWithMultipleShapes()
```

## Returns
Returns true if this Rebar can be matched with multiple Rebar Shapes, false otherwise.

## Remarks
A Free Form Rebar that has Workshop Instructions set to Bent is considered that can be matched with multiple shapes. A Free Form Rebar that has Workshop Instructions set to Straight or a Shape Driven Rebar is considered that can be matched with only one shape.

