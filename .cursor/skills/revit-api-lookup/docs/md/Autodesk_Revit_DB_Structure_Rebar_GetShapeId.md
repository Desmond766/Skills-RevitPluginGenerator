---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetShapeId
zh: 钢筋、配筋
source: html/6edc946f-d8a3-ee78-adbb-7d5359501ed3.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetShapeId Method

**中文**: 钢筋、配筋

Returns the id of the RebarShape element that defines the shape of the rebar.

## Syntax (C#)
```csharp
public ElementId GetShapeId()
```

## Remarks
A Free Form Rebar that has Workshop Instructions set to Bent is considered to have multiple shapes and this method will throw exception. A Free Form Rebar that has Workshop Instructions set to Straight or a Shape Driven is considered to have only one shape and this method will return the id of that shape.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Rebar is matched with multiple shapes.

